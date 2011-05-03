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
            XDocument doc = IOUtil.LoadXml(url);
            List<AppHelperItem> items = new List<AppHelperItem>();

            foreach(var showElement in doc.Element("Results").Elements("show"))
            {
                items.Add(new SimpleAppHelperItem { Name = showElement.Element("name").Value, Value = showElement.Element("showid").Value });
            }

            return items.ToArray();
        }

        public bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            string showId = (string)item.Value;
            string url = string.Format("http://services.tvrage.com/myfeeds/showinfo.php?key={0}&sid={1}", key, showId);

            XElement doc = IOUtil.LoadXml(url).Element("Showinfo");
            context["title"] = doc.Element("showname").Value;
            context["id"] = doc.Element("showid").Value;
            context["country"] = doc.Element("origin_country").Value;
            context["year"] = doc.Element("startdate").Value;
            context["length"] = doc.Element("seasons").Value + " seasons";
            context["genre"] = string.Join(", ", from e in doc.Element("genres").Elements("genre")
                                                  select e.Value);
            context["imageURL"] = doc.Element("image").Value;
            if (context["imageURL"] != null)
            {
                string imageUrl = (string)context["imageURL"];
                context["imageData"] = IOUtil.LoadUrl(imageUrl);
            }
            return true;
        }

        public string Name
        {
            get { return "TvRage"; }
        }
    }
}
