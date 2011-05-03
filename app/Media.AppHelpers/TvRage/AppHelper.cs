using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Media.BE;
using Media.BC;
using Media.CO;

namespace Media.AppHelpers.TvRage
{
    public class AppHelper : IAppHelper
    {
        private readonly string key;

        public AppHelper(string key)
        {
            this.key = key;
        }

        public AppHelperItem[] LocateItems(AppHelperContext context)
        {
            string url = string.Format("http://services.tvrage.com/myfeeds/search.php?key={0}&show={1}", key, context["title"]);

            var request = WebRequest.Create(url);
            request.Proxy = WebRequest.GetSystemWebProxy();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            XDocument doc = XDocument.Load(response.GetResponseStream());
            List<AppHelperItem> items = new List<AppHelperItem>();

            foreach(var showElement in doc.Element("Results").Elements("show"))
            {
                items.Add(new SimpleAppHelperItem { Name = showElement.Element("name").Value, Value = showElement });
            }

            return items.ToArray();
        }

        public bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            XElement doc = (XElement)item.Value;
            context["title"] = doc.Element("name").Value;
            context["id"] = doc.Element("showid").Value;
            context["country"] = doc.Element("name").Value;
            context["year"] = doc.Element("started").Value;
            context["length"] = doc.Element("seasons").Value + " seasons";
            context["genres"] = string.Join(", ", from e in doc.Element("genres").Elements("genre")
                                                  select e.Value);
            return true;
        }

        public string Name
        {
            get { return "TvRage"; }
        }
    }
}
