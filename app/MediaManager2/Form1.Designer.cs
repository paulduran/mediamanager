namespace MediaManager2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));            
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mediaTree = new System.Windows.Forms.TreeView();
            this.tcEditorPanels = new System.Windows.Forms.TabControl();
            this.tabSummary = new System.Windows.Forms.TabPage();
            this.tabEpisodes = new System.Windows.Forms.TabPage();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.btnRetrieveInformation = new System.Windows.Forms.Button();
            this.generalInformation = new MediaManager2.GeneralInformation();
            this.episodeMaintenance = new MediaManager2.EpisodeMaintenance();
            this.menuBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tcEditorPanels.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.tabEpisodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(594, 24);
            this.menuBar.TabIndex = 2;
            this.menuBar.Text = "menuBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTablesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createTablesToolStripMenuItem
            // 
            this.createTablesToolStripMenuItem.Name = "createTablesToolStripMenuItem";
            this.createTablesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createTablesToolStripMenuItem.Text = "Create Tables";
            this.createTablesToolStripMenuItem.Click += new System.EventHandler(this.createTablesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 467);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(594, 22);
            this.statusBar.TabIndex = 5;
            this.statusBar.Text = "statusBar";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(109, 17);
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSave,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnPrevious,
            this.btnNext});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(594, 25);
            this.toolBar.TabIndex = 6;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(32, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(42, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(52, 22);
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 22);
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.mediaTree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.tcEditorPanels);
            this.splitContainer.Panel2.Controls.Add(this.txtMovieName);
            this.splitContainer.Panel2.Controls.Add(this.btnRetrieveInformation);
            this.splitContainer.Size = new System.Drawing.Size(594, 418);
            this.splitContainer.SplitterDistance = 197;
            this.splitContainer.TabIndex = 7;
            // 
            // mediaTree
            // 
            this.mediaTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaTree.Location = new System.Drawing.Point(0, 0);
            this.mediaTree.Name = "mediaTree";
            this.mediaTree.Size = new System.Drawing.Size(197, 418);
            this.mediaTree.TabIndex = 1;
            this.mediaTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mediaTree_AfterSelect);
            this.mediaTree.Click += new System.EventHandler(this.mediaTree_Click);
            // 
            // tcEditorPanels
            // 
            this.tcEditorPanels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcEditorPanels.Controls.Add(this.tabSummary);
            this.tcEditorPanels.Controls.Add(this.tabEpisodes);
            this.tcEditorPanels.Location = new System.Drawing.Point(3, 33);
            this.tcEditorPanels.Name = "tcEditorPanels";
            this.tcEditorPanels.SelectedIndex = 0;
            this.tcEditorPanels.Size = new System.Drawing.Size(386, 365);
            this.tcEditorPanels.TabIndex = 6;
            // 
            // tabSummary
            // 
            this.tabSummary.Controls.Add(this.generalInformation);
            this.tabSummary.Location = new System.Drawing.Point(4, 22);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSummary.Size = new System.Drawing.Size(378, 339);
            this.tabSummary.TabIndex = 0;
            this.tabSummary.Text = "Summary";
            this.tabSummary.UseVisualStyleBackColor = true;
            // 
            // tabEpisodes
            // 
            this.tabEpisodes.Controls.Add(this.episodeMaintenance);
            this.tabEpisodes.Location = new System.Drawing.Point(4, 22);
            this.tabEpisodes.Name = "tabEpisodes";
            this.tabEpisodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabEpisodes.Size = new System.Drawing.Size(378, 339);
            this.tabEpisodes.TabIndex = 1;
            this.tabEpisodes.Text = "Episodes";
            this.tabEpisodes.UseVisualStyleBackColor = true;
            // 
            // txtMovieName
            // 
            this.txtMovieName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMovieName.Location = new System.Drawing.Point(3, 7);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(263, 20);
            this.txtMovieName.TabIndex = 3;
            this.txtMovieName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMovieName_KeyPress);
            // 
            // btnRetrieveInformation
            // 
            this.btnRetrieveInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieveInformation.Location = new System.Drawing.Point(272, 5);
            this.btnRetrieveInformation.Name = "btnRetrieveInformation";
            this.btnRetrieveInformation.Size = new System.Drawing.Size(118, 23);
            this.btnRetrieveInformation.TabIndex = 1;
            this.btnRetrieveInformation.Text = "Retrieve Information";
            this.btnRetrieveInformation.Click += new System.EventHandler(this.button1_Click);
 
            this.generalInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalInformation.Location = new System.Drawing.Point(3, 3);
            this.generalInformation.Name = "generalInformation";
            this.generalInformation.Size = new System.Drawing.Size(372, 333);
            this.generalInformation.TabIndex = 5;
            // 
            // episodeMaintenance
            // 
            this.episodeMaintenance.AutoScroll = true;
            this.episodeMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.episodeMaintenance.Location = new System.Drawing.Point(3, 3);
            this.episodeMaintenance.Name = "episodeMaintenance";
            this.episodeMaintenance.Size = new System.Drawing.Size(372, 333);
            this.episodeMaintenance.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 489);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.tcEditorPanels.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.tabEpisodes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieveInformation;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.SplitContainer splitContainer;
        private GeneralInformation generalInformation;
        private System.Windows.Forms.TreeView mediaTree;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tcEditorPanels;
        private System.Windows.Forms.TabPage tabSummary;
        private System.Windows.Forms.TabPage tabEpisodes;
        private EpisodeMaintenance episodeMaintenance;


    }
}

