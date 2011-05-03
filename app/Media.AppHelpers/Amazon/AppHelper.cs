using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Media.AppHelpers.Amazon.Signing;
using Media.BC;
using Media.BE;
using Media.CO;

namespace Media.AppHelpers.Amazon
{
    public class AppHelper : IAppHelper
    {
        private readonly string accessKeyId;
        private readonly string secretKey;

        public AppHelper(string accessKeyId, string secretKey)
        {
            this.accessKeyId = accessKeyId;
            this.secretKey = secretKey;
        }

        public AppHelperItem[] LocateItems(AppHelperContext context)
        {
            // prepare an ItemSearch request
            ItemSearchRequest request = new ItemSearchRequest();
            request.SearchIndex = "DVD";
            request.Keywords = (string) context["title"];
            request.ResponseGroup = new[] { "ItemAttributes", "EditorialReview", "Images" };

            var response = DoSearch(request);
            var item = response.Items[0];

            if (item.Request.Errors != null && item.Request.Errors.Length > 0)
            {
                // TODO: log error messages?
                return new AppHelperItem[0];
            }
            return item.Item.Select(x=> new AmazonAppHelperItem()
                                                         {
                                                             Name = x.ItemAttributes.Title, Value = x
                                                         }).Cast<AppHelperItem>().ToArray();
        }

        ItemSearchResponse DoSearch(ItemSearchRequest request)
        {
            var client = CreateClient();

            var req = new ItemSearchRequest1 {ItemSearch = new ItemSearch {Request = new[] {request}, AWSAccessKeyId = accessKeyId}};
            ItemSearchResponse1 response1 = client.ItemSearch(req);
            return response1.ItemSearchResponse;
        }

        private AWSECommerceServicePortType CreateClient()
        {
            var client = new AWSECommerceServicePortTypeClient();
            client.ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(accessKeyId, secretKey));
            return client;
        }

        public bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            Item details = (Item) item.Value;
            // for debugging
            XmlSerializer ser = new XmlSerializer(typeof (Item));
            StringWriter outWriter = new StringWriter();
            ser.Serialize(outWriter, details);
            string xml = outWriter.ToString();
            // end debugging
            context["title"] = details.ItemAttributes.Title;
            if (!string.IsNullOrEmpty(details.ItemAttributes.MiniMovieDescription))
                context["summary"] = details.ItemAttributes.MiniMovieDescription;
            else if (details.EditorialReviews.Length > 0)
                context["summary"] = details.EditorialReviews[0].Content;
            if (!string.IsNullOrEmpty(details.LargeImage.URL))
            {
                context["imageURL"] = details.LargeImage.URL;
                context["imageData"] = IOUtil.LoadUrl(details.LargeImage.URL);
            }
            if (details.ItemAttributes.Actor != null)
                context["cast"] = string.Join(", ", details.ItemAttributes.Actor);
            if (details.ItemAttributes.Director != null)
                context["director"] = string.Join(", ", details.ItemAttributes.Director);
            context["length"] = details.ItemAttributes.RunningTime.Value + " " +
                                details.ItemAttributes.RunningTime.Units;
            DateTime relDate;
            if (DateTime.TryParse(details.ItemAttributes.TheatricalReleaseDate, out relDate))
                context["year"] = relDate.Year;
            else
                context["year"] = details.ItemAttributes.TheatricalReleaseDate;
            
            return true;
        }

        public string Name
        {
            get { return "Amazon"; }
        }
    }
}
