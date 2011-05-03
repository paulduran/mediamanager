using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Xml.Linq;
using Media.BC;
using Media.BE;

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
        private List<RegexMatcher> expressions = new List<RegexMatcher>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppHelper"/> class.
        /// </summary>
        public AppHelper()
        {
            Debug("ImdbAppHelper created!");

            expressions.Add(new RegexMatcher("summary", "Plot Outline:[^>]+>([^<]+)"));
            expressions.Add(new RegexMatcher("summary", "Plot Summary:[^>]+>([^<]+)"));

            expressions.Add(new TitleYearMatcher("title", "year", @"<title>(.*)?\s+\((.*?)\)</title>"));
            expressions.Add(new RegexMatcher("imageURL", "<a name=\"poster\".*?<img [^>]*src=\"([^\"]+)\""));

            RegexMatcher castMatcher = new RegexMatcher("cast", "Cast overview.*?:(.*)", "<a href=[^>]+>(.*?)</a>");
            castMatcher.Excludes.Add("(more)");
            expressions.Add(castMatcher);

            RegexMatcher genreMatcher = new MultiLineRegexMatcher("genre", "Genre:.*", "(^.*$)", "<a href=[^>]+>(.*?)</a>");
            genreMatcher.Excludes.Add("(more)");
            expressions.Add(genreMatcher);

            expressions.Add(new MultiLineRegexMatcher("length", "Runtime:.*", "(.*)"));
            expressions.Add(new MultiLineRegexMatcher("country", "Country:.*", "<a href=[^>]+>(.*?)</a>"));
            expressions.Add(new MultiLineRegexMatcher("rating", "Certification:", "<a href=[^>]+>Australia:([^<]+)<"));
            expressions.Add(new MultiLineRegexMatcher("director", "Directed by", "<a href=[^>]+>(.*?)</a>"));

            // for matching the (result of clicking the) (more) link to get extended summary(s)
            RegexMatcher longSummaryMatcher = new RegexMatcher("summary", @"<p class=""plotpar"">([^p])+");
            // cast item match: <a href=[^>]+>(.*?)</a>
        }
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
            string url = BuildSearchURL(context);

            Debug("requesting URL: " + url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            request.AllowAutoRedirect = false;
            request.UserAgent = "Mozilla 6.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Debug("response URI: " + response.ResponseUri);
            Debug("response status code: " + response.StatusCode);
            Debug("content type: " + response.ContentType);
            AppHelperItem[] items;
            if (response.StatusCode == HttpStatusCode.Found)
            {
                // being redirected to the single match.
                ImdbAppHelperItem item = new ImdbAppHelperItem();
                item.Name = "default";
                item.Value = new Uri(response.Headers["Location"]);
                items = new AppHelperItem[] { item };
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                /// FIXME: need to parse the page and extract result URIs + titles
                Debug("no exact match. multiple results not yet supported");
                items = ProcessSearchResponse(response.ResponseUri, response.GetResponseStream());
                //items = new ImdbAppHelperItem[0];
            }
            else
            {
                // something strange happened...
                items = new ImdbAppHelperItem[0];
            }
            response.Close();
            return items;
        }

        public void doSomething()
        {
            Debug("doing something!");
        }

        private ImdbAppHelperItem[] ProcessSearchResponse(Uri baseUri, Stream stream)
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
            return new ImdbAppHelperItem[] { item };
        }
        /// <summary>
        /// Processes the search response.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        private ImdbAppHelperItem[] ProcessSearchResponseOld(Uri baseUri, Stream stream)
        {
            StreamReader sr = new StreamReader(stream);
            string line;
            List<ImdbAppHelperItem> items = new List<ImdbAppHelperItem>();
            bool getLinks = false;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("<h2>Popular"))
                {
                    getLinks = true;
                }
                else if (getLinks && line.Contains("<li>"))
                {
                    Regex regex = new Regex("<a href=\"([^\"]+)[^>]*>(.*?)</a>");
                    MatchCollection coll = regex.Matches(line.Trim());
                    for (int i = 0; i < coll.Count; i++)
                    {
                        Match match = coll[i];
                        string itemUrl = match.Groups[1].ToString();
                        string itemName = match.Groups[2].ToString();
                        Debug("found a match: {0} - {1}", itemUrl, itemName);
                        ImdbAppHelperItem item = new ImdbAppHelperItem();
                        item.Name = itemName;
                        item.Value = new Uri(baseUri, itemUrl);
                        items.Add(item);
                    }
                }
                else
                    getLinks = false;
            }
            return items.ToArray();
        }

        /// <summary>
        /// loads the specified item into the context, setting values as declared as outputFields
        /// in the helper contract (defined in the Helpers.xml file)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool LoadItemOld(AppHelperItem item, AppHelperContext context)
        {
            string url = item.Value.ToString();
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

            
            ProcessExpressions(expressions, context, response.GetResponseStream());
            
            if (context["imageURL"] != null)
            {
                string imageUrl = (string)context["imageURL"];
                context["imageData"] = LoadData(imageUrl);
            }
            return true;
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
            context["rating"] = movie.Attribute("rating").Value;
            context["year"] = movie.Attribute("year").Value;

            // length rating director cast genre summary

//            ProcessExpressions(expressions, context, response.GetResponseStream());))))

            if (context["imageURL"] != null)
            {
                string imageUrl = (string)context["imageURL"];
                context["imageData"] = LoadData(imageUrl);
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
        private static string BuildSearchURLOld(AppHelperContext context)
        {
            string extra = null;
            string year = (string)context["year"];
            if (year != null && year.Length > 0)
            {
                extra = string.Format("&from_year={0}&to_year={0}", year);
            }
            string theTitle = ((string)context["title"]).Replace(" ", "+");
            return string.Format("http://imdb.com/find?q={0};tt{1}", theTitle, extra != null ? extra : "");
        }

        /// <summary>
        /// constructs the search url based on the information in the context
        /// object that we can use to effect the search
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string BuildSearchURL(AppHelperContext context)
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

        /// <summary>
        /// reads in the data from the specified url into a byte array
        /// </summary>
        /// <param name="url">url to read data from</param>
        /// <returns>byte array of data returned from the specified url</returns>
        private static byte[] LoadData(string url)
        {
            WebClient client = new WebClient();
            Debug("opening connection to: " + url);
            Stream dataStream = client.OpenRead(url);
            Debug("reading data stream");
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = dataStream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                    {
                        dataStream.Close();
                        return ms.ToArray();
                    }
                    Debug("read: " + read + " bytes");
                    ms.Write(buffer, 0, read);
                }
            }
        }


  
        private class TitleYearMatcher : RegexMatcher
        {
            private string titleField;
            private string yearField;

            private string title;
            private string year;

            public TitleYearMatcher(string titleField, string yearField, string regexp)
                : base(titleField, regexp)
            {
                this.titleField = titleField;
                this.yearField = yearField;
            }

            protected override void ProcessMatches(MatchCollection matches)
            {
                if (matches.Count != 1)
                    throw new Exception("Expect single match for TitleYearMatcher");

                title = matches[0].Groups[1].Value.Replace("&#34;", "\"");
                year = matches[0].Groups[2].Value;
            }

            public override void AssignToContext(AppHelperContext context)
            {
                context[titleField] = title;
                context[yearField] = year;
            }

            public override string ToString()
            {
                return string.Format("{0}: {1}. {2}: {3}", titleField, title, yearField, year);
            }
        }

    }

}
