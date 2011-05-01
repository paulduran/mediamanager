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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Media.BE.MediaGeneralInformation mediaGeneralInformation2 = new Media.BE.MediaGeneralInformation();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.drpItemTypes = new System.Windows.Forms.ToolStripComboBox();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPanel1 = new MediaManager2.LeftPanel();
            this.drpHelpers = new System.Windows.Forms.ComboBox();
            this.editorContainer = new System.Windows.Forms.Panel();
            this.tcEditorPanels = new System.Windows.Forms.TabControl();
            this.tabSummary = new System.Windows.Forms.TabPage();
            this.generalInformation = new MediaManager2.GeneralInformation();
            this.tabEpisodes = new System.Windows.Forms.TabPage();
            this.episodeMaintenance = new MediaManager2.EpisodeMaintenance();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.btnRetrieveInformation = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.navigationControl1 = new MediaManager2.NavigationControl();
            this.headerStrip1 = new OLAF.Controls.HeaderStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.menuBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.editorContainer.SuspendLayout();
            this.tcEditorPanels.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.tabEpisodes.SuspendLayout();
            this.headerStrip1.SuspendLayout();
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
            this.statusBar.Location = new System.Drawing.Point(0, 646);
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
            this.drpItemTypes,
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
            // drpItemTypes
            // 
            this.drpItemTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpItemTypes.Name = "drpItemTypes";
            this.drpItemTypes.Size = new System.Drawing.Size(121, 25);
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
            this.splitContainer.Panel1.Controls.Add(this.leftPanel1);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.headerStrip1);
            this.splitContainer.Panel2.Controls.Add(this.drpHelpers);
            this.splitContainer.Panel2.Controls.Add(this.editorContainer);
            this.splitContainer.Panel2.Controls.Add(this.txtMovieName);
            this.splitContainer.Panel2.Controls.Add(this.btnRetrieveInformation);
            this.splitContainer.Size = new System.Drawing.Size(594, 597);
            this.splitContainer.SplitterDistance = 197;
            this.splitContainer.TabIndex = 7;
            // 
            // leftPanel1
            // 
            this.leftPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel1.Location = new System.Drawing.Point(3, 3);
            this.leftPanel1.Name = "leftPanel1";
            this.leftPanel1.Size = new System.Drawing.Size(194, 591);
            this.leftPanel1.TabIndex = 0;
            // 
            // drpHelpers
            // 
            this.drpHelpers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drpHelpers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpHelpers.FormattingEnabled = true;
            this.drpHelpers.Location = new System.Drawing.Point(197, 7);
            this.drpHelpers.Name = "drpHelpers";
            this.drpHelpers.Size = new System.Drawing.Size(110, 21);
            this.drpHelpers.TabIndex = 8;
            // 
            // editorContainer
            // 
            this.editorContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editorContainer.Controls.Add(this.tcEditorPanels);
            this.editorContainer.Location = new System.Drawing.Point(3, 59);
            this.editorContainer.Name = "editorContainer";
            this.editorContainer.Size = new System.Drawing.Size(387, 535);
            this.editorContainer.TabIndex = 7;
            // 
            // tcEditorPanels
            // 
            this.tcEditorPanels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcEditorPanels.Controls.Add(this.tabSummary);
            this.tcEditorPanels.Controls.Add(this.tabEpisodes);
            this.tcEditorPanels.Location = new System.Drawing.Point(0, 0);
            this.tcEditorPanels.Name = "tcEditorPanels";
            this.tcEditorPanels.SelectedIndex = 0;
            this.tcEditorPanels.Size = new System.Drawing.Size(387, 535);
            this.tcEditorPanels.TabIndex = 6;
            // 
            // tabSummary
            // 
            this.tabSummary.Controls.Add(this.generalInformation);
            this.tabSummary.Location = new System.Drawing.Point(4, 22);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSummary.Size = new System.Drawing.Size(379, 509);
            this.tabSummary.TabIndex = 0;
            this.tabSummary.Text = "Summary";
            this.tabSummary.UseVisualStyleBackColor = true;
            // 
            // generalInformation
            // 
            mediaGeneralInformation2.Cast = "";
            mediaGeneralInformation2.Country = "";
            mediaGeneralInformation2.Date = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            mediaGeneralInformation2.Description = "";
            mediaGeneralInformation2.Director = "";
            mediaGeneralInformation2.Genre = "";
            mediaGeneralInformation2.Id = 0;
            mediaGeneralInformation2.Image = null;
            mediaGeneralInformation2.Length = "";
            mediaGeneralInformation2.Rating = "";
            mediaGeneralInformation2.Title = "";
            this.generalInformation.DataObject = mediaGeneralInformation2;
            this.generalInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalInformation.Location = new System.Drawing.Point(3, 3);
            this.generalInformation.Name = "generalInformation";
            this.generalInformation.Size = new System.Drawing.Size(373, 503);
            this.generalInformation.TabIndex = 5;
            // 
            // tabEpisodes
            // 
            this.tabEpisodes.Controls.Add(this.episodeMaintenance);
            this.tabEpisodes.Location = new System.Drawing.Point(4, 22);
            this.tabEpisodes.Name = "tabEpisodes";
            this.tabEpisodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabEpisodes.Size = new System.Drawing.Size(379, 535);
            this.tabEpisodes.TabIndex = 1;
            this.tabEpisodes.Text = "Episodes";
            this.tabEpisodes.UseVisualStyleBackColor = true;
            // 
            // episodeMaintenance
            // 
            this.episodeMaintenance.AllowDrop = true;
            this.episodeMaintenance.AutoScroll = true;
            this.episodeMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.episodeMaintenance.Location = new System.Drawing.Point(3, 3);
            this.episodeMaintenance.Name = "episodeMaintenance";
            this.episodeMaintenance.SeasonHelperFactory = null;
            this.episodeMaintenance.Size = new System.Drawing.Size(373, 529);
            this.episodeMaintenance.TabIndex = 0;
            // 
            // txtMovieName
            // 
            this.txtMovieName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMovieName.Location = new System.Drawing.Point(3, 7);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(188, 20);
            this.txtMovieName.TabIndex = 3;
            this.txtMovieName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMovieName_KeyPress);
            // 
            // btnRetrieveInformation
            // 
            this.btnRetrieveInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieveInformation.Location = new System.Drawing.Point(313, 5);
            this.btnRetrieveInformation.Name = "btnRetrieveInformation";
            this.btnRetrieveInformation.Size = new System.Drawing.Size(77, 23);
            this.btnRetrieveInformation.TabIndex = 1;
            this.btnRetrieveInformation.Text = "Retrieve Info";
            this.btnRetrieveInformation.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cd16.png");
            this.imageList1.Images.SetKeyName(1, "plasma-tv16.png");
            this.imageList1.Images.SetKeyName(2, "film16.png");
            this.imageList1.Images.SetKeyName(3, "cd24.png");
            this.imageList1.Images.SetKeyName(4, "plasma-tv24.png");
            this.imageList1.Images.SetKeyName(5, "film24.png");
            this.imageList1.Images.SetKeyName(6, "Folder.bmp");
            this.imageList1.Images.SetKeyName(7, "Folder24.bmp");
            // 
            // navigationControl1
            // 
            this.navigationControl1.Location = new System.Drawing.Point(371, 0);
            this.navigationControl1.Name = "navigationControl1";
            this.navigationControl1.Size = new System.Drawing.Size(223, 26);
            this.navigationControl1.TabIndex = 8;
            // 
            // headerStrip1
            // 
            this.headerStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.headerStrip1.AutoSize = false;
            this.headerStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.headerStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.headerStrip1.ForeColor = System.Drawing.Color.Black;
            this.headerStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip1.HeaderStyle = OLAF.Controls.AreaHeaderStyle.Small;
            this.headerStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.headerStrip1.Location = new System.Drawing.Point(0, 31);
            this.headerStrip1.Name = "headerStrip1";
            this.headerStrip1.Size = new System.Drawing.Size(393, 19);
            this.headerStrip1.TabIndex = 9;
            this.headerStrip1.Text = "headerStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(89, 16);
            this.toolStripLabel1.Text = " Tv Series Details";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 668);
            this.Controls.Add(this.navigationControl1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "Form1";
            this.Text = "Media Manager";
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
            this.editorContainer.ResumeLayout(false);
            this.tcEditorPanels.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.tabEpisodes.ResumeLayout(false);
            this.headerStrip1.ResumeLayout(false);
            this.headerStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripComboBox drpItemTypes;
        private System.Windows.Forms.Panel editorContainer;
        private System.Windows.Forms.ComboBox drpHelpers;
        private NavigationControl navigationControl1;
        private System.Windows.Forms.ImageList imageList1;
        private LeftPanel leftPanel1;
        private OLAF.Controls.HeaderStrip headerStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;


    }
}

