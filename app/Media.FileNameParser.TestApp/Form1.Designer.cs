namespace Media.FileNameParser.TestApp
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblDirName = new System.Windows.Forms.Label();
            this.grdResults = new System.Windows.Forms.DataGridView();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblMediaType = new System.Windows.Forms.Label();
            this.drpMediaType = new System.Windows.Forms.ComboBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbParseProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.mediaFileInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seasonNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.episodeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.episodeTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRepackDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isProperDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaFileInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(291, 51);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblDirName
            // 
            this.lblDirName.AutoSize = true;
            this.lblDirName.Location = new System.Drawing.Point(12, 36);
            this.lblDirName.Name = "lblDirName";
            this.lblDirName.Size = new System.Drawing.Size(191, 13);
            this.lblDirName.TabIndex = 1;
            this.lblDirName.Text = "Select Directory Containing Media Files";
            // 
            // grdResults
            // 
            this.grdResults.AllowUserToAddRows = false;
            this.grdResults.AllowUserToDeleteRows = false;
            this.grdResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResults.AutoGenerateColumns = false;
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileTypeDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.seasonNumberDataGridViewTextBoxColumn,
            this.episodeNumberDataGridViewTextBoxColumn,
            this.episodeTitleDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn,
            this.sourceDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.isRepackDataGridViewCheckBoxColumn,
            this.isProperDataGridViewCheckBoxColumn});
            this.grdResults.DataSource = this.mediaFileInfoBindingSource;
            this.grdResults.Location = new System.Drawing.Point(12, 104);
            this.grdResults.Name = "grdResults";
            this.grdResults.ReadOnly = true;
            this.grdResults.Size = new System.Drawing.Size(635, 137);
            this.grdResults.TabIndex = 2;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 54);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(270, 20);
            this.txtPath.TabIndex = 3;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(253, 13);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(174, 24);
            this.lblHeading.TabIndex = 4;
            this.lblHeading.Text = "Media File Parser";
            // 
            // lblMediaType
            // 
            this.lblMediaType.AutoSize = true;
            this.lblMediaType.Location = new System.Drawing.Point(15, 81);
            this.lblMediaType.Name = "lblMediaType";
            this.lblMediaType.Size = new System.Drawing.Size(59, 13);
            this.lblMediaType.TabIndex = 5;
            this.lblMediaType.Text = "Media type";
            // 
            // drpMediaType
            // 
            this.drpMediaType.FormattingEnabled = true;
            this.drpMediaType.Items.AddRange(new object[] {
            "Tv Show",
            "Movie",
            "All"});
            this.drpMediaType.Location = new System.Drawing.Point(81, 77);
            this.drpMediaType.Name = "drpMediaType";
            this.drpMediaType.Size = new System.Drawing.Size(121, 21);
            this.drpMediaType.TabIndex = 6;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(222, 81);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(74, 17);
            this.chkRecursive.TabIndex = 8;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(562, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbParseProgress,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 244);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(659, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // pbParseProgress
            // 
            this.pbParseProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbParseProgress.Margin = new System.Windows.Forms.Padding(1, 3, 10, 3);
            this.pbParseProgress.Name = "pbParseProgress";
            this.pbParseProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // mediaFileInfoBindingSource
            // 
            this.mediaFileInfoBindingSource.DataSource = typeof(Media.BE.MediaFile);
            // 
            // fileTypeDataGridViewTextBoxColumn
            // 
            this.fileTypeDataGridViewTextBoxColumn.DataPropertyName = "FileType";
            this.fileTypeDataGridViewTextBoxColumn.HeaderText = "FileType";
            this.fileTypeDataGridViewTextBoxColumn.Name = "fileTypeDataGridViewTextBoxColumn";
            this.fileTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seasonNumberDataGridViewTextBoxColumn
            // 
            this.seasonNumberDataGridViewTextBoxColumn.DataPropertyName = "SeasonNumber";
            this.seasonNumberDataGridViewTextBoxColumn.HeaderText = "SeasonNumber";
            this.seasonNumberDataGridViewTextBoxColumn.Name = "seasonNumberDataGridViewTextBoxColumn";
            this.seasonNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // episodeNumberDataGridViewTextBoxColumn
            // 
            this.episodeNumberDataGridViewTextBoxColumn.DataPropertyName = "EpisodeNumber";
            this.episodeNumberDataGridViewTextBoxColumn.HeaderText = "EpisodeNumber";
            this.episodeNumberDataGridViewTextBoxColumn.Name = "episodeNumberDataGridViewTextBoxColumn";
            this.episodeNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // episodeTitleDataGridViewTextBoxColumn
            // 
            this.episodeTitleDataGridViewTextBoxColumn.DataPropertyName = "EpisodeTitle";
            this.episodeTitleDataGridViewTextBoxColumn.HeaderText = "EpisodeTitle";
            this.episodeTitleDataGridViewTextBoxColumn.Name = "episodeTitleDataGridViewTextBoxColumn";
            this.episodeTitleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Group";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            this.groupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            this.sourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isRepackDataGridViewCheckBoxColumn
            // 
            this.isRepackDataGridViewCheckBoxColumn.DataPropertyName = "IsRepack";
            this.isRepackDataGridViewCheckBoxColumn.HeaderText = "IsRepack";
            this.isRepackDataGridViewCheckBoxColumn.Name = "isRepackDataGridViewCheckBoxColumn";
            this.isRepackDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // isProperDataGridViewCheckBoxColumn
            // 
            this.isProperDataGridViewCheckBoxColumn.DataPropertyName = "IsProper";
            this.isProperDataGridViewCheckBoxColumn.HeaderText = "IsProper";
            this.isProperDataGridViewCheckBoxColumn.Name = "isProperDataGridViewCheckBoxColumn";
            this.isProperDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 266);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.drpMediaType);
            this.Controls.Add(this.lblMediaType);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.grdResults);
            this.Controls.Add(this.lblDirName);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.Text = "Media File Parser";
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaFileInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblDirName;
        private System.Windows.Forms.DataGridView grdResults;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblMediaType;
        private System.Windows.Forms.ComboBox drpMediaType;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pbParseProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seasonNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isRepackDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isProperDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource mediaFileInfoBindingSource;
    }
}

