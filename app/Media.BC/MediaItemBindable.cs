using System;
using System.Collections.Generic;
using System.Text;

namespace Media.BE
{
    public interface MediaItemBindable
    {
        void ReadFrom(MediaItem mediaItem);
        void WriteTo(MediaItem mediaItem);
    }
}
