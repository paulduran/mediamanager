using System.Net;
using System.IO;
using System.Xml.Linq;
using Media.BC;
using Media.BE;
using Media.CO;

namespace Media.AppHelpers.Imdb
{
    public class ImdbAppHelperItem : AppHelperItem
    {
        #region AppHelperItem Members

        public string Name { get; set; }

        public object Value { get; set; }

        //	public HttpWebResponse Response = null;
        #endregion

    }

    /// <summary>
    /// Summary description for AppHelper.
    /// </summary>
    public class AppHelper : RegexAppHelper
    {              
        #region AppHelper Members

        public override string Name
        {
            get { return "IMDB"; }
        }

        /// <summary>
        /// locates the items (ie: performs a search) using the data in the context. the context
        /// will (possibly) contain data in fields declared as inputFields in the helper contract
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AppHelperItem[] LocateItems(AppHelperContext context)
        {
            string url = BuildSearchUrl(context);

            Debug("requesting URL: " + url);
            var request = WebRequest.Create(url);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Debug("response URI: " + response.ResponseUri);
            Debug("response status code: " + response.StatusCode);
            Debug("content type: " + response.ContentType);
            AppHelperItem[] items;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                items = ProcessSearchResponse(response.GetResponseStream());             
            }
            else
            {
                // something strange happened...
                items = new ImdbAppHelperItem[0];
            }
            response.Close();
            return items;
        }
       
        private ImdbAppHelperItem[] ProcessSearchResponse(Stream stream)
        {
            XDocument document = XDocument.Load(stream);
            var movie = document.Element("root").Element("movie");
            ImdbAppHelperItem item = new ImdbAppHelperItem
                                     {
                                         Name =
                                             string.Format("{0} ({1})", movie.Attribute("title").Value,
                                                           movie.Attribute("year").Value),
                                         Value = movie.Attribute("id").Value
                                     };
            return new[] { item };
        }       

        public override bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            string url = string.Format("http://www.imdbapi.com/?i={0}&r=XML", item.Value);
            context["URL"] = url;
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.UserAgent = "Mozilla 6.0";
            HttpWebResponse response = (HttpWebResponse)webrequest.GetResponse();
            Debug("creating new request/response");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Debug("invalid response code (" + response.StatusCode + ") cannot load item");
                return false;
            }

            XDocument document = XDocument.Load(response.GetResponseStream());
            var movie = document.Element("root").Element("movie");
            context["imageURL"] = movie.Attribute("poster").Value;
            context["title"] = movie.Attribute("title").Value;
            context["genre"] = movie.Attribute("genre").Value;
            context["summary"] = movie.Attribute("plot").Value;
            context["director"] = movie.Attribute("director").Value;
            context["cast"] = movie.Attribute("actors").Value;
            context["length"] = movie.Attribute("runtime").Value;
            context["rating"] = movie.Attribute("rated").Value;
            context["year"] = movie.Attribute("year").Value;

            // length rating director cast genre summary

//            ProcessExpressions(expressions, context, response.GetResponseStream());))))

            if (context["imageURL"] != null)
            {
                string imageUrl = (string)context["imageURL"];
                context["imageData"] = IOUtil.LoadUrl(imageUrl);
            }
            return true;
        }
        #endregion
        
        /// <summary>
        /// constructs the search url based on the information in the context
        /// object that we can use to effect the search
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string BuildSearchUrl(AppHelperContext context)
        {
            string extra = null;
            string year = (string)context["year"];
            if (!string.IsNullOrEmpty(year))
            {
                extra = string.Format("&y={0}", year);
            }
            string theTitle = ((string)context["title"]).Replace(" ", "+");
            return string.Format("http://www.imdbapi.com/?t={0}&r=XML{1}", theTitle, extra ?? "");
        }             
    }

}
