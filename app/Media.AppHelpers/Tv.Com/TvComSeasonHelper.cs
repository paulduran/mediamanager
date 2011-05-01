using System;
using System.Collections.Generic;
using System.Text;
using Media.BC;
using Media.BE;
using Media.CO;
using System.Text.RegularExpressions;
using Media.AppHelpers.Tv.Com;

namespace Media.AppHelpers.Tv.Com
{
    public class TvComSeasonHelper : ISeasonHelper
    {
        public bool CanLoadFrom(string episodeListUrl)
        {
            if (episodeListUrl != null && episodeListUrl.Contains("tv.com"))
                return true;
            return false;
        }

        public List<ISeason> GetSeasons(string episodeListUrl)
        {            
            byte[] data = IOUtil.LoadUrl(episodeListUrl);
            string allEpisodesHtml = Encoding.ASCII.GetString(data);
                     /* <div id="season-dropdown">
              <select onChange="javascript:document.location=this.value;">
                                  <option value="http://www.tv.com/americas-funniest-home-videos/show/3780/episode_listings.html?season=1">Season 1</option>
                                  <option value="http://www.tv.com/americas-funniest-home-videos/show/3780/episode_listings.html?season=2">Season 2</option>
            */
            Regex seasonsRegex = new Regex("<div id=\"season-dropdown\">(.*?)</div>", RegexOptions.Singleline);
            Match match = seasonsRegex.Match(allEpisodesHtml);
            List<ISeason> seasons = new List<ISeason>();
            if (match.Success)
            {
                Regex seasonRegex = new Regex("<option value=\"([^\"]+)\"[^>]*>Season (.*?)</option>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in seasonRegex.Matches(match.Groups[1].Value))
                {
                    int seasonNum = int.Parse(m.Groups[2].Value);
                    TvSeason season = new TvSeason(seasonNum, m.Groups[1].Value);
                    seasons.Add(season);
                }
                if (seasons.Count == 0)
                {
                    // more than likely there is only 1 season so they dont show the dropdown list... punks!
                    TvSeason season = new TvSeason(1, episodeListUrl);
                    seasons.Add(season);
                }
            }
            return seasons;
        }

        public List<ISeason> GetSeasonsOld(string episodeListUrl)
        {
            Dictionary<int, ISeason> seasons = new Dictionary<int, ISeason>();

            foreach (IEpisode ep in LoadAllEpisodes(episodeListUrl))
            {
                ISeason season;
                if( seasons.ContainsKey(ep.SeasonNumber) )
                    season = seasons[ep.SeasonNumber];
                else
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

        private List<IEpisode> LoadAllEpisodes(string episodeListUrl)
        {
            System.IO.IsolatedStorage.IsolatedStorageFile f = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();
            
            byte[] data = IOUtil.LoadUrl(episodeListUrl);
            string allEpisodesHtml = Encoding.ASCII.GetString(data);

            List<IEpisode> details = new List<IEpisode>();

            Regex episodeMatcher = new Regex("<tr class=\"[ t](.*?)</tr>", RegexOptions.Singleline);

            foreach (Match m in episodeMatcher.Matches(allEpisodesHtml))
            {
                string episodeHtml = m.Groups[1].Value;
                //Match match = Regex.Match(episode, "<td.*?><a href=\"([^\"]+)\">([^<]+)<", RegexOptions.Singleline);
                Match match = Regex.Match(episodeHtml, "<td.*?>\\s*<a href=\"([^\"]+)\">([^<]+)<.*?/td>.*?<td[^>]*>\\s*(.*?)\\s*</td>.*?<td class=\"p-5\"[^>]*>(.*?)</td>", RegexOptions.Singleline);
                if (match.Success)
                {
                    string url = match.Groups[1].Value;
                    string desc = match.Groups[2].Value;
                    string date = match.Groups[3].Value.Trim();
                    System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    try
                    {
                        DateTime usDate = DateTime.Parse(date, ci.DateTimeFormat);
                        date = usDate.ToString("yyyy-MM-dd");
                    }
                    catch (FormatException e)
                    {
                        System.Diagnostics.Debug.WriteLine("Unable to process date: " + date + ". Setting to DateTime.MinValue (Error: " + e.Message + ")");
                        date = DateTime.MinValue.ToString("yyyy-MM-dd");
                    }

                    string episode = match.Groups[4].Value.Trim();

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
                    
                    details.Add(new Episode(int.Parse(season), int.Parse(episode), date, desc, new Uri(url)));
                }

            }

            return details;
        }
    }
}
