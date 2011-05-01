using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Media.BE
{
    public class Episode : MediaItem, IEpisode
    {
 /*       private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }*/

        public Episode() {
            Type = "Tv Episode";
        }

        public Episode(int seasonNum, int epnum, string date, string title, Uri detailsUri)
		{
            Type = "Tv Episode";
            this.SeasonNumber = seasonNum;
			this.EpisodeNumber = epnum;
			this.Title = title;
			/*try 
			{
				DateTime airingDate = DateTime.Parse(date).Date;
				this.airingDateTime = new DateTime(airingDate.Year, airingDate.Month, airingDate.Day, startTime.Hours, startTime.Minutes, 0, 0);
			} 
			catch { this.airingDateTime = DateTime.Now; }*/
            try
            {
                this.AiringDateTime = DateTime.Parse(date).Date;
            }
            catch( Exception e)
            {
                Console.WriteLine("error parsing date: " + date + ": " + e.Message);
                this.AiringDateTime = DateTime.Now;
            }
            this.DetailsURI = detailsUri;
			// this.duration = new TimeSpan(0,0,duration, 0, 0);
		}

        public virtual string Description { get; set; }

        public virtual Uri DetailsURI { get; set; }

        public virtual string DetailsURIString
        {
            get { if (this.DetailsURI == null) 
                    return null;
                else
                    return this.DetailsURI.ToString(); }
            set { if (string.IsNullOrEmpty(value) ) this.DetailsURI = null; 
                    else this.DetailsURI = new Uri(value); }
        }

        public virtual int EpisodeNumber { get; set; }

        public virtual int SeasonNumber { get; set; }

        public virtual DateTime AiringDateTime { get; set; }

        public virtual TimeSpan Duration { get; set; }

        public virtual MediaFile File
        {
            get {
                if (Children.Count == 0)
                    return null;
                return (MediaFile)Children[0]; 
            }
            set {
                Children.Clear();
                if( value != null )
                    Children.Add(value);
            }
        }
    }
}
