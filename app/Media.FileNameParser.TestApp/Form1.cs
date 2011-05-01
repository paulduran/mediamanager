using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Media.BC;
using Media.BE;

namespace Media.FileNameParser.TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(txtPath.Text);
            int attempts = 0;
            int successes = 0;

            FileInfo []files = dirinfo.GetFiles("*.avi", (chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));

            pbParseProgress.ProgressBar.Minimum = 0;
            pbParseProgress.ProgressBar.Maximum = files.Length;
            MediaFileNameParser parser = new MediaFileNameParser();
            List<MediaFile> fileInfos = new List<MediaFile>();
            foreach (FileInfo fileInfo in files )
            {
                if (fileInfo.FullName.Contains("Documentaries"))
                    continue;
                attempts++;
                lblStatus.Text = "Processing: " + fileInfo.Name;

                pbParseProgress.ProgressBar.Value = attempts;
                MediaFile actual = parser.Parse(fileInfo.FullName);
                fileInfos.Add(actual);
                if (actual.FileType == MediaFileType.TvEpisode)
                    successes++;
            }
            grdResults.DataSource = fileInfos;
            lblStatus.Text = "Attempts: " + attempts + ". Successes: " + successes + ". Failures: " + (attempts - successes) + ". Accuracy: " + ((double)successes / (double)attempts) * 100.0d;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select Folder containing media files";
            fbd.SelectedPath = "K:\tv shows";
            fbd.ShowNewFolderButton = false;
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }
    }
}