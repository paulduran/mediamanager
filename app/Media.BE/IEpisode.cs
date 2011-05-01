using System;
using System.Collections.Generic;
using System.Text;

namespace Media.BE
{
    public interface IEpisode
    {
        string Show
        {
            get;
        }
        string Title
        {
            get;
        }
        string Description
        {
            get;
        }
        Uri DetailsURI
        {
            get;
        }
        int EpisodeNumber
        {
            get;
        }
        int SeasonNumber
        {
            get;
        }
        DateTime AiringDateTime
        {
            get;
        }
        TimeSpan Duration
        {
            get;
        }
    }
}
