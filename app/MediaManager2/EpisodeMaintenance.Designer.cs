namespace MediaManager2
{
    partial class EpisodeMaintenance
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSeasonMaintenance = new System.Windows.Forms.Label();
            this.lstSeasons = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grdEpisodes = new System.Windows.Forms.DataGridView();
            this.episodeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.episodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediaFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airingDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iEpisodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.episodeDetails = new MediaManager2.EpisodeDetails();
            this.episodeDetails1 = new MediaManager2.EpisodeDetails();
            this.btnRename = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdEpisodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEpisodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSeasonMaintenance
            // 
            this.lblSeasonMaintenance.AutoSize = true;
            this.lblSeasonMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeasonMaintenance.Location = new System.Drawing.Point(3, 0);
            this.lblSeasonMaintenance.Name = "lblSeasonMaintenance";
            this.lblSeasonMaintenance.Size = new System.Drawing.Size(165, 18);
            this.lblSeasonMaintenance.TabIndex = 0;
            this.lblSeasonMaintenance.Text = "Season Maintenance";
            // 
            // lstSeasons
            // 
            this.lstSeasons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSeasons.FormattingEnabled = true;
            this.lstSeasons.Location = new System.Drawing.Point(6, 25);
            this.lstSeasons.Name = "lstSeasons";
            this.lstSeasons.Size = new System.Drawing.Size(105, 95);
            this.lstSeasons.TabIndex = 1;
            this.lstSeasons.Click += new System.EventHandler(this.lstSeasons_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(117, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(117, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdEpisodes
            // 
            this.grdEpisodes.AllowDrop = true;
            this.grdEpisodes.AllowUserToAddRows = false;
            this.grdEpisodes.AllowUserToDeleteRows = false;
            this.grdEpisodes.AllowUserToResizeRows = false;
            this.grdEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEpisodes.AutoGenerateColumns = false;
            this.grdEpisodes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEpisodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.episodeNum,
            this.episodeName,
            this.mediaFile,
            this.airingDateTimeDataGridViewTextBoxColumn});
            this.grdEpisodes.DataSource = this.iEpisodeBindingSource;
            this.grdEpisodes.Location = new System.Drawing.Point(0, 126);
            this.grdEpisodes.Name = "grdEpisodes";
            this.grdEpisodes.ReadOnly = true;
            this.grdEpisodes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdEpisodes.RowHeadersVisible = false;
            this.grdEpisodes.Size = new System.Drawing.Size(397, 140);
            this.grdEpisodes.TabIndex = 4;
            this.grdEpisodes.CurrentCellChanged += new System.EventHandler(this.grdEpisodes_CurrentCellChanged);
            // 
            // episodeNum
            // 
            this.episodeNum.DataPropertyName = "EpisodeNumber";
            this.episodeNum.HeaderText = "Ep #";
            this.episodeNum.Name = "episodeNum";
            this.episodeNum.ReadOnly = true;
            this.episodeNum.Width = 55;
            // 
            // episodeName
            // 
            this.episodeName.DataPropertyName = "Title";
            this.episodeName.HeaderText = "Episode Name";
            this.episodeName.Name = "episodeName";
            this.episodeName.ReadOnly = true;
            this.episodeName.Width = 140;
            // 
            // mediaFile
            // 
            this.mediaFile.DataPropertyName = "File";
            this.mediaFile.HeaderText = "Media File";
            this.mediaFile.Name = "mediaFile";
            this.mediaFile.ReadOnly = true;
            this.mediaFile.Width = 200;
            // 
            // airingDateTimeDataGridViewTextBoxColumn
            // 
            this.airingDateTimeDataGridViewTextBoxColumn.DataPropertyName = "AiringDateTime";
            this.airingDateTimeDataGridViewTextBoxColumn.HeaderText = "Air Date";
            this.airingDateTimeDataGridViewTextBoxColumn.Name = "airingDateTimeDataGridViewTextBoxColumn";
            this.airingDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.airingDateTimeDataGridViewTextBoxColumn.ToolTipText = "Date the episode first went to air";
            // 
            // iEpisodeBindingSource
            // 
            this.iEpisodeBindingSource.DataSource = typeof(Media.BE.IEpisode);
            // 
            // episodeDetails
            // 
            this.episodeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.episodeDetails.Episode = null;
            this.episodeDetails.Location = new System.Drawing.Point(0, 273);
            this.episodeDetails.Name = "episodeDetails";
            this.episodeDetails.Size = new System.Drawing.Size(397, 201);
            this.episodeDetails.TabIndex = 5;
            // 
            // episodeDetails1
            // 
            this.episodeDetails1.Episode = null;
            this.episodeDetails1.Location = new System.Drawing.Point(0, 273);
            this.episodeDetails1.Name = "episodeDetails1";
            this.episodeDetails1.Size = new System.Drawing.Size(364, 201);
            this.episodeDetails1.TabIndex = 5;
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.Location = new System.Drawing.Point(179, 25);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(110, 23);
            this.btnRename.TabIndex = 6;
            this.btnRename.Text = "Rename Episodes...";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // EpisodeMaintenance
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.episodeDetails);
            this.Controls.Add(this.grdEpisodes);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstSeasons);
            this.Controls.Add(this.lblSeasonMaintenance);
            this.Name = "EpisodeMaintenance";
            this.Size = new System.Drawing.Size(403, 478);
            this.Load += new System.EventHandler(this.EpisodeMaintenance_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.EpisodeMaintenance_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EpisodeMaintenance_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.grdEpisodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEpisodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeasonMaintenance;
        private System.Windows.Forms.ListBox lstSeasons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView grdEpisodes;
        private System.Windows.Forms.BindingSource iEpisodeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mediaFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn airingDateTimeDataGridViewTextBoxColumn;
        private EpisodeDetails episodeDetails;
        private EpisodeDetails episodeDetails1;
        private System.Windows.Forms.Button btnRename;
    }
}
