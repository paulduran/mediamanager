using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Media.BE
{
    public class MediaGeneralInformation : IMediaItemComponent, IAppHelperAware
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string Director { get; set; }

        public virtual string Length { get; set; }

        public virtual string Country { get; set; }

        public virtual string Rating { get; set; }

        public virtual string Genre { get; set; }

        public virtual string Cast { get; set; }

        public virtual string Description { get; set; }

        public virtual Image Image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public virtual void ReadFrom(AppHelperContext context)
        {
            if( context["year"] != null ) 
            {
                try
                {
                    this.Date = DateTime.Parse(context["year"].ToString());
                }
                catch
                {
                    try
                    {
                        int year = int.Parse(context["year"].ToString());
                        this.Date = new DateTime(year, 1, 1);
                    }
                    catch
                    {

                        this.Date = DateTime.MinValue;
                    }
                }
            }
            this.Genre = (string)context["genre"];
            this.Description = (string)context["summary"];
            this.Title = (string)context["title"];
            this.Country = (string)context["country"];
            this.Length = (string)context["length"];
            this.Rating = (string)context["rating"];
            this.Director = (string)context["director"];
            this.Cast = (string)context["cast"];

            if (context["imageURL"] != null)

            {
                System.Net.WebClient client = new System.Net.WebClient( );
                this.Image = Image.FromStream(client.OpenRead(new Uri((string)context["imageURL"])));
            }
            else
                this.Image = null;
        }
    }
}
