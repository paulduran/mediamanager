using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MediaManager2
{
    class MediaTypeProvider
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Control editor;

        public Control Editor
        {
            get { return editor; }
            set { editor = value; }
        }

        private IList appHelpers;

        public IList AppHelpers
        {
            get { return appHelpers; }
            set { appHelpers = value; }
        }

        private string icon16x16;
        public string IconName16x16
        {
            get { return icon16x16; }
            set { icon16x16 = value; }
        }

        private string icon24x24;

        public string IconName24x24
        {
            get { return icon24x24; }
            set { icon24x24 = value; }
        }

        private Spring.Objects.Factory.IGenericObjectFactory mediaItemFactory;

        public Spring.Objects.Factory.IGenericObjectFactory MediaItemFactory
        {
            get { return mediaItemFactory; }
            set { mediaItemFactory = value; }
        }

        public Media.BE.MediaItem CreateMediaItem()
        {
            return (Media.BE.MediaItem)MediaItemFactory.GetObject();
        }
    }
}
