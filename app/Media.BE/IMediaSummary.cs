using System;
using System.Collections.Generic;
using System.Text;

namespace Media.BE
{
    public interface IMediaSummary
    {
        event EventHandler SelectedItemChanged;
        MediaItem SelectedItem { get; set; }
        void Initialise(IList<MediaItem> items,string type);
        void Add(MediaItem item);
        void Replace(MediaItem old,MediaItem newItem);
        void Remove(MediaItem item);
    }
}
