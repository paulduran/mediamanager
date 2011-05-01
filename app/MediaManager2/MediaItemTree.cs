using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Media.BE;
using Media.BC;

namespace MediaManager2
{
    public partial class MediaItemTree : UserControl, IMediaSummary
    {
    
        public event EventHandler SelectedItemChanged;

        private Dictionary<MediaItem, TreeNode> treeNodes = new Dictionary<MediaItem, TreeNode>();

        public MediaItemTree()
        {
            InitializeComponent();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaItemTree));
            tree.AfterSelect += new TreeViewEventHandler(tree_AfterSelect);
        }

        public MediaItem SelectedItem
        {
            get
            {
                if (tree.SelectedNode == null)
                    return null;
                return (MediaItem)tree.SelectedNode.Tag;
            }
            set
            {
                tree.SelectedNode = GetTreeNode(value);
            }
        }

        private TreeNode GetTreeNode(MediaItem tag)
        {
            if (tag == null)
                return null;
            TreeNode node;
            treeNodes.TryGetValue(tag, out node);
            return node;
        }

        public void Initialise(IList<MediaItem> items, string type)
        {
            tree.BeginUpdate();

            tree.Nodes.Clear();
            treeNodes.Clear();

             foreach (MediaItem item in items)
            {
                if (item.Type != type)
                    continue;
                AddNode(item, tree.Nodes);
            }

            tree.EndUpdate();
        }

        public void Add(MediaItem item)
        {
            // this.MediaItem = item;            
            AddNode(item, tree.Nodes);
        }

        public void Replace(MediaItem oldItem, MediaItem newItem)
        {
            TreeNode oldNode = GetTreeNode(oldItem);
            int index = oldNode.Index;
            tree.Nodes.Remove(oldNode);
            TreeNode newNode = CreateNode(newItem);            
            tree.Nodes.Insert(index, newNode);
            foreach (MediaItem child in newItem.Children)
            {
                AddNode(child, newNode.Nodes);
            }
        }

        public void Remove(MediaItem item)
        {
            TreeNode node = GetTreeNode(item);
            if (node.NextNode != null)
                tree.SelectedNode = node.NextNode;
            else
                tree.SelectedNode = node.PrevNode;
            tree.Nodes.Remove(node);
            treeNodes.Remove(item);
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(sender, e);
        }

        private void AddNode(MediaItem item, TreeNodeCollection container)
        {
           // mediaItems.Add(item);

            // FIXME: do this in a more generic manner. dont want
            // to display individual files in the tree view
            if (item is MediaFile)
                return;

            TreeNode node = CreateNode(item);
            container.Add(node);
            foreach (MediaItem child in item.Children)
            {
                AddNode(child, node.Nodes);
            }
        }

        private TreeNode CreateNode(MediaItem item)
        {
            TreeNode node = new TreeNode(item.Title);
            switch (item.Type)
            {
                case "Tv Series":
                    node.ImageKey = "plasma-tv.png";
                    node.SelectedImageKey = "plasma-tv.png";
                    break;
                case "Movie":
                    node.ImageKey = "film.png";
                    node.SelectedImageKey = "film.png";
                    break;
                case "Tv Season":
                    node.ImageKey = "folder.bmp";
                    node.SelectedImageKey = "Folder.bmp";
                    break;
                default:
                    node.ImageKey = null;
                    node.SelectedImageKey = null;
                    break;
            }
            node.Tag = item;
            treeNodes[item] = node;
            return node;
        }
    }
}
