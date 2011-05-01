using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Globalization;
using Media.BC;
using Media.BE;
using Media.AppHelpers.com.amazon.soap;

namespace Media.AppHelpers
{
    /// <summary>
    /// Summary description for AmazonAppHelper.
    /// </summary>
    public class AmazonAppHelper : MarshalByRefObject, IAppHelper
    {
        private const string DEVTAG = "D70LG8D3LB8UB";
        public AmazonAppHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region AppHelper Members

        public string Name
        {
            get { return "Amazon"; }
        }
        /// <summary>
        /// locates the items (ie: performs a search) using the data in the context. the context
        /// will (possibly) contain data in fields declared as inputFields in the helper contract
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public AppHelperItem[] LocateItems(AppHelperContext context)
        {
            AmazonSearchService ss = new AmazonSearchService();
            ProductInfo info;

            if (context["barcode"] != null)
            {
                UpcRequest request = new UpcRequest();
                request.devtag = DEVTAG;
                request.mode = "dvd";
                request.type = "heavy";
                //request.upc = "786936215595";
                request.upc = (string)context["barcode"];
                info = ss.UpcSearchRequest(request);
            }
            else
            {
                KeywordRequest kr = new KeywordRequest();
                kr.devtag = DEVTAG;
                kr.mode = "dvd";
                kr.type = "heavy";
                //kr.keyword = "matrix revolutions";
                kr.keyword = (string)context["title"];                
                info = ss.KeywordSearchRequest(kr);
            }
            Console.WriteLine(info.ToString());
            Console.WriteLine("num results: {0}", info.TotalResults);
            AppHelperItem[] items = new AppHelperItem[info.Details.Length];
            for (int i = 0; i < info.Details.Length; i++)
            {
                Details details = info.Details[i];

                Trace.WriteLine("item: " + details.ProductName);
                items[i] = new AmazonAppHelperItem(details.ProductName, details);
            }
            return items;
        }

        /// <summary>
        /// loads the specified item into the context, setting values as declared as outputFields
        /// in the helper contract (defined in the Helpers.xml file)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool LoadItem(AppHelperItem item, AppHelperContext context)
        {
            Details details = (Details)item.Value;
            context["URL"] = details.Url;
            string description = details.ProductDescription;
            Trace.WriteLine("visit: " + details.ImageUrlLarge);
            string releaseDate = details.ReleaseDate;
            string trd = details.TheatricalReleaseDate;
            DateTime dt;
            try
            {
                dt = DateTime.ParseExact(trd, "yyyyMMdd", new DateTimeFormatInfo());
            }
            catch            
            {
                if (releaseDate != null)
                    dt = DateTime.Parse(releaseDate);
                else
                    dt = DateTime.MinValue;
            }

            Trace.WriteLine("releaseDate: " + releaseDate + ". TRD: " + trd + ", year: " + dt.Year);
            DumpStrings("lists", details.Lists);
            DumpStrings("accessories", details.Accessories);
            DumpStrings("directors", details.Directors);
            DumpStrings("features", details.Features);

            context["year"] = dt.Year;
            context["title"] = details.ProductName;
            context["summary"] = details.ProductDescription;
            context["imageURL"] = details.ImageUrlMedium;
            
            string []genres = new string[0];

            if (details.BrowseList != null)
            {
                genres = new string[details.BrowseList.Length];

                int i = 0;
                foreach (BrowseNode node in details.BrowseList)
                    genres[i++] = node.BrowseName;
            }
            context["genre"] = string.Join(", ", genres);
            if( details.Starring != null )
                context["cast"] = string.Join(", ", details.Starring);

            // dont think we can get country
            context["length"] = details.RunningTime;
            context["rating"] = details.MpaaRating;

            if( details.Directors != null )
                context["director"] = string.Join(", ", details.Directors);
            
            return true;
        }

        /// <summary>
        /// logs the array of item strings.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <param name="items">The items.</param>
        private void DumpStrings(string desc, string[] items)
        {
            int i = 0;
            if (items == null)
            {
                Trace.WriteLine("no " + desc + " items");
                return;
            }
            foreach (string item in items)
            {
                Trace.WriteLine(String.Format("{0} {1} - {2}", desc, i++, item));
            }
        }
        #endregion
    }

    class AmazonAppHelperItem : AppHelperItem
    {
        private String _name;
        private object _val;
        #region AppHelperItem Members
        public AmazonAppHelperItem(String name, Details details)
        {
            this._name = name;
            this._val = details;
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public object Value
        {
            get
            {
                return _val;
            }
        }

        #endregion
    }
}
