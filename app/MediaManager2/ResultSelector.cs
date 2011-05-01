using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaManager2
{
    public partial class ResultSelector : Form
    {
        public delegate void ItemSelected(object selectedItem);

        public event ItemSelected ItemSelectedEvent;

        public ResultSelector()
        {
            InitializeComponent();
        }

        private IEnumerable items;
        public IEnumerable Items
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
            int x = 24;
            int y = 8;
            int numItems = 0;
            foreach (object item in items)
            {
                numItems++;
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Location = new System.Drawing.Point(x, y);
                linkLabel.Name = item.ToString();
                linkLabel.Text = item.ToString();
                linkLabel.Tag = item;
                linkLabel.Size = new Size(224, 23);
                linkLabel.FlatStyle = FlatStyle.System;
                linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.item_LinkClicked);
                this.resultsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                linkLabel.AutoSize = true;
                resultsPanel.Controls.Add(linkLabel);
                y += 24;
            }

            lblMessage.Text = numItems + " results found. Please select one";
        }

        private void item_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            object item = ((LinkLabel)sender).Tag;
//            Console.WriteLine("got a click on item: " + item.ToString() + " with value: " + item);
            //Hide();
            Close();
            if( ItemSelectedEvent != null )
                ItemSelectedEvent(item);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}