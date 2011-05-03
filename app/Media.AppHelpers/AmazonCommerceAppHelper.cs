using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using Media.AppHelpers.Amazon;
using Media.BC;
using Media.BE;
using Media.CO;
using Simple;

namespace Media.AppHelpers
{
    public class AmazonCommerceAppHelper : IAppHelper
    {
        private readonly string accessKeyId;
        private readonly string secretKey;
//        private string accessKeyId = "AKIAISVP2WI7QJFOCXKQ";
//        private string secretKey = "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";

        public AmazonCommerceAppHelper(string accessKeyId, string secretKey)
        {
            this.accessKeyId = accessKeyId;
            this.secretKey = secretKey;
        }

        public AppHelperItem[] LocateItems(AppHelperContext context)
        {
            // prepare an ItemSearch request
            ItemSearchRequest request = new ItemSearchRequest();
            request.SearchIndex = "DVD";
            request.Title = (string)context["title"];
            request.ResponseGroup = new[] { "ItemAttributes", "EditorialReview", "Images" };

            var response = DoSearch(request);

            return response.Items[0].Item.Select(item => new AmazonAppHelperItem()
                                                         {
                                                             Name = item.ItemAttributes.Title, Value = item
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
            XmlSerializer ser = new XmlSerializer(typeof(Item));
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
            context["cast"] = string.Join(", ", details.ItemAttributes.Actor);
            context["director"] = string.Join(", ", details.ItemAttributes.Director);
            context["length"] = details.ItemAttributes.RunningTime.Value + " " + details.ItemAttributes.RunningTime.Units;
            DateTime relDate = DateTime.Parse(details.ItemAttributes.TheatricalReleaseDate);
            context["year"] = relDate.Year;
            return true;
        }

        public string Name
        {
            get { return "Amazon AWSECommerceService"; }
        }
    }
}
