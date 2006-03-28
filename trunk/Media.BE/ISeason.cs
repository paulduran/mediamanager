using System;
using System.Collections.Generic;
using System.Text;

namespace Media.BE
{
    public interface ISeason
    {
        int SeasonNumber { get; }

        List<IEpisode> Episodes { get; }

        /// <summary>
        /// return the episode with the specified episode number within the season
        /// </summary>
        /// <param name="index">episode number</param>
        /// <returns>IEpisode object if one exists with the specified episode number
        /// or else null</returns>
        IEpisode this[int index] { get; }        

    }
}
