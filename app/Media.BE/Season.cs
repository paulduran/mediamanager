using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Media.BE
{
    public class Season : MediaItem, ISeason
    {
        private int seasonNumber;
        private IList episodes = new ArrayList();
        public Season() {
            Type = "Tv Season";
        }

        public Season(int seasonNumber, IList episodes)
        {
            Type = "Tv Season";
            this.SeasonNumber = seasonNumber;
            if( episodes != null )
                ((ArrayList)this.episodes).AddRange(episodes);
        }

        public override string ToString()
        {
            return "Season " + SeasonNumber;
        }

        public virtual int SeasonNumber
        {
            get { return seasonNumber; }
            set { this.seasonNumber = value; this.Title = "Season " + SeasonNumber; }
        }

        public virtual IEpisode this[int epNum]
        {
            get
            {
                foreach (IEpisode ep in Episodes)
                {
                    if (ep.EpisodeNumber == epNum)
                        return ep;
                }
                return null;
            }
        }

        public virtual IList Episodes 
        {
            get
            {
                return Children;
            }
            set {
                this.Children = value;
            }
        }
    }
}
