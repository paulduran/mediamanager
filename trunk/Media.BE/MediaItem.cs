using System;
using System.Collections.Generic;
using System.Text;

namespace Media.BE
{
    public class MediaItem
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private MediaGeneralInformation info;
        public MediaGeneralInformation GeneralInformation
        {
            get
            {

                return info;
            }
            set
            {
                this.info = value;
            }
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}
