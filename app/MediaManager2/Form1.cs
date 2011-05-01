using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Media.BC;
using Media.BE;
using Media.DAC;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MediaManager2
{
    public partial class Form1 : Form
    {
        private AppHelperFactory appHelperFactory = new AppHelperFactory(@"C:\Documents and Settings\pauld\My Documents\Visual Studio 2005\Projects\MediaManager\dotnet-Helpers.xml");
        private AppHelper helper;
        private MediaStore mediaStore;
        private List<TreeNode> treeNodeList = new List<TreeNode>();
        int curIndex = 0;

        private System.Collections.IList mediaItems;

        public Form1()
        {
            InitializeComponent();

            mediaStore = new MediaStore();           
          
            mediaItems = mediaStore.GetAllMedia();

            InitialiseTreeView();

            if (mediaItems.Count == 0)
            {
                DoAdd();
            }
            else
                UpdateDisplay();
        }

        private void InitialiseTreeView()
        {
            //TreeNode rootNode = new TreeNode();
            mediaTree.BeginUpdate();
            //mediaTree.Nodes.Add(rootNode);

            List<TreeNode> unsortedNodes = new List<TreeNode>();
            //This is list of items that still have no place in tree

            for (int i = 0; i < this.mediaItems.Count; i++)
            {
                TreeNode node = this.CreateNode(mediaItems, i);
                treeNodeList.Add( node );
                //Fill this list with all items.
                unsortedNodes.Add(node);
            }

            int startCount;

            //Iterate until list will not empty.
            while (unsortedNodes.Count > 0)
            {
                startCount = unsortedNodes.Count;

                for (int i = 0 ; i < unsortedNodes.Count ; i++ ) //  unsortedNodes.Count - 1; i >= 0; i--)
                {
                    if (this.TryAddNode(unsortedNodes[i]))
                    {
                        Console.WriteLine("added node: " + unsortedNodes[i].Text);
                        //Item found its place.
                        unsortedNodes.RemoveAt(i);
                        i--;
                    }
                }

                if (startCount == unsortedNodes.Count)
                {
                    //Throw if nothing was done, in another way this 
                    //will continuous loop.
                    throw new ApplicationException("Tree view confused when try to make your data hierarchical.");
                }
            }
            mediaTree.EndUpdate();
        }

        private TreeNode CreateNode(System.Collections.IList mediaItems, int index)
        {
            MediaItem item = (MediaItem)mediaItems[index];
            TreeNode node = new TreeNode( item.GeneralInformation.Title);
            node.Tag = item;
            return node;
        }

        private bool TryAddNode(TreeNode node)
        {
            /*if (this.IsIDNull(node.ParentID))
            {
                //If parent is null this mean that this is root node.
                this.AddNode(this.Nodes, node);                
                return true;
            }
            else
            {
                if (this.items_Identifiers.ContainsKey(node.ParentID))
                {
                    //Parent already exists in tree so we can add item to it.
                    TreeNode parentNode = 
                            this.items_Identifiers[node.ParentID] as TreeNode;
                    if (parentNode != null)
                    {
                        this.AddNode(parentNode.Nodes, node);                
                        return true;
                    }
                }
            }*/
            mediaTree.Nodes.Add(node);
            //Parent was not found at this point.
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoSearch("Amazon");
        }

        private void DoSearch(string appHelper)
        {
            statusLabel.Text = "Performing Search. Please Wait...";
            this.Cursor = Cursors.WaitCursor;
            // use an app helper to locate information
            helper = appHelperFactory.GetAppHelper(appHelper);
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
                    AppHelperItemSelected(items[0]);
                    break;
                default:
                    AppHelperResultSelector resultSelector = new AppHelperResultSelector();
                    resultSelector.ItemSelectedEvent += new AppHelperItemSelected(AppHelperItemSelected);
                    resultSelector.Items = items;
                    resultSelector.Show();
                    break;
            }        
        }


        private void AppHelperItemSelected(AppHelperItem item)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("got selected item. name: {0}. value: {1}", item.Name, item.Value));
            AppHelperContext context = new SimpleAppHelperContext();
            if (helper.LoadItem(item, context))
            {
               // if (context["title"] != null)
               //     this.txtMovieName.Text = (string)context["title"];
                MediaItem.GeneralInformation.ReadFrom(context);
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

        private void mediaTree_Click(object sender, EventArgs e)
        {
            
        }

        private void mediaTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DoSelect(mediaTree.SelectedNode.Tag);
       }

        private void txtMovieName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n' )
                DoSearch("IMDB");
        }

        private void DoAdd()
        {
            curIndex = mediaItems.Count;

            MediaItem item = new MediaItem();
            item.GeneralInformation = new MediaGeneralInformation();
            mediaItems.Add(item);
            // this.MediaItem = item;            
            TreeNode node = CreateNode(mediaItems, curIndex);
            treeNodeList.Add(node);
            mediaTree.Nodes.Add( node );
            UpdateDisplay();
        }

        private MediaItem currentMediaItem;

        private MediaItem MediaItem
        {
            get
            {
                foreach (TabPage page in tcEditorPanels.TabPages)
                {
                    foreach (Control ctrl in page.Controls)
                    {
                        if (ctrl is MediaItemBindable)
                        {
                            ((MediaItemBindable)ctrl).WriteTo(currentMediaItem);
                        }
                    }
                }
                return currentMediaItem;
            }
            set
            {
                currentMediaItem = value;
                foreach (TabPage page in tcEditorPanels.TabPages)
                {
                    foreach (Control ctrl in page.Controls)
                    {
                        if (ctrl is MediaItemBindable)
                        {
                            ((MediaItemBindable)ctrl).ReadFrom(value);
                        }
                    }
                }
            }
        }

        private void DoSelect(object tag)
        {
            for (int i = 0; i < mediaItems.Count; i++)
            {
                if (mediaItems[i].Equals(tag))
                    curIndex = i;
            }            
            UpdateDisplay();          
        }

        private void DoSave()
        {
            MediaItem item = this.MediaItem;
            //MediaGeneralInformation info = generalInformation.DataObject;
            mediaStore.Save(item);
            mediaTree.SelectedNode.Text = item.GeneralInformation.Title;
            mediaTree.SelectedNode.Tag = item;
            // re-assign so that the mgi id is retained
            this.MediaItem = item;
            UpdateButtonStatuses();
        }

        private void DoDelete()
        {
            MediaItem item = this.MediaItem;
            //MediaGeneralInformation mgi = (MediaGeneralInformation)mediaItems[curIndex];
            if( DialogResult.Yes.Equals( MessageBox.Show("deleting: " + item.GeneralInformation.Title, "Confirm Delete", MessageBoxButtons.YesNo)))
            {
                mediaStore.Delete(item);                
                mediaItems.Remove(item);
                TreeNode node = mediaTree.SelectedNode;
                if (mediaTree.SelectedNode.NextNode != null)
                    mediaTree.SelectedNode = node.NextNode;
                else
                    mediaTree.SelectedNode = node.PrevNode;
                mediaTree.Nodes.Remove(node);

                curIndex = Math.Min(mediaItems.Count - 1, curIndex);
                UpdateDisplay();
            }
        }

        private TreeNode GetNode(object tag)
        {
            foreach (TreeNode node in treeNodeList)
            {
                if (node.Tag.Equals(tag))
                    return node;
            }
            return null;
        }


        private void DoNext()
        {
            curIndex = Math.Min(this.mediaItems.Count-1, curIndex + 1);
            UpdateDisplay();
        }

        private void DoPrevious()
        {
            curIndex = Math.Max(0, curIndex - 1);
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
                mediaTree.SelectedNode = null;
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
                TreeNode node = GetNode(this.MediaItem);
                mediaTree.SelectedNode = node;
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
            btnDelete.Enabled = (mediaTree.SelectedNode != null && mediaTree.SelectedNode.Tag != null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DoDelete();
        }
    }
}