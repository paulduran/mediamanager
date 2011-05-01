using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Media.BC;

namespace MediaManager2
{
    public delegate void AppHelperItemSelected(IAppHelper appHelper, AppHelperItem selectedItem);

    public partial class AppHelperResultSelector : Form
    {
        private AppHelperItem[] items;

        private bool showNone = false;

        public event AppHelperItemSelected ItemSelectedEvent;

        private IAppHelper appHelper;
        public AppHelperResultSelector(IAppHelper appHelper)
        {
            InitializeComponent();
            this.appHelper = appHelper;
        }

         public AppHelperItem[] Items
        {
            get { return items; }
            set
            {
                items = value;
                rebuildItemsList();
            }
        }

        private void rebuildItemsList()
        {
            resultsPanel.Controls.Clear();
            message.Text = items.Length + " results found. Please select one";
            int x = 24;
            int y = 8;
            foreach (AppHelperItem item in items)
            {
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Location = new System.Drawing.Point(x, y);
                linkLabel.Name = item.Name;
                linkLabel.Text = item.Name;
                linkLabel.Tag = item;
                linkLabel.Size = new Size(224, 23);
                linkLabel.FlatStyle = FlatStyle.System;
                linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.appResult_LinkClicked);
                this.resultsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                linkLabel.AutoSize = true;
                resultsPanel.Controls.Add(linkLabel);
                y += 24;
            }

        }

        /// <summary>
        /// should we show a 'none' item to select if none of the items are appropriate
        /// </summary>
        public bool ShowNone
        {
            get { return showNone; }
            set { this.showNone = value; }
        }

        private void appResult_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            AppHelperItem item = (AppHelperItem)((LinkLabel)sender).Tag;
            Console.WriteLine("got a click on item: " + item.Name + " with value: " + item.Value);
            //Hide();
            Close();
            ItemSelectedEvent(appHelper, item);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}