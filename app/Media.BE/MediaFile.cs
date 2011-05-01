using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Media.BE
{
    public enum MediaFileType
    {
        Movie = 1,
        TvEpisode = 2
    }
    public enum MediaSource
    {
        DVDRip = 1,
        PDTV = 2,
        HDTV = 3,
        DSRip = 4,
        TC = 5,
        TS = 6,
        DVDSCR = 7,
        Screener = 8,
        [Description("HR.HDTV")]
        HRHD = 9
    }
    public enum MediaCodecType
    {
        DivX = 1,
        XviD = 2,
        SVCD = 3,
        VCD = 4
    }
    public class MediaFile : MediaItem
    {
        public virtual string FileName { get; set; }

/*        private string title;

        public overridestring Title
        {
            get { return title; }
            set { title = value; }
        }
        */

        public virtual string FileProducer { get; set; }

        public virtual MediaFileType FileType { get; set; }

        public virtual MediaSource Source { get; set; }

        public virtual bool IsProper { get; set; }

        public virtual bool IsRepack { get; set; }

        #region Tv Specific Properties

        public virtual int SeasonNumber { get; set; }

        public virtual int EpisodeNumber { get; set; }

        public virtual string EpisodeTitle { get; set; }

        public virtual MediaCodecType CodecType { get; set; }

        public virtual bool HasAc3 { get; set; }

        private static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
        public virtual string Attributes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if( IsProper )
                    sb.Append(".PROPER");
                if( IsRepack )
                    sb.Append(".REPACK");
                if (Source != 0)
                {                   
                    sb.Append("." + GetDescription( Source) );
                }
                if (HasAc3)
                    sb.Append(".AC3.5.1");
                if( CodecType != 0 )
                    sb.Append("." + GetDescription( CodecType ));
                return sb.ToString();
            }
        }
        
        public override string ToString()
        {
            return FileName;
        }
        #endregion

    }
}
