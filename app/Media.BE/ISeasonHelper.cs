using System;
using System.Collections.Generic;
using System.Text;
using Media.BE;

namespace Media.BC
{
    public interface ISeasonHelper
    {
        List<ISeason> GetSeasons(string epListUrl);

        bool CanLoadFrom(string epListUrl);
    }

   
}
