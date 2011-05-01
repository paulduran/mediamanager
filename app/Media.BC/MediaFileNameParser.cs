using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using System.IO;
using Media.BE;

namespace Media.BC
{
    public class MediaFileNameParser
    {
        private string RemoveText(string origString, string text)
        {
            return origString.Remove(origString.ToLower().IndexOf(text), text.Length);
        }
        private void ExtractAttributes(string restOfFile, MediaFile mfi)
        {
            Match m = Regex.Match(restOfFile, "(^|(?<before>(.*))\\.)(?<codec>(xvid|vcd|svcd|divx))(?<after>(.*))$", RegexOptions.IgnoreCase);
            if (m.Success )
            {
                restOfFile = m.Groups["before"].Value + m.Groups["after"].Value;
                mfi.CodecType = (MediaCodecType)Enum.Parse(typeof(MediaCodecType), m.Groups["codec"].Value, true);
                //Console.WriteLine("got the xvid part: " + m.Groups[0].Value);
                // TODO: set media type to xvid
            }
       //     else
         //       Console.WriteLine("did not get the xvid part. " + restOfFile.ToLower() + " does not contain .xvid");

           /* if (restOfFile.ToLower().Contains(".divx"))
            {
                restOfFile = RemoveText(restOfFile, ".divx");               
                // TODO: set media type to divx
                mfi.CodecType = MediaCodecType.DivX;
            }*/
            if (restOfFile.ToLower().Contains(".proper"))
            {
                restOfFile = RemoveText(restOfFile, ".proper");
                mfi.IsProper = true;
            }
            if (restOfFile.ToLower().Contains(".repack"))
            {
                restOfFile = RemoveText(restOfFile, ".repack");
                mfi.IsRepack = true;
            }
            if (restOfFile.ToLower().Contains("ac3.5.1"))
            {
                // TODO: mark it as having ac3 sound
                restOfFile = RemoveText(restOfFile, "ac3.5.1");
                mfi.HasAc3 = true;
            }            
            if (restOfFile.Contains("-"))
            {
                mfi.FileProducer = restOfFile.Substring(restOfFile.IndexOf("-") + 1);
            }
            else
                mfi.FileProducer = restOfFile;

            return;
        }
        private MediaFile ParseTvShow(string fileName)
        {
            string filePart = GetFileNameWithoutExtension(fileName);
            Dictionary<string, MediaSource> tvTypes = new Dictionary<string, MediaSource>();

            tvTypes[".HR.HDTV"] = MediaSource.HRHD;
            tvTypes[".HR-HDTV"] = MediaSource.HRHD;
            tvTypes[".HDTV"] = MediaSource.HDTV;
            tvTypes[".PDTV"] = MediaSource.PDTV;
            tvTypes[".DSRip"] = MediaSource.DSRip;
            tvTypes[".DSR"] = MediaSource.DSRip;
            tvTypes[".HRHD"] = MediaSource.HRHD;
            tvTypes[".DVDRip"] = MediaSource.DVDRip;
            tvTypes[".DVD.SCREENER"] = MediaSource.DVDSCR;
            tvTypes[".DVDSCR"] = MediaSource.DVDSCR;

            string rest;
            string file;
            foreach (string tvtype in SortKeys(tvTypes.Keys))
            {
                int index = filePart.ToLower().IndexOf(tvtype.ToLower());
                if (index != -1)
                {
                    file = filePart.Substring(0, index);
                    if (index + tvtype.Length + 1 > filePart.Length)
                        rest = "";
                    else
                        rest = filePart.Substring(index + tvtype.Length + 1);
                    // Console.WriteLine("file=" + file + ". tv type=" + tvtype + ". rest=" + rest);
                                   
                    string [] regexes = {
                        @"^(?<title>(.*?))[\. _-]+S(?<season>(\d\d))E(?<episode>(\d+))([\. _-]+(?<episodetitle>(.+)))?$",
                        @"^(?<title>(.*?))[\. _-]+(?<season>(\d\d?))(?<episode>(\d{2,}))([\. _-]+(?<episodetitle>(.+)))?$",
                        @"^(?<title>(.*?))[\. _-]+(?<season>(\d+))x(?<episode>(\d+))([\. _-]+(?<episodetitle>(.+)))?$"
                    };

                    foreach( string regexStr in regexes )
                    {
                        Regex r = new Regex(regexStr, RegexOptions.IgnoreCase);
                        Match match = r.Match(file);
                        if (match.Success)
                        {
                            MediaFile mfi = new MediaFile();
                            ExtractAttributes(rest, mfi);
                            mfi.FileType = MediaFileType.TvEpisode;
                            mfi.Title = match.Groups["title"].Value.Replace('.', ' ').Replace('_', ' ');
                            mfi.EpisodeTitle = match.Groups["episodetitle"].Value.Replace('.', ' ').Replace('_', ' ');
                            mfi.EpisodeNumber = int.Parse(match.Groups["episode"].Value);
                            mfi.SeasonNumber = int.Parse(match.Groups["season"].Value);
                            mfi.FileName = fileName;
                            mfi.Source = tvTypes[tvtype];
                            return mfi;
                        }
                    }
                }
            }

           // Console.WriteLine("2: got down to this part");

            string[] mainregexes = {
                        @"^(?<title>(.*?))[\. _-]+S(?<season>(\d\d))E(?<episode>(\d+))([\. _-]+(?<episodetitle>(.+)))?([\. _-]*(?<group>([\w\[\]]+)))?$",
                        @"^(?<title>(.*?))[\. _-]+(?<season>(\d\d?))(?<episode>(\d{2,}))([\. _-]+(?<episodetitle>(.+)))?([\. _-]*(?<group>([\w\[\]]+)))?$",
                        @"^(?<title>(.*?))[\. _-]+(?<season>(\d+))x(?<episode>(\d+))([\. _-]+(?<episodetitle>(.+)))?([\. _-]*(?<group>([\w\[\]]+)))?$"
                    };
            int counter = 0;
            foreach (string regexStr in mainregexes)
            {
                counter++;
                Regex regex = new Regex(regexStr, RegexOptions.IgnoreCase);
                Match m = regex.Match(filePart);
                // Match m = regex.Match(filePart);
                if (m.Success)
                {
                   // Console.WriteLine("2.1: got down to this part. successful regex: " + counter + ": " + regexStr);
                    string title = m.Groups["title"].Value.Replace('.', ' ').Replace('_', ' ');
                    int seasonNum = int.Parse(m.Groups["season"].Value);
                    int episodeNum = int.Parse(m.Groups["episode"].Value);
                    
                    MediaFile mfi = new MediaFile();
                    mfi.FileType = MediaFileType.TvEpisode;
                    mfi.EpisodeTitle = m.Groups["episodetitle"].Value.Replace('.', ' ').Replace('_', ' ');
                    mfi.Title = title;
                    mfi.FileName = fileName;
                    mfi.FileProducer = m.Groups["group"].Value;
                    mfi.EpisodeNumber = episodeNum;
                    mfi.SeasonNumber = seasonNum;                
                    return mfi;
                }
            }
            //Regex regex = new Regex(@"^(.*?)\.S(\d\d)E(\d+)\..*?-(.*)$", RegexOptions.IgnoreCase);

            //else 
            {
                string fileLower = filePart.ToLower();
                if (fileLower.Contains(MediaSource.DSRip.ToString().ToLower()) ||
                    fileLower.Contains(MediaSource.HDTV.ToString().ToLower()) ||
                    fileLower.Contains(MediaSource.PDTV.ToString().ToLower()))
                {
                    // it looks like a tv show...
                    Regex regex = new Regex(@"^(.*?)\.(\d\d?)(\d\d)\..*?-(.*)$", RegexOptions.IgnoreCase);
                    Match m = regex.Match(filePart);
                    if (m.Success)
                    {
                        Console.WriteLine("2.2: got down to this part");
                        MediaFile mfi = new MediaFile();
                        mfi.Title = m.Groups[1].Value.Replace('.', ' ');
                        mfi.FileProducer = m.Groups[4].Value;
                        mfi.FileName = fileName;
                        mfi.EpisodeNumber = int.Parse(m.Groups[3].Value);
                        mfi.SeasonNumber = int.Parse(m.Groups[2].Value);
                        return mfi;
                    }
                }
            }
            
            return null;
        }

        private List<string> SortKeys(IEnumerable keysList)
        {
            List<string> keys = new List<string>();
            foreach( string key in keysList) 
            {
                keys.Add(key);
            }
            keys.Sort(new Comparison<string>(this.CompareKeys));
            return keys;
        }
        private int CompareKeys(string key1, string key2)
        {
            return key2.Length.CompareTo(key1.Length);
        }

        private string GetFileNameWithoutExtension(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            string filePart = new FileInfo(fileName).Name;
            if( !string.IsNullOrEmpty( fi.Extension ) )
            {
                filePart = filePart.Substring(0, filePart.Length - fi.Extension.Length);
            }
            return filePart;
        }
        /// <summary>
        /// Parses the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public MediaFile Parse(string fileName)
        {
            // first try to parse it as a tv show
            MediaFile info = ParseTvShow(fileName);
            if (info != null)
            {
                Console.WriteLine("Got tv show: title: " + info.Title + ". Episode Name: " + info.EpisodeTitle + ". season num: " + info.SeasonNumber + ". episode num: " + info.EpisodeNumber + ". group: " + info.FileProducer);
                return info;
            }
            // movie: dot.separated.title.year.source.xvid-group
            //          group-shortmovietitle.avi
            //          group-shorttitle-cdx.avi
            string filePart = GetFileNameWithoutExtension(fileName);
            Regex regex = new Regex(@"(?<group>([^-]+))-(?<title>([^-]+))(-(?<part>(CD\d)))?", RegexOptions.IgnoreCase);
            Match m = regex.Match(filePart);
            MediaFile mfi;
            if (m.Success)
            {
                mfi = new MediaFile();
                mfi.FileProducer = m.Groups["group"].Value;
                mfi.Title = m.Groups["title"].Value;                
                string cd = "";
                if( m.Groups["part"].Success )
                    cd = m.Groups["part"].Value;

                Console.WriteLine("got match for first type. group: " + mfi.FileProducer + " title: " + mfi.Title + ". cd: " + cd);
                return mfi;
            }
            // test without regex
            //if (x)
            {
                string dir = Path.GetDirectoryName(fileName);
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                string release = dirInfo.Name;
                int groupIndex = release.LastIndexOf('-');
                mfi = new MediaFile();
                if (groupIndex != -1)
                {
                    mfi.FileProducer = release.Substring(groupIndex + 1);
                    release = release.Substring(0, groupIndex);
                }
                string[] parts = release.Split(new char[] { '.', '_' });
                if (parts.Length > 1)
                {
                    int end = parts.Length - 2;
                    if (parts.Length > 2)
                    {
                        string format = parts[parts.Length - 1];                       
                        mfi.Source = (MediaSource) Enum.Parse(typeof(MediaSource), parts[parts.Length - 2], true) ;
                        end = parts.Length - 2;
                    }
                    else
                    {
                        string format = parts[parts.Length - 1];
                    }

                    if (end > 0)
                    {
                        string[] rest = new string[end];
                        for (int i = 0; i < end; i++)
                        {
                            rest[i] = parts[i];
                        }
                        mfi.Title = string.Join(" ", rest);
                    }
                    else
                        mfi.Title = release;
                }
                else
                    mfi.Title = dirInfo.Name;

                return mfi;
            }
            return null;
        }
    }

}
