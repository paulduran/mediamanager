using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Media.BE
{
    public class MediaGeneralInformation
    {
        private int mediaId;

        public int Id
        {
            get { return mediaId; }
            set { mediaId = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string director;

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        private string length;

        public string Length
        {
            get { return length; }
            set { length = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string rating;

        public string Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private string cast;

        public string Cast
        {
            get { return cast; }
            set { cast = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ReadFrom(AppHelperContext context)
        {
            int year = int.Parse(context["year"].ToString());
            this.Date = new DateTime(year, 1, 1);           
            this.Genre = (string)context["genre"];
            this.Description = (string)context["summary"];
            this.Title = (string)context["title"];
            this.country = (string)context["country"];
            this.Length = (string)context["length"];
            this.Rating = (string)context["rating"];
            this.Director = (string)context["director"];
            this.Cast = (string)context["cast"];

            if (context["imageURL"] != null)

            {
                System.Net.WebClient client = new System.Net.WebClient( );
                this.image = Image.FromStream(client.OpenRead(new Uri((string)context["imageURL"])));
            }
            else
                this.image = null;
        }
    }
}
