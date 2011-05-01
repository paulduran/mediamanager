using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Media.BE;
using Media.CO;

namespace Media.AppHelpers.Tv.Com
{
    public class TvSeason : Season
    {
        public virtual string SeasonUrl { get; set; }

        //private IList episodes;

        public TvSeason()
        {
        }

        public TvSeason(int seasonNum, string seasonUrl) : base(seasonNum, null)
        {
            this.SeasonUrl = seasonUrl;

            foreach (IEpisode ep in FetchEpisodes(seasonUrl))
            {
                Episodes.Add(ep);
            }
        }

        private IList FetchEpisodes(string episodesListUrl)
        {
            byte[] data = IOUtil.LoadUrl(episodesListUrl);
            string episodesHtml = Encoding.ASCII.GetString(data);

            List<IEpisode> details = new List<IEpisode>();
            Regex episodeMatcher = new Regex("(<tr[^>]*>)(.*?)</tr>", RegexOptions.Singleline);

            int episodeNum = 0;
            int errorEpisodeNum = 999;
            foreach (Match m in episodeMatcher.Matches(episodesHtml))
            {
                string episodeHtml = m.Groups[2].Value;
                //Match match = Regex.Match(episode, "<td.*?><a href=\"([^\"]+)\">([^<]+)<", RegexOptions.Singleline);
                // 1 = episode (non-numeric = specials)
                // 2 = url
                // 3 = title
                // 4 = date
                // episode number incremented manually
                Match match =
                    Regex.Match(episodeHtml,
                                "<td.*?>\\s*([^\\s]+)\\s*</td>\\s*<td.*?>\\s*<a href=\"([^\"]+)\">([^<]+)<.*?/td>.*?<td[^>]*>\\s*(.*?)\\s*</td>",
                                RegexOptions.Singleline);

                if (match.Success)
                {
                    string episodeStr = match.Groups[1].Value;
                    string url = match.Groups[2].Value;
                    string desc = match.Groups[3].Value;
                    string date = match.Groups[4].Value.Trim();
                    CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
                    try
                    {
                        DateTime usDate = DateTime.Parse(date, ci.DateTimeFormat);
                        date = usDate.ToString("yyyy-MM-dd");
                    }
                    catch (FormatException e)
                    {
                        Debug.WriteLine("Unable to process date: " + date +
                                        ". Setting to DateTime.MinValue (Error: " + e.Message + ")");
                        date = DateTime.MinValue.ToString("yyyy-MM-dd");
                    }

                    Match descMatch = Regex.Match(desc, "^\\s+(.*)&nbsp;\\s*?", RegexOptions.Multiline);
                    if (descMatch.Success)
                        desc = descMatch.Groups[1].Value;

                    int season = SeasonNumber;
                    int episode;
                    try
                    {
                        int.Parse(episodeStr);
                        episode = ++episodeNum;
                    }
                    catch (FormatException e)
                    {
                        Debug.WriteLine("Unable to process episode number: " + episodeStr +
                                        ". Setting to " + errorEpisodeNum + " (Error: " + e.Message +
                                        ")");
                        episode = errorEpisodeNum++;
                    }
                    Debug.WriteLine(
                        string.Format("Got season: {0}. episode: {1}. Title: {2}. Url: {3}. Air Date: {4}", season,
                                      episode, desc, url, date));

                    details.Add(new Episode(season, episode, date, desc, new Uri(url)));
                }
            }

            return details;
        }
    }
}