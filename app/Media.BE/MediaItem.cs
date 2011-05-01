using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Media.BE
{
    public class MediaItem : IAppHelperAware
    {
        public MediaItem()
        {
            Components = new Hashtable();
            MetaData = new Dictionary<string,object>();
            Children = new ArrayList();
        }

        public virtual string Type { get; set; }

        public virtual Dictionary<string, object> MetaData { get; set; }
        /// <summary>
        /// Compatibility interface for spring as it cannot yet handle generics
        /// </summary>
        /// <value>The metadata dictionary.</value>
        public virtual IDictionary MetaDataCompat
        {
            get
            {
                return new Hashtable(MetaData);
            }
            set
            {
                MetaData = new Dictionary<string, object>();
                foreach (DictionaryEntry entry in value)
                {
                    MetaData[(string)entry.Key] = entry.Value;
                }
            }
        }

        /// <summary>
        /// Compatibility interface for spring as it cannot yet handle generics
        /// </summary>
        /// <value>The components dictionary.</value>
        public virtual IDictionary Components { get; set; }

        /// <summary>
        /// gets or sets the list of MediaItem objects that are the children of this object
        /// </summary>
        /// <value>The children.</value>
        public virtual IList Children { get; set; }

        public virtual int ParentId { get; set; }

        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual void ReadFrom(AppHelperContext context)
        {
           /* foreach (object obj in context.GetEnumerator())
            {
                if (entry.Key.StartsWith("Meta"))
                {
                    MetaData[entry.Key.ToString()] = entry.Value;
                }
            }*/
            foreach (object obj in Components.Values)
            {
                if (obj is IAppHelperAware)
                    ((IAppHelperAware)obj).ReadFrom(context);
            }
        }
    }
}
