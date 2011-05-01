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
    public partial class EpisodeMaintenance : UserControl
    {
        private ISeasonHelper seasonHelper;

        public EpisodeMaintenance()
        {
            InitializeComponent();
        }

        private void EpisodeMaintenance_Load(object sender, EventArgs e)
        {
            
        }

        public MediaGeneralInformation DataObject
        {
            set
            {       
                   


                //richTextBox1.Text = value.Description;

                // CODE: test code for displaying description as html
                /*
                browser.Navigate("about:blank");
                HtmlDocument doc = browser.Document;
                // Write the HTML to the doc                
                doc.Write(value.Description);  
                */
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
