using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using Media.BE;

namespace MediaManager2
{
    public partial class EpisodeRenamer : Form
    {
        private string title;


        public EpisodeRenamer()
        {
            InitializeComponent();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            List<MediaFile> oldFiles = new List<MediaFile>();
            List<string> newNames = new List<string>();
            StringBuilder msg = new StringBuilder();
            string mask = drpFileMask.Text;
            if (string.IsNullOrEmpty(mask) )
            {
                MessageBox.Show("Please select a file mask first: " + drpFileMask.SelectedText);
                return;
            }
            msg.Append("The Following Files will be renamed\n\n");
            foreach (DataGridViewRow row in grdEpisodes.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cell.Value == cell.TrueValue)
                {
                    IEpisode ep = (IEpisode)row.DataBoundItem;

                    string newFileName = GetNewFileName(mask, title, ep, true);
                    string oldFilename = ep.File.FileName;
                    if( string.IsNullOrEmpty(Path.GetDirectoryName(newFileName) ) )
                    {
                        newFileName = Path.Combine(Path.GetDirectoryName(oldFilename), newFileName);
                    }
                    newNames.Add(newFileName);
                    oldFiles.Add(ep.File);
                    msg.Append(oldFilename + " will be renamed to " + newFileName + "\n");
                }
            }
            if (oldFiles.Count > 0 && DialogResult.OK == MessageBox.Show(msg.ToString(), "Confirm Rename", MessageBoxButtons.OKCancel))
            {
                for (int i = 0; i < oldFiles.Count; i++)
                {
                    File.Move(oldFiles[i].FileName, newNames[i]);
                    oldFiles[i].FileName = newNames[i];
                }
                Close();
            }            
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        public List<IEpisode> Episodes
        {
            set
            {
                grdEpisodes.DataSource = value;
                foreach (DataGridViewRow row in grdEpisodes.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                    IEpisode ep = (IEpisode)row.DataBoundItem;
                    if (ep.File == null || string.IsNullOrEmpty(ep.File.FileName))
                    {
                        cell.Value = cell.IndeterminateValue;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        cell.Value = cell.TrueValue;
                        cell.ReadOnly = false;                       
                    }
                }
            }
        }

        private string ReplaceSpaces(string replacement, string inStr)
        {
            string str = inStr.Replace(" ", replacement);
            // replace illegal characters
            str = Regex.Replace(str, @"[\?\[\]/\\=\+\<\>\:\;]", "");
            // clean up any other uglyness
            str = str.Replace("," + replacement, replacement);
            if (str.EndsWith(replacement))
                str = str.Substring(0, str.Length - 1);
            return str;
        }
        private string GetNewFileName(string mask, string showTitle, IEpisode ep, bool replaceSpaces)
        {
            string formatString = mask.Replace("%T", "{0}");
            formatString = formatString.Replace("%E", "{1}");
            formatString = formatString.Replace("%s", "{2}");
            formatString = formatString.Replace("%e", "{3}");
            formatString = formatString.Replace("%a", "{4}");
            formatString = formatString.Replace("%d", "{5}");
            formatString = formatString.Replace("%g", "{6}");
            string fileShowTitle = showTitle;
            if (replaceSpaces)
            {
                fileShowTitle = ReplaceSpaces(".",fileShowTitle);                
            }
            string fileEpTitle = ep.Title;
            if (replaceSpaces)
            {
                fileEpTitle = ReplaceSpaces(".", fileEpTitle);
            }

            return string.Format(formatString, fileShowTitle, fileEpTitle, ep.SeasonNumber, ep.EpisodeNumber, ep.File.Attributes, ep.AiringDateTime, ep.File.FileProducer);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SetAllChecked(chkSelectAll.Checked);
        }

        private void SetAllChecked(bool isChecked)
        {
            foreach (DataGridViewRow row in grdEpisodes.Rows)
            {
                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells[0];                
                DataGridViewTextBoxCell tc = (DataGridViewTextBoxCell)row.Cells[4];
                if( isChecked && tc.Value != null && ! string.IsNullOrEmpty(((MediaFile)tc.Value).FileName) )
                    cb.Value = cb.TrueValue;
                else
                    cb.Value = cb.FalseValue;
            }
        }
    }
}