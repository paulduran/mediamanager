using System;
using System.Collections.Generic;
using System.Text;

using Media.BE;

namespace Media.AppHelpers.EpGuides
{
    public class EpisodeDetails : IEpisode
    {
        public EpisodeDetails( TvShowDetails showDetails, int seasonNum, int epnum, string date, string title, Uri detailsUri)
		{
			this.show = showDetails.Name;
            this.seasonNumber = seasonNum;
			this.episodeNumber = epnum;
			this.title = title;
			try 
			{
				DateTime airingDate = DateTime.Parse(date).Date;
				this.airingDateTime = new DateTime(airingDate.Year, airingDate.Month, airingDate.Day, showDetails.StartTime.Hour, showDetails.StartTime.Minute, 0, 0);
			} 
			catch { this.airingDateTime = DateTime.Now; }
            this.detailsURI = detailsUri;
			this.duration = new TimeSpan(0,0,showDetails.Duration, 0, 0);
		}

		DateTime airingDateTime;
        int seasonNumber;
		int episodeNumber;
		string title;
		string show;
		Uri detailsURI;
		TimeSpan duration;

		public override string ToString()
		{
			return episodeNumber + " - " + title + " - " + airingDateTime.ToShortDateString() + " - " + detailsURI;
		}
		public string Show
		{
			get { return show; }
		}
		public Uri DetailsURI
		{
			get { return detailsURI; }
		}
		public int EpisodeNumber
		{
			get { return episodeNumber; }
		}
        public int SeasonNumber
        {
            get { return seasonNumber; }
        }
		public string Title
		{
			get { return title; }
		}
		public DateTime AiringDateTime
		{
			get { return airingDateTime; }
		}
		public TimeSpan Duration
		{
			get { return duration; }
		}
        public string Description
        {
            get { return Description; }
        }
		public string GetStartDateTime()
		{
			return formatDateTime(AiringDateTime);
		}
		public string GetEndDateTime()
		{
			DateTime endDate = AiringDateTime.Add(Duration);
			return formatDateTime(endDate);
		}
		private string formatDateTime(DateTime dateTime)
		{
			return dateTime.ToString("yyyyMMddTHHmmss");
		}
    }

}
