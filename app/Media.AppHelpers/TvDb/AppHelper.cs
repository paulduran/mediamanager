using System;
using System.Linq;
using System.Xml.Linq;
using Ionic.Zip;
using Media.BC;
using Media.BE;
using Media.CO;

namespace Media.AppHelpers.TvDb
{
    public class MirrorInfo
    {
        public string XmlMirror { get; set; }
        public string BannerMirror { get; set; }
        public string ZipMirror { get; set; }
    }
    public class AppHelper : IAppHelper
    {
        private readonly string apiKey;
        private MirrorInfo _mirrorInfo;
        private MirrorInfo MirrorInfo { get { if (_mirrorInfo == null) LoadMirrorInfo(); return _mirrorInfo; } set { _mirrorInfo = value; } }
        private int LastUpdate { get; set; }

        public AppHelper(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public AppHelperItem[] LocateItems(AppHelperContext context)
        {
            string url = string.Format("http://www.thetvdb.com/api/GetSeries.php?seriesname={0}",context["title"]);
            XElement results = IOUtil.LoadXml(url).Element("Data");
            return (from series in results.Elements("Series")                   
                   let title = series.Element("SeriesName").Value
                   select new SimpleAppHelperItem {Name = title, Value = series}).ToArray();
        }

        public bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            XElement series = (XElement) item.Value;
            string seriesId = series.Element("seriesid").Value;
            string language = series.Element("language").Value;
            XElement doc = GetSeriesData(seriesId, language).Element("Series");

            context["id"] = seriesId;
            context["lastUpdate"] = LastUpdate;
            context["title"] = doc.Element("SeriesName").Value;
            context["summary"] = doc.Element("Overview").Value;
            context["year"] = doc.Element("FirstAired").Value;
            context["length"] = doc.Element("Runtime").Value;
            context["genre"] = string.Join(", ", doc.Element("Genre").Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            context["cast"] = string.Join(", ", doc.Element("Actors").Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            context["rating"] = doc.Element("Rating").Value;
            string poster = doc.Element("poster").Value;                        
            if( ! string.IsNullOrEmpty(poster))
            {
                context["imageURL"] = string.Format("{0}/banners/{1}", MirrorInfo.BannerMirror, poster);
                string imageUrl = (string) context["imageURL"];
                context["imageData"] = IOUtil.LoadUrl(imageUrl);
            }
            return true;
        }

        private XElement GetSeriesData(string seriesId, string language)
        {
            string url = string.Format("{0}/api/{1}/series/{2}/all/{3}.zip", MirrorInfo.ZipMirror,
                                       apiKey, seriesId, language);           
            ZipFile zip = ZipFile.Read(IOUtil.LoadUrl(url));
            string fileName = language + ".xml";
            var zipEntry = zip[fileName];
            var stream = zipEntry.OpenReader();
            return XDocument.Load(stream).Element("Data");
        }

        private void LoadMirrorInfo()
        {
            string mirrorUrl = string.Format("http://www.thetvdb.com/api/{0}/mirrors.xml", apiKey);
            XElement mirrors = IOUtil.LoadXml(mirrorUrl).Element("Mirrors");
            var xmlMirrors =
                from m in mirrors.Elements("Mirror")
                where (Convert.ToInt32(m.Element("typemask").Value) & 1) != 0
                select m.Element("mirrorpath");
            var bannerMirrors =
                from m in mirrors.Elements("Mirror")
                where (Convert.ToInt32(m.Element("typemask").Value) & 2) != 0
                select m.Element("mirrorpath");
            var zipMirrors =
                from m in mirrors.Elements("Mirror")
                where (Convert.ToInt32(m.Element("typemask").Value) & 4) != 0
                select m.Element("mirrorpath");
            Random rand = new Random(DateTime.Now.Millisecond);
            MirrorInfo = new MirrorInfo
                             {
                                 XmlMirror = xmlMirrors.ElementAt(rand.Next(0, xmlMirrors.Count())).Value,
                                 BannerMirror = bannerMirrors.ElementAt(rand.Next(0, xmlMirrors.Count())).Value,
                                 ZipMirror = zipMirrors.ElementAt(rand.Next(0, xmlMirrors.Count())).Value
                             };
            LastUpdate = Convert.ToInt32(IOUtil.LoadXml("http://www.thetvdb.com/api/Updates.php?type=none").Element("Items").Element("Time").Value);
        }
        public string Name
        {
            get { return "TheTvDb"; }
        }
    }
}
