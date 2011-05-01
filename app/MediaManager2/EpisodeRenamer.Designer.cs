namespace MediaManager2
{
    partial class EpisodeRenamer
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
            this.grdEpisodes = new System.Windows.Forms.DataGridView();
            this.chkRename = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.episodeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seasonNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iEpisodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRename = new System.Windows.Forms.Button();
            this.lblFileNameMask = new System.Windows.Forms.Label();
            this.drpFileMask = new System.Windows.Forms.ComboBox();
            this.lblRenameGuide = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdEpisodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEpisodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEpisodes
            // 
            this.grdEpisodes.AllowUserToAddRows = false;
            this.grdEpisodes.AllowUserToDeleteRows = false;
            this.grdEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEpisodes.AutoGenerateColumns = false;
            this.grdEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEpisodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkRename,
            this.episodeNumberDataGridViewTextBoxColumn,
            this.seasonNumberDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.fileDataGridViewTextBoxColumn});
            this.grdEpisodes.DataSource = this.iEpisodeBindingSource;
            this.grdEpisodes.Location = new System.Drawing.Point(12, 59);
            this.grdEpisodes.Name = "grdEpisodes";
            this.grdEpisodes.RowHeadersVisible = false;
            this.grdEpisodes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEpisodes.Size = new System.Drawing.Size(540, 263);
            this.grdEpisodes.TabIndex = 1;
            // 
            // chkRename
            // 
            this.chkRename.FalseValue = "0";
            this.chkRename.HeaderText = "Rename";
            this.chkRename.IndeterminateValue = "0";
            this.chkRename.Name = "chkRename";
            this.chkRename.ReadOnly = true;
            this.chkRename.TrueValue = "1";
            this.chkRename.Width = 50;
            // 
            // episodeNumberDataGridViewTextBoxColumn
            // 
            this.episodeNumberDataGridViewTextBoxColumn.DataPropertyName = "EpisodeNumber";
            this.episodeNumberDataGridViewTextBoxColumn.HeaderText = "Ep #";
            this.episodeNumberDataGridViewTextBoxColumn.Name = "episodeNumberDataGridViewTextBoxColumn";
            this.episodeNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.episodeNumberDataGridViewTextBoxColumn.Width = 50;
            // 
            // seasonNumberDataGridViewTextBoxColumn
            // 
            this.seasonNumberDataGridViewTextBoxColumn.DataPropertyName = "SeasonNumber";
            this.seasonNumberDataGridViewTextBoxColumn.HeaderText = "Season #";
            this.seasonNumberDataGridViewTextBoxColumn.Name = "seasonNumberDataGridViewTextBoxColumn";
            this.seasonNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.seasonNumberDataGridViewTextBoxColumn.Width = 50;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 150;
            // 
            // fileDataGridViewTextBoxColumn
            // 
            this.fileDataGridViewTextBoxColumn.DataPropertyName = "File";
            this.fileDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileDataGridViewTextBoxColumn.Name = "fileDataGridViewTextBoxColumn";
            this.fileDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileDataGridViewTextBoxColumn.Width = 200;
            // 
            // iEpisodeBindingSource
            // 
            this.iEpisodeBindingSource.DataSource = typeof(Media.BE.IEpisode);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.Location = new System.Drawing.Point(396, 328);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "Rename...";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lblFileNameMask
            // 
            this.lblFileNameMask.AutoSize = true;
            this.lblFileNameMask.Location = new System.Drawing.Point(12, 17);
            this.lblFileNameMask.Name = "lblFileNameMask";
            this.lblFileNameMask.Size = new System.Drawing.Size(80, 13);
            this.lblFileNameMask.TabIndex = 3;
            this.lblFileNameMask.Text = "File name mask";
            // 
            // drpFileMask
            // 
            this.drpFileMask.FormattingEnabled = true;
            this.drpFileMask.Items.AddRange(new object[] {
            "{0}.S{2:00}E{3:00}.{1}{4}-{6}.avi"});
            this.drpFileMask.Location = new System.Drawing.Point(98, 13);
            this.drpFileMask.Name = "drpFileMask";
            this.drpFileMask.Size = new System.Drawing.Size(186, 21);
            this.drpFileMask.TabIndex = 4;
            // 
            // lblRenameGuide
            // 
            this.lblRenameGuide.AutoSize = true;
            this.lblRenameGuide.Location = new System.Drawing.Point(290, 16);
            this.lblRenameGuide.Name = "lblRenameGuide";
            this.lblRenameGuide.Size = new System.Drawing.Size(90, 39);
            this.lblRenameGuide.TabIndex = 5;
            this.lblRenameGuide.Text = "{0} = series title\r\n{2} = season num\r\n{4} = attributes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "{1} = episode title\r\n{3} = episode num\r\n{5} = airing date";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 334);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(122, 17);
            this.chkSelectAll.TabIndex = 7;
            this.chkSelectAll.Text = "Select / Deselect all";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(477, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EpisodeRenamer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 363);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRenameGuide);
            this.Controls.Add(this.drpFileMask);
            this.Controls.Add(this.lblFileNameMask);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.grdEpisodes);
            this.Name = "EpisodeRenamer";
            this.Text = "EpisodeRenamer";
            ((System.ComponentModel.ISupportInitialize)(this.grdEpisodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEpisodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEpisodes;
        private System.Windows.Forms.BindingSource iEpisodeBindingSource;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Label lblFileNameMask;
        private System.Windows.Forms.Label lblRenameGuide;
        private System.Windows.Forms.ComboBox drpFileMask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkRename;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seasonNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnCancel;
    }
}