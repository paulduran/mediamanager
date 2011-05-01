using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Media.BE;
using Media.BC;
using Media.CO;

namespace Media.AppHelpers.EpGuides
{
    public class TvShowDetails : ISeasonHelper
    {
        private Uri episodeListUrl;
        private Uri imageUri;
        private string showName;
        private int durationInMinutes;
        private string duration;
        private DateTime showingTime;

        public TvShowDetails(string showName, Uri episodeListUri, Uri imageUri, string duration, DateTime showingTime)
        {
            this.showName = showName;
            this.episodeListUrl = episodeListUri;
            this.imageUri = imageUri;
            //this.durationInMinutes = durationInMinutes;
            this.durationInMinutes = 0;
            this.duration = duration;
            this.showingTime = showingTime;
        }
        public Uri EpisodeListUrl
        {
            get { return episodeListUrl; }
        }
        public Uri ImageUrl
        {
            get { return imageUri; }
        }
        public string Name
        {
            get { return showName; }
        }
        public int Duration
        {
            get { return durationInMinutes; }
        }
        public DateTime StartTime
        {
            get { return showingTime; }
        }

        public List<ISeason> GetSeasons()
        {
            Dictionary<int, ISeason> seasons = new Dictionary<int, ISeason>();

            foreach( EpisodeDetails ep in LoadAllEpisodes() )
            {
                ISeason season = seasons[ep.SeasonNumber];
                if (season == null)
                {
                    season = new Season(ep.SeasonNumber, new List<IEpisode>());
                    seasons[ep.SeasonNumber] = season;
                }
                season.Episodes.Add(ep);
            }

            List<ISeason> seasonsList = new List<ISeason>();
            seasonsList.AddRange(seasons.Values);
            return seasonsList;
        }

        private List<EpisodeDetails> LoadAllEpisodes()
        {
            byte[] data = IOUtil.LoadUrl(EpisodeListUrl.ToString());
            string allEpisodesHtml = Encoding.ASCII.GetString(data);

            List<EpisodeDetails> details = new List<EpisodeDetails>();

            Regex episodeMatcher = new Regex("<tr class=\"[ t](.*?)</tr>", RegexOptions.Singleline);
            
            foreach (Match m in episodeMatcher.Matches(allEpisodesHtml))
            {
                string episodeHtml = m.Groups[1].Value;
                //Match match = Regex.Match(episode, "<td.*?><a href=\"([^\"]+)\">([^<]+)<", RegexOptions.Singleline);
                Match match = Regex.Match(episodeHtml, "<td.*?>\\s*<a href=\"([^\"]+)\">([^<]+)<.*?/td>.*?<td[^>]*>\\s*(.*?)\\s*</td>.*?<td class=\"p-5\"[^>]*>(.*?)</td>", RegexOptions.Singleline);
                string url;
                string desc;
                string date;
                string episode;
                if (match.Success)
                {
                    url = match.Groups[1].Value;
                    desc = match.Groups[2].Value;
                    date = match.Groups[3].Value.Trim();
                    episode = match.Groups[4].Value.Trim();

                    Match descMatch = Regex.Match(desc, "^\\s+(.*)&nbsp;\\s*?", RegexOptions.Multiline);
                    if (descMatch.Success)
                        desc = descMatch.Groups[1].Value;

                    string season = null;
                    Match seasonMatch = Regex.Match(episode, "^(.+?)\\s*-\\s*(.+?)$");
                    if (seasonMatch.Success)
                    {
                        season = seasonMatch.Groups[1].Value;
                        episode = seasonMatch.Groups[2].Value;
                    }
                    System.Diagnostics.Debug.WriteLine(string.Format("Got season: {0}. episode: {1}. Title: {2}. Url: {3}. Air Date: {4}", season, episode, desc, url, date));

                    details.Add( new EpisodeDetails(this, int.Parse(season), int.Parse(episode), date, desc, new Uri(url) ) );
                }

            }

            return details;
        }

        public class Season : ISeason
        {
            private int seasonNumber;
            private List<IEpisode> episodes;
            public Season(int seasonNum, List<IEpisode> episodes)
            {
                this.seasonNumber = seasonNum;
                this.episodes = episodes;
            }

            public int SeasonNumber
            {
                get { return seasonNumber; }
            }

            public IEpisode this[int epNum]
            {
                get
                {
                    foreach( IEpisode ep in Episodes ) 
                    {
                        if (ep.EpisodeNumber == epNum)
                            return ep;
                    }
                    return null;
                }
            }
            public List<IEpisode> Episodes
            {
                get { return episodes; }
            }
        }
    }
}
