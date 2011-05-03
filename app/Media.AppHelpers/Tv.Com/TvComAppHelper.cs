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

namespace Media.AppHelpers.Tv.Com
{
    public class TvComAppHelper : RegexAppHelper
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
        private const string SEARCH_SHOWRESULT_REGEX = "<a class=\"f-bold f-C30\" href=\"([^\"]+)\"[^>]*>(.*?)</a>";

        private ASCIIEncoding encoding = new ASCIIEncoding();

        List<RegexMatcher> expressions = new List<RegexMatcher>();
        public TvComAppHelper()
        {
            expressions.Add(new RegexMatcher("length", @"\((\d+ min.)\)"));
            expressions.Add(new EntireStreamRegexMatcher("genre", new Regex(@"Show Categor\w+:\s*(.*?)\s*</div", RegexOptions.Singleline), new Regex(@"<a href=[^>]+>([^<]+)</a>")));
            expressions.Add(new EntireStreamRegexMatcher("cast", new Regex(@"<h1>Cast and Crew</h1>(.*?)</table>", RegexOptions.Singleline), new Regex("<a href=\"[^\"]+\">([^<]+)</a>")));
            expressions.Add(new EntireStreamRegexMatcher("summary", new Regex("<div class=\"mt-10\">\\s*(<a .*?</a>)?(?<match>(.*?))(\\s*)</div>", RegexOptions.Singleline), null));            
            expressions.Add(new EntireStreamRegexMatcher("imageURL", new Regex("<a class=\"default-image more\".*?<img src=\"([^\"]+)\".*?</a>", RegexOptions.Singleline), null));
            //expressions.Add(new RegexMatcher("year", new Regex("Premiered:\\s*<span [^>]*>\\s*((([\\w,]+)|(\\s))+)\\s*</span>", RegexOptions.Singleline), null));
            expressions.Add(new EntireStreamRegexMatcher("year", new Regex("Premiered:\\s*<span [^>]*>\\s*([\\w,\\s]+)\\s*</span>", RegexOptions.Singleline), null));
        }
        
        /// <summary>
        /// locates the items (ie: performs a search) using the data in the context. the context
        /// will (possibly) contain data in fields declared as inputFields in the helper contract
        /// </summary>
        public override AppHelperItem[] LocateItems(AppHelperContext context)
        {
            string name = (string)context["title"];
            Uri baseUri = new Uri(SEARCH_URI);
            string url = baseUri + "?type=11&stype=program&x=0&y=0&qs=" + HttpUtility.HtmlEncode(name);
            byte[] data = IOUtil.LoadUrl(url);
            string response = encoding.GetString(data);
            return parseItems(baseUri, response);
        }

        public override string Name
        {
            get { return "TV.com"; }
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

                SimpleAppHelperItem item = new SimpleAppHelperItem { Name = showMatches[i].Groups[2].ToString(), Value = new Uri(baseUri, pathPart) };
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
            string epListUrl = Regex.Replace(uri.ToString(), "(.*)/(.*?)$", "$1/episode_listings.html");
            context["episodeListUrl"] = epListUrl;
            context["title"] = item.Name;
            context["URL"] = uri.ToString();
            byte[] data = IOUtil.LoadUrl(uri.ToString());
            string response = encoding.GetString(data);

            ProcessExpressions(expressions, context, new MemoryStream(data));

            string summary = (string)context["summary"];

            // fix up segment of html to be hopefully xhtml compliant
            summary = Regex.Replace(summary, "<br>", "<br/>", RegexOptions.IgnoreCase);
            summary = Regex.Replace(summary, "&(\\s|([^;]+\\s))", "&amp; ", RegexOptions.IgnoreCase);
            summary = Regex.Replace(summary, "([^\\r]?)\\n", "$1" + Environment.NewLine);
            //summary = Regex.Replace(summary, "<br[^>]*>", "\n", RegexOptions.IgnoreCase);
            //summary = Regex.Replace(summary, "<p>", "\n\n", RegexOptions.IgnoreCase);
            //summary = Regex.Replace(summary, "</p>", "", RegexOptions.IgnoreCase);
            context["summary"] = summary.Trim();

            Uri imageUri = (context["imageURL"] == null ? null : new Uri((string)context["imageURL"]));
          //  TvShowDetails tvd = new TvShowDetails(item.Name, new Uri(epListUrl), imageUri, (string)context["duration"], DateTime.MinValue);
          //  context["episodesAppHelper"] = tvd;
            return true;
        }
    }
}
