using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Media.BC
{
    public class SeasonHelperFactory
    {
        private IDictionary seasonHelpers = new Hashtable();

        public IDictionary SeasonHelpers
        {
            get { return seasonHelpers; }
            set { seasonHelpers = value; }
        }

        public ISeasonHelper GetSeasonHelperForUrl(string epListUrl)
        {
            foreach (ISeasonHelper helper in seasonHelpers.Values)
            {
                if (helper.CanLoadFrom(epListUrl))
                {                    
                    return helper;
                }
            }
            return null;
        }

        public ISeasonHelper GetSeasonHelper(string name)
        {
            return (ISeasonHelper)seasonHelpers[name];
        }

        public ICollection GetSeasonHelperNames()
        {
            return seasonHelpers.Keys;
        }
    }
}
