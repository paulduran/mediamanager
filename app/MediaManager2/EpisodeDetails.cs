using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Media.BE;
using Media.BC;

namespace MediaManager2
{
    public partial class EpisodeDetails : UserControl
    {
        private const string TV_FILE_FILTER = "Media Files|*.mpg;*.avi;*.wma;*.mov;|All Files|*.*";
        public EpisodeDetails()
        {
            InitializeComponent();

            for (int i = 1; i <= 30; i++)
            {
                drpEpisodeNumber.Items.Add(i);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = txtFileName.Text;
            ofd.Filter = TV_FILE_FILTER;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
            }
        }

        private Episode episode;

        public Episode Episode
        {
            get {
                if (episode == null)
                    return null;

                episode.Description = txtDescription.Text;
                if (string.IsNullOrEmpty(txtFileName.Text))
                    episode.File = null;
                else
                {
                    MediaFileNameParser mfp = new MediaFileNameParser();
                    MediaFile mf = mfp.Parse(txtFileName.Text);
                    mf.FileProducer = txtGroup.Text;
                    episode.File = mf;
                }
                episode.SeasonNumber = int.Parse(txtSeasonNumber.Text);
                episode.Title = txtTitle.Text;
                episode.DetailsURIString = txtUrl.Text;
                if (drpEpisodeNumber.SelectedItem != null)
                    episode.EpisodeNumber = (int)drpEpisodeNumber.SelectedItem;
                else
                    episode.EpisodeNumber = 0;
                episode.AiringDateTime = dtDateAired.Value;
                return episode; 
            }
            set { 
                episode = value;
                if (episode != null)
                {
                    txtDescription.Text = episode.Description;
                    if (episode.File != null)
                    {
                        txtFileName.Text = episode.File.FileName;
                        txtGroup.Text = episode.File.FileProducer;
                    }
                    else
                        txtFileName.Text = null;
                    txtSeasonNumber.Text = episode.SeasonNumber.ToString();
                    txtTitle.Text = episode.Title;
                    txtUrl.Text = episode.DetailsURIString;
                    drpEpisodeNumber.SelectedItem = episode.EpisodeNumber;
                    dtDateAired.Value = episode.AiringDateTime;
                }
                else
                {
                    txtDescription.Text = null;
                    txtFileName.Text = null;
                    txtSeasonNumber.Text = null;
                    txtTitle.Text = null;
                    txtUrl.Text = null;
                    drpEpisodeNumber.SelectedItem = null;
                    dtDateAired.ResetText();
                }
            }
        }
 
    }
}
