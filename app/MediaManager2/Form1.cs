using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Spring.Context.Support;
using Spring.Context;

using Media.BC;
using Media.BE;
using Media.DAC;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MediaManager2
{
    public partial class Form1 : Form
    {
        private MediaStore mediaStore;
        int curIndex = 0;

        private IList<MediaItem> mediaItems;
        private IApplicationContext ctx;
        private Dictionary<string, MediaTypeProvider> providers = new Dictionary<string, MediaTypeProvider>();    
        //private Dictionary<string, Control> editors = new Dictionary<string,Control>();
        private IMediaSummary mediaTree;

        public Form1()
        {
            InitializeComponent();
            mediaTree = leftPanel1.Summary;
            mediaTree.SelectedItemChanged += new EventHandler(mediaTree_AfterSelect);

            mediaStore = new MediaStore();

            mediaItems = new List<MediaItem>();
            foreach (MediaItem item in mediaStore.GetAllMedia())
                mediaItems.Add(item);
            
            leftPanel1.Initialise(mediaItems);
 
            ctx = ContextRegistry.GetContext();
            foreach (DictionaryEntry entry in ctx.GetObjectsOfType(typeof(MediaTypeProvider)))
            {
                MediaTypeProvider provider = (MediaTypeProvider)entry.Value;
                providers[provider.Name] = provider;
                drpItemTypes.Items.Add(new ListItem(provider, provider.Name));
            }
            drpItemTypes.SelectedIndex = 0;
            UpdateDisplay();
        }

        #region Tree related

        private void mediaTree_AfterSelect(object sender, EventArgs e)
        {
            DoSelect(mediaTree.SelectedItem);
        }

        #endregion


        private Control GetEditor(string type)
        {
            if (type == null)
                return tcEditorPanels;

            Control editor;
            
            MediaTypeProvider provider = providers[type];
            if (provider == null)
            {
                throw new Exception("Provider not found for item of type: " + type);     
            }
            editor = provider.Editor;
            editor.Dock = DockStyle.Fill;
            return editor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoSearch((IAppHelper)((ListItem)drpHelpers.SelectedItem).Key);
        }

        private void DoSearch(IAppHelper helper)
        {
            statusLabel.Text = "Performing Search. Please Wait...";
            this.Cursor = Cursors.WaitCursor;
            // use an app helper to locate information
            //helper = appHelperFactory.GetAppHelper(appHelper);
            AppHelperContext context = new SimpleAppHelperContext();
            context["title"] = txtMovieName.Text;
            AppHelperItem[] items = helper.LocateItems(context);

            statusLabel.Text = null;
            this.Cursor = Cursors.Default;

            switch (items.Length)
            {
                case 0:
                    MessageBox.Show("No Match Found for: " + txtMovieName.Text);
                    break;
                case 1:
                    AppHelperItemSelected(helper, items[0]);
                    break;
                default:
                    AppHelperResultSelector resultSelector = new AppHelperResultSelector(helper);
                    resultSelector.ItemSelectedEvent += new AppHelperItemSelected(AppHelperItemSelected);
                    resultSelector.Items = items;
                    resultSelector.Show();
                    break;
            }        
        }


        private void AppHelperItemSelected(IAppHelper helper, AppHelperItem item)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("got selected item. name: {0}. value: {1}", item.Name, item.Value));
            AppHelperContext context = new SimpleAppHelperContext();
            if (helper.LoadItem(item, context))
            {
               // if (context["title"] != null)
               //     this.txtMovieName.Text = (string)context["title"];
                MediaItem.ReadFrom(context);
                UpdateDisplay();
            }
        }

        private void createTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // new CreateTables().Run();
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DoAdd();
            //AddNewItem();
        }

        /*
        private void AddNewItem()
        {
            MediaGeneralInformation info = new MediaGeneralInformation();
            generalInformation.DataObject = info;
            mediaItems.Add(info);
            int numItems = mediaItems.Count;
            curIndex = numItems - 1;
            UpdateButtonStatuses();
        }*/

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DoPrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DoNext();
        }

        private void txtMovieName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                DoSearch((IAppHelper)((ListItem)drpHelpers.SelectedItem).Key);
            }
        }

        private void DoAdd()
        {
            curIndex = mediaItems.Count;

            ListItem listItem = (ListItem)drpItemTypes.SelectedItem;
            MediaTypeProvider provider = (MediaTypeProvider)listItem.Key;
            MediaItem item = provider.CreateMediaItem();
            // MediaItem item = (MediaItem)ctx.GetObject(listItem.Key);

            //MediaItem item = new MediaItem();
            //item.GeneralInformation = new MediaGeneralInformation();
            mediaItems.Add(item);
            mediaTree.Add(item);            
            UpdateDisplay();
        }

        private MediaItem currentMediaItem;

        private MediaItem MediaItem
        {
            get
            {
              /*foreach (TabPage page in tcEditorPanels.TabPages)
                {
                    foreach (Control ctrl in page.Controls)
                    {
                        if (ctrl is MediaItemBindable)
                        {
                            ((MediaItemBindable)ctrl).WriteTo(currentMediaItem);
                        }
                    }
                }*/
                foreach (Control ctrl in editorContainer.Controls)
                {
                    if (ctrl is MediaItemBindable)
                    {
                        ((MediaItemBindable)ctrl).WriteTo(currentMediaItem);
                    }
                }
                return currentMediaItem;
            }
            set            
            {
                string oldType = ((currentMediaItem != null) ? currentMediaItem.Type : null);
                currentMediaItem = value;
                editorContainer.Controls.Clear();
                if (oldType != currentMediaItem.Type)
                {
                    drpHelpers.Items.Clear();
                    if (providers.ContainsKey(currentMediaItem.Type))
                    {
                        MediaTypeProvider provider = providers[currentMediaItem.Type];
                        foreach (IAppHelper helper in provider.AppHelpers)
                        {
                            drpHelpers.Items.Add(new ListItem(helper, helper.Name));
                        }
                    }

                    if (drpHelpers.Items.Count > 0)
                    {
                        drpHelpers.Enabled = true;
                        drpHelpers.SelectedIndex = 0;
                    }
                    else
                        drpHelpers.Enabled = false;
                }
                Control editor = GetEditor(currentMediaItem.Type);

                if (editor is MediaItemBindable)
                {
                    ((MediaItemBindable)editor).ReadFrom(value);
                }
                editorContainer.Controls.Add(editor);

                /*
                foreach (TabPage page in tcEditorPanels.TabPages)
                {
                    foreach (Control ctrl in page.Controls)
                    {
                        if (ctrl is MediaItemBindable)
                        {
                            ((MediaItemBindable)ctrl).ReadFrom(value);
                        }
                    }
                }*/
            }
        }

        private void DoSelect(object tag)
        {
            for (int i = 0; i < mediaItems.Count; i++)
            {
                if (mediaItems[i].Equals(tag))
                {
                    curIndex = i;
                    break;
                }
            }            
            UpdateDisplay();          
        }

        private void DoSave()
        {
            MediaItem item = this.MediaItem;
            //MediaGeneralInformation info = generalInformation.DataObject;
            mediaStore.Save(item);
            mediaTree.Replace(mediaTree.SelectedItem, item);
            // re-assign so that the mgi id is retained
            this.MediaItem = item;
            mediaTree.SelectedItem = item;
            UpdateButtonStatuses();
        }

        private void DoDelete()
        {
            MediaItem item = this.MediaItem;
            //MediaGeneralInformation mgi = (MediaGeneralInformation)mediaItems[curIndex];
            if( DialogResult.Yes.Equals( MessageBox.Show("deleting: " + item.Title, "Confirm Delete", MessageBoxButtons.YesNo)))
            {
                mediaStore.Delete(item);                
                mediaItems.Remove(item);
                mediaTree.Remove(item);
                
                curIndex = Math.Min(mediaItems.Count - 1, curIndex);
                UpdateDisplay();
            }
        }

        private void DoNext()
        {
            curIndex = Math.Min(this.mediaItems.Count-1, curIndex + 1);
            while (curIndex < mediaItems.Count && ((MediaItem)mediaItems[curIndex]).ParentId != 0)
                curIndex++;

            UpdateDisplay();
        }

        private void DoPrevious()
        {
            curIndex = Math.Max(0, curIndex - 1);
            while (curIndex >= 0 && ((MediaItem)mediaItems[curIndex]).ParentId != 0)
                curIndex--;

            UpdateDisplay();
        }

        private void DoFirst()
        {
            curIndex = 0;
            UpdateDisplay();
        }

        private void DoLast()
        {
            curIndex = this.mediaItems.Count - 1;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (curIndex >= mediaItems.Count)
            {
                // adding new one
                mediaTree.SelectedItem = null;
                this.MediaItem = null;
            }
            else
            {
                if (mediaItems.Count == 0)
                {
                    DoAdd();
                    return;
                }
                
                this.MediaItem = (MediaItem)mediaItems[curIndex]; 
                //MediaGeneralInformation info = (MediaGeneralInformation)mediaItems[curIndex];
                //generalInformation.DataObject = info;
                //episodeMaintenance.DataObject = info;
                mediaTree.SelectedItem = this.MediaItem;
                //treeMediaList .SelectedNode = treeMediaList.Nodes[0];
                //treeMediaList.Select();
            }
            UpdateButtonStatuses();
        }
        private void UpdateButtonStatuses()
        {
            if (curIndex == 0)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }
            if (curIndex >= (mediaItems.Count - 1))
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
            btnDelete.Enabled = (mediaTree.SelectedItem != null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DoDelete();
        }

        private class ListItem
        {
            private object key;

            public object Key
            {
                get { return key; }
                set { key = value; }
            }
            private string text;

            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            public ListItem(object key, string text)
            {
                this.key = key;
                this.text = text;
            }

            public override string ToString()
            {
                return text;
            }
        }

    }

}