using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Media.BE
{
    public class TvSeries : MediaItem, IAppHelperAware
    {
   /*     private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
     */

        public virtual string EpisodeListUrl { get; set; }

        public virtual string SummaryUrl { get; set; }

        public override void ReadFrom(AppHelperContext context)
        {
            base.ReadFrom(context);
            SummaryUrl = (string)context["URL"];
            EpisodeListUrl = (string)context["episodeListUrl"];
        }

        public virtual IList Seasons
        {
            get { return Children; }
            set { Children = value; }
        }

        public virtual ISeason this[int seasonNum]
        {
            get { 
                foreach( ISeason season in Seasons )
                {
                    if( season.SeasonNumber == seasonNum )
                        return season;
                }
                return null;
            }
            set
            {
                ISeason seasonToRemove = this[seasonNum];
                if( seasonToRemove != null )
                    Seasons.Remove(seasonToRemove);
                Seasons.Add(value);
            }
        }
    }
}
