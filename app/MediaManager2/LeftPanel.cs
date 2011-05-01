using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Spring.Context.Support;
using Spring.Context;

using Media.BE;

namespace MediaManager2
{
    public partial class LeftPanel : UserControl
    {
        public LeftPanel()
        {
            InitializeComponent();

            foreach (MediaTypeProvider provider in GetProviders())
            {
                ToolStripButton button = new ToolStripButton();
                button.CheckOnClick = true;
                button.Image = Properties.Resources.ResourceManager.GetObject(provider.IconName24x24) as Bitmap;
                button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                button.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
                button.Margin = new System.Windows.Forms.Padding(0);
                button.Name = "toolStripButton" + provider.Name.Replace(' ', '_');
                button.Padding = new System.Windows.Forms.Padding(2);
                button.Size = new System.Drawing.Size(311, 32);
                button.Text = provider.Name;
                button.Tag = provider;
                button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                button.Click += new EventHandler(button_Click);
                stackStrip.Items.Add(button);
            }

            ((ToolStripButton)stackStrip.Items[0]).Checked = true;
        }

        private IList<MediaTypeProvider> GetProviders()
        {
            
            IList<MediaTypeProvider> providers = new List<MediaTypeProvider>();

            if (!DesignMode)
            {
                IApplicationContext ctx = ContextRegistry.GetContext();
                foreach (DictionaryEntry entry in ctx.GetObjectsOfType(typeof(MediaTypeProvider)))
                {
                    MediaTypeProvider provider = (MediaTypeProvider)entry.Value;
                    providers.Add(provider);
                }
            }
            return providers;
        }

        void button_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            MediaTypeProvider provider = button.Tag as MediaTypeProvider;
            titleStrip.Items[0].Text = provider.Name;
            mediaItemTree1.Initialise(items, provider.Name);
        }

        private IList<MediaItem> items;

        public void Initialise(IList<MediaItem> items)
        {
            this.items = items;
            ToolStripButton button = GetSelectedButton();
            MediaTypeProvider provider = button.Tag as MediaTypeProvider;
            titleStrip.Items[0].Text = provider.Name;
            mediaItemTree1.Initialise(items, provider.Name);
        }

        private ToolStripButton GetSelectedButton()
        {
            foreach (ToolStripItem ctrl in stackStrip.Items)
            {
                ToolStripButton but = ctrl as ToolStripButton;
                if (but == null)
                    continue;

                if (but.Checked)
                    return but;
            }
            return null;
        }

        public IMediaSummary Summary
        {
            get
            {
                return mediaItemTree1;
            }
        }
    }
}
