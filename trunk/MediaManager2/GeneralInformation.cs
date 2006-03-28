using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Media.BC;
using Media.BE;

namespace MediaManager2
{
    public partial class GeneralInformation : UserControl, MediaItemBindable
    {
        private int objectId;

        public GeneralInformation()
        {
            InitializeComponent();
            image.AllowDrop = true;
        }

        public void ReadFrom(MediaItem mediaItem)
        {
            this.DataObject = mediaItem.GeneralInformation;
        }

        public void WriteTo(MediaItem mediaItem)
        {
            mediaItem.GeneralInformation = this.DataObject;
        }

        private void AssignField(object value, Control control)
        {
            if (value != null)
                control.Text = value.ToString();
            else
                control.Text = "";
        }

        private MediaGeneralInformation generalInformation;

        public MediaGeneralInformation DataObject
        {
            get
            {
                if (generalInformation == null)
                    generalInformation = new MediaGeneralInformation();

                generalInformation.Id = objectId;
                generalInformation.Cast = txtCast.Text;
                generalInformation.Country = txtCountry.Text;
                try
                {
                    int year = int.Parse(txtdate.Text);
                    generalInformation.Date = new DateTime(year, 1, 1);
                }
                catch
                {
                    // set it to this year if we dont know it
                    generalInformation.Date = new DateTime(1800, 1, 1);
                }
                
                generalInformation.Description = txtSynopsis.Text;
                generalInformation.Director = txtDirector.Text;
                generalInformation.Genre = txtGenre.Text;
                generalInformation.Length = txtLength.Text;
                generalInformation.Rating = txtRating.Text;
                generalInformation.Title = txtTitle.Text;
                
                generalInformation.Image = image.Image;

                return generalInformation;
            }
            set
            {
                this.generalInformation = value;
                this.objectId = generalInformation.Id;

                AssignField( generalInformation.Cast, txtCast );
                AssignField( generalInformation.Country, txtCountry );
                int year = generalInformation.Date.Year;
                if (year != 1800)
                    AssignField( year.ToString(), txtdate );
                else
                    AssignField( null, txtdate );

                AssignField( generalInformation.Description, txtSynopsis );
                AssignField( generalInformation.Director, txtDirector );
                AssignField( generalInformation.Genre, txtGenre );
                AssignField( generalInformation.Length, txtLength );
                AssignField( generalInformation.Rating, txtRating );
                AssignField( generalInformation.Title, txtTitle );

                image.Image = generalInformation.Image;
            }
        }

        private void image_DragDrop(object sender, DragEventArgs e)
        {
            string fileName;
            if (GetFilename(out fileName, e))
            {
                byte []someData = File.ReadAllBytes(fileName);
                System.Diagnostics.Debug.WriteLine("read data other way of length: " + someData.Length);
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                byte [] data = new byte [fs.Length];
                System.Diagnostics.Debug.WriteLine("read data of length: " + data.Length);
                fs.Read(data, 0, data.Length);
                fs.Close();
                //byte []data = File.ReadAllBytes(fileName);
                image.Image = Image.FromStream(new MemoryStream(data));
            }
          //  image.Image = data;
        }

        protected bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp") || (ext == ".gif") )
                        {                        
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Handles the DragEnter event of the image control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
        private void image_DragEnter(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("------------");
           /* foreach (string format in e.Data.GetFormats())
            {
                System.Diagnostics.Debug.WriteLine("send format requested: " + format);
            }*/
            string fileName;
            if (GetFilename(out fileName, e))
            {
                System.Diagnostics.Debug.WriteLine("Accepting drag with file: " + fileName);
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
