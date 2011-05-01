using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Media.BE;
using Media.BC;
using Media.CO;

namespace Media.AppHelpers.EpGuides
{
    public class EpGuidesAppHelper : RegexAppHelper
    {
        public const string SEARCH_URI = "http://www.tv.com/search.php";

        /* regular expressions that are used for determining details about a tv show */
        private const string SHOW_NAME_REGEX = "<h1>(.*?)</h1>";
        private const string IMAGE_URL_REGEX = "\\s*<img src=\"(/images/shows/[^\"]+)\"";
        private const string EPISODES_URL_REGEX = "<a href=\"([^\"]+)\".*Episode List.*</a>";
        private const string RUNNING_TIME_REGEX = "<td[^>]+>Running Time</td><td[^>]+>(.*?) min</td>";
        private const string AIRING_TIME_REGEX = "<td[^>]+>Currently Appears</td><td[^>]+>.*?\\s+(.*? [AP]M)</td>";

        /* regular expressions used in parsing search results */
        private const string SEARCH_MAINDETAILS_REGEX = "<table id=\"search-results\"[^>]*>(.*?)</table>";
        private const string SEARCH_SHOWRESULT_REGEX = "<a href=\"([^\"]+)\"[^>]*><span class=\"f-xbig\">(.*?)</span></a>";

        private ASCIIEncoding encoding = new ASCIIEncoding();

        List<RegexMatcher> expressions = new List<RegexMatcher>();
        public EpGuidesAppHelper()
        {
            expressions.Add(new RegexMatcher("length", @"\((\d+ mins)\)"));
            expressions.Add(new EntireStreamRegexMatcher("genre", new Regex(@"Show Category:\s*(.*?)\s*<br", RegexOptions.Singleline), new Regex(@"<a href=[^>]+>([^<]+)</a>")));
            expressions.Add(new EntireStreamRegexMatcher("cast", new Regex(@"Cast and Crew(.*?)</table>", RegexOptions.Singleline), new Regex("<a href=\"[^\"]+\">([^<]+)</a>")));
            expressions.Add(new EntireStreamRegexMatcher("summary", new Regex("<p class=\"mt-0 mb-0\">(.*?)<br class=\"cb\" />(\\s*)<div", RegexOptions.Singleline), null));
            expressions.Add(new EntireStreamRegexMatcher("imageURL", new Regex("<div class=\"p-5 fl ta-c mr-5\".*?<img src=\"([^\"]+)\".*?</div>", RegexOptions.Singleline), null));
            expressions.Add(new RegexMatcher("year", new Regex("Premiered ((([\\w,]+)|(\\s))+)"), null));
        }
        
        /// <summary>
        /// locates the items (ie: performs a search) using the data in the context. the context
        /// will (possibly) contain data in fields declared as inputFields in the helper contract
        /// </summary>
        public override AppHelperItem[] LocateItems(AppHelperContext context)
        {
            string name = (string)context["title"];

            Uri baseUri = new Uri(SEARCH_URI);
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(baseUri);
            httpReq.AllowAutoRedirect = false;
            httpReq.Method = "POST";
            Trace.WriteLine("sending web request");
            string postData = "type=11&stype=program&x=0&y=0&qs=" + HttpUtility.HtmlEncode(name);
            byte[] postBytes = encoding.GetBytes(postData);
            // Set the content type of the data being posted.
            httpReq.ContentType = "application/x-www-form-urlencoded";
            // Set the content length of the string being posted.
            httpReq.ContentLength = postData.Length;
            Stream requestStream = httpReq.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            Trace.WriteLine("posting data of size: " + httpReq.ContentLength);
            requestStream.Close();

            Trace.WriteLine("reading web response");
            HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
            Trace.WriteLine("response URI: " + httpRes.ResponseUri);
            Trace.WriteLine("response status code: " + httpRes.StatusCode);
            Trace.WriteLine("content type: " + httpRes.ContentType);
            Trace.WriteLine("content length: " + httpRes.ContentLength);

            if (httpRes.StatusCode == HttpStatusCode.Moved || httpRes.StatusCode == HttpStatusCode.Found)
            {
                String url = httpRes.Headers["Location"];
                Trace.WriteLine("i've been redirected to: " + url);
                AppHelperItem item = new SimpleAppHelperItem(name, new Uri(baseUri, url));
                Trace.WriteLine("got URI: " + item.Value);
                return new AppHelperItem[] { item };
            }
            Stream responseStream = httpRes.GetResponseStream();
            byte[] data = IOUtil.ReadStreamFully(responseStream);
            string response = encoding.GetString(data);
            //Trace.WriteLine("read response: " + response);
            // Close the response.
            httpRes.Close();

            return parseItems(baseUri, response);
        }

        private static AppHelperItem[] parseItems(Uri baseUri, string response)
        {
            Regex regex = new Regex(SEARCH_MAINDETAILS_REGEX, RegexOptions.Singleline);
            string mainData = getMatch(regex, response);
            Trace.WriteLine("got main data; " + mainData);
            Regex showsRegex = new Regex(SEARCH_SHOWRESULT_REGEX, RegexOptions.IgnoreCase);
            MatchCollection showMatches = showsRegex.Matches(mainData);
            List<AppHelperItem> items = new List<AppHelperItem>();

            for (int i = 0; i < showMatches.Count; i++)
            {
                string pathPart = showMatches[i].Groups[1].ToString();
                pathPart = Regex.Replace(pathPart, "([?&])(q=[^&]+)", "$1full_summary=1");

                SimpleAppHelperItem item = new SimpleAppHelperItem(showMatches[i].Groups[2].ToString(),
                    new Uri(baseUri, pathPart));
                Trace.WriteLine("got URI: " + item.Value);
                items.Add(item);
            }
            return items.ToArray();
        }

        private static string getMatch(Regex regex, string data)
        {
            return regex.Match(data).Groups[1].ToString();
        }

        /// <summary>
        /// loads the specified item into the context, setting values as declared as outputFields 
        /// in the helper contract (defined in the Helpers.xml file)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="listener"></param>
        /// <param name="context"></param>
        public override bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            Trace.WriteLine("Loading: " + item.Name + " from " + item.Value);

            Uri uri = item.Value as Uri;
            // name, duration, start time, episode list url, image url
            string epListUrl = Regex.Replace(uri.ToString(), "(.*)/(.*?)$", "$1/episode_listings.html?season=0");
            context["episodeListUrl"] = epListUrl;
            context["title"] = item.Name;
            context["URL"] = uri.ToString();
            byte[] data = IOUtil.LoadUrl(uri.ToString());
            string response = encoding.GetString(data);

            ProcessExpressions(expressions, context, new MemoryStream(data));

            string summary = (string)context["summary"];
            summary = Regex.Replace(summary, "<br[^>]*>", "\n", RegexOptions.IgnoreCase);
            summary = Regex.Replace(summary, "<p>", "\n\n", RegexOptions.IgnoreCase);
            summary = Regex.Replace(summary, "</p>", "", RegexOptions.IgnoreCase);
            context["summary"] = summary.Trim();

            Uri imageUri = (context["imageURL"] == null ? null : new Uri((string)context["imageURL"]));
            TvShowDetails tvd = new TvShowDetails(item.Name, new Uri(epListUrl), imageUri, (string)context["duration"], DateTime.MinValue);
            context["episodesAppHelper"] = tvd;
            return true;
        }
    }
}
