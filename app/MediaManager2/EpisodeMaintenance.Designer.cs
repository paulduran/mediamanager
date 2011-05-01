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
            this.lblSeasonMaintenance = new System.Windows.Forms.Label();
            this.lstSeasons = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grdEpisodes = new System.Windows.Forms.DataGridView();
            this.episodeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.episodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediaFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbRename = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdEpisodes)).BeginInit();
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
            this.lstSeasons.Size = new System.Drawing.Size(387, 95);
            this.lstSeasons.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(399, 25);
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
            this.btnDelete.Location = new System.Drawing.Point(399, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // grdEpisodes
            // 
            this.grdEpisodes.AllowDrop = true;
            this.grdEpisodes.AllowUserToAddRows = false;
            this.grdEpisodes.AllowUserToDeleteRows = false;
            this.grdEpisodes.AllowUserToResizeRows = false;
            this.grdEpisodes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEpisodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.episodeNum,
            this.episodeName,
            this.mediaFile,
            this.cbRename});
            this.grdEpisodes.Location = new System.Drawing.Point(0, 126);
            this.grdEpisodes.Name = "grdEpisodes";
            this.grdEpisodes.ReadOnly = true;
            this.grdEpisodes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdEpisodes.RowHeadersVisible = false;
            this.grdEpisodes.Size = new System.Drawing.Size(461, 126);
            this.grdEpisodes.TabIndex = 4;
            // 
            // episodeNum
            // 
            this.episodeNum.HeaderText = "Ep #";
            this.episodeNum.Name = "episodeNum";
            this.episodeNum.ReadOnly = true;
            this.episodeNum.Width = 45;
            // 
            // episodeName
            // 
            this.episodeName.HeaderText = "Episode Name";
            this.episodeName.Name = "episodeName";
            this.episodeName.ReadOnly = true;
            this.episodeName.Width = 140;
            // 
            // mediaFile
            // 
            this.mediaFile.HeaderText = "Media File";
            this.mediaFile.Name = "mediaFile";
            this.mediaFile.ReadOnly = true;
            this.mediaFile.Width = 200;
            // 
            // cbRename
            // 
            this.cbRename.HeaderText = "Rename";
            this.cbRename.Name = "cbRename";
            this.cbRename.ReadOnly = true;
            this.cbRename.Width = 60;
            // 
            // EpisodeMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdEpisodes);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstSeasons);
            this.Controls.Add(this.lblSeasonMaintenance);
            this.Name = "EpisodeMaintenance";
            this.Size = new System.Drawing.Size(461, 381);
            this.Load += new System.EventHandler(this.EpisodeMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEpisodes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeasonMaintenance;
        private System.Windows.Forms.ListBox lstSeasons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView grdEpisodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mediaFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbRename;
    }
}
