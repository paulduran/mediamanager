using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Spring.Context;
using Spring.Context.Support;

using Media.BE;

namespace MediaManager2
{
    public partial class TabbedMediaItemEditor : UserControl, Media.BE.MediaItemBindable
    {

        public TabbedMediaItemEditor()
        {
            InitializeComponent();

        }

        private IList editors;

        public IList Editors
        {
            get { return editors; }
            set
            {
                editors = value;
                tabControl.TabPages.Clear();
                foreach (object obj in value)
                {
                    if (obj is Control)
                    {
                        TabPage page = new TabPage(((Control)obj).Text);
                        ((Control)obj).Dock = DockStyle.Fill;
                        page.AutoScroll = true;
                        page.Controls.Add((Control)obj);                        
                        tabControl.TabPages.Add(page);
                    }
                }
            }
        }

        public void ReadFrom(MediaItem item)
        {
            tabControl.SelectedTab = tabControl.TabPages[0];
            foreach (object obj in editors)
            {
                if (obj is MediaItemBindable)
                    ((MediaItemBindable)obj).ReadFrom(item);
            }
        }

        public void WriteTo(MediaItem item)
        {
            foreach (object obj in editors)
            {
                if (obj is MediaItemBindable)
                    ((MediaItemBindable)obj).WriteTo(item);
            }
        }
    }
}
