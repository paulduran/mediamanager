using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Web;

using Media.BC;
using Media.BE;
using Media.CO;

namespace Media.AppHelpers.EpGuides
{
    public class AppHelper : Media.BC.IAppHelper
    {
        private const string EPGUIDES_SEARCH_URL = "http://www.google.com/search?hl=en&lr=&btnG=Search&q=site%3Aepguides.com+";
        private ASCIIEncoding encoding = new ASCIIEncoding();

        public string Name
        {
            get
            {
                return "EpguidesReal";
            }
        }
        /// <summary>
        /// locates the items (ie: performs a search) using the data in the context. the context
        /// will (possibly) contain data in fields declared as inputFields in the helper contract
        /// </summary>
        public AppHelperItem[] LocateItems(AppHelperContext context)
        {
            string url = string.Format("{0}{1}", EPGUIDES_SEARCH_URL, HttpUtility.HtmlEncode((string)context["title"]));
            byte[] data = IOUtil.LoadUrl(url);
            string response = encoding.GetString(data);

            // TODO: could possibly refactor this out into a google result matcher
            Regex regex = new Regex(@"<a class=l href=""([^\""]+)""[^>]*>(.*?)\s*</a>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            List<AppHelperItem> items = new List<AppHelperItem>();
            foreach (Match m in regex.Matches(response))
            {
                string name = m.Groups[2].Value;
                name = name.Replace("<b>", "");
                name = name.Replace("</b>", "");
                if (name.Contains("(a Titles and Air Dates Guide)"))
                {
                    name = name.Replace("(a Titles and Air Dates Guide)", "");
                    items.Add(new SimpleAppHelperItem {Name = name, Value = m.Groups[1].Value});
                }
            }
            return items.ToArray();
        }

        /// <summary>
        /// loads the specified item into the context, setting values as declared as outputFields 
        /// in the helper contract (defined in the Helpers.xml file)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="listener"></param>
        /// <param name="context"></param>
        public bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            string name = item.Name;
            string url = (string)item.Value;
            //load the page to find out the url for tv.com or tvtome
            return false;
        }
    }
}
