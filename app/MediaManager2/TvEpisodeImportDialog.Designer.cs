namespace MediaManager2
{
    partial class TvEpisodeImportDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.grdMediaItems = new System.Windows.Forms.DataGridView();
            this.mediaFileInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mediaGeneralInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeasonNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EpisodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EpisodeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdMediaItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaFileInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaGeneralInformationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "The following compatible episodes have been detected. \r\nPlease check the items yo" +
                "u wish to add";
            // 
            // grdMediaItems
            // 
            this.grdMediaItems.AllowUserToAddRows = false;
            this.grdMediaItems.AllowUserToDeleteRows = false;
            this.grdMediaItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMediaItems.AutoGenerateColumns = false;
            this.grdMediaItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMediaItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkAdd,
            this.titleDataGridViewTextBoxColumn,
            this.SeasonNumber,
            this.EpisodeNumber,
            this.EpisodeTitle,
            this.FileName});
            this.grdMediaItems.DataSource = this.mediaFileInfoBindingSource;
            this.grdMediaItems.Location = new System.Drawing.Point(12, 64);
            this.grdMediaItems.Name = "grdMediaItems";
            this.grdMediaItems.RowHeadersVisible = false;
            this.grdMediaItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMediaItems.Size = new System.Drawing.Size(568, 160);
            this.grdMediaItems.TabIndex = 1;
            this.grdMediaItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMediaItems_CellValueChanged);
            this.grdMediaItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMediaItems_CellContentClick);
            // 
            // mediaFileInfoBindingSource
            // 
            this.mediaFileInfoBindingSource.DataSource = typeof(Media.BE.MediaFile);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(424, 230);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(505, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mediaGeneralInformationBindingSource
            // 
            this.mediaGeneralInformationBindingSource.DataSource = typeof(Media.BE.MediaGeneralInformation);
            // 
            // chkAdd
            // 
            this.chkAdd.FalseValue = "false";
            this.chkAdd.HeaderText = "Add";
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.TrueValue = "true";
            this.chkAdd.Width = 30;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SeasonNumber
            // 
            this.SeasonNumber.DataPropertyName = "SeasonNumber";
            this.SeasonNumber.HeaderText = "Season";
            this.SeasonNumber.Name = "SeasonNumber";
            this.SeasonNumber.ReadOnly = true;
            this.SeasonNumber.Width = 45;
            // 
            // EpisodeNumber
            // 
            this.EpisodeNumber.DataPropertyName = "EpisodeNumber";
            this.EpisodeNumber.HeaderText = "Episode";
            this.EpisodeNumber.Name = "EpisodeNumber";
            this.EpisodeNumber.ReadOnly = true;
            this.EpisodeNumber.Width = 45;
            // 
            // EpisodeTitle
            // 
            this.EpisodeTitle.DataPropertyName = "EpisodeTitle";
            this.EpisodeTitle.HeaderText = "EpisodeTitle";
            this.EpisodeTitle.Name = "EpisodeTitle";
            this.EpisodeTitle.ReadOnly = true;
            this.EpisodeTitle.Width = 150;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 190;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 230);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(122, 17);
            this.chkSelectAll.TabIndex = 4;
            this.chkSelectAll.Text = "Select / Deselect all";
            this.chkSelectAll.ThreeState = true;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // TvEpisodeImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 266);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grdMediaItems);
            this.Controls.Add(this.label1);
            this.Name = "TvEpisodeImportDialog";
            this.Text = "Import Episodes";
            ((System.ComponentModel.ISupportInitialize)(this.grdMediaItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaFileInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaGeneralInformationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdMediaItems;
        private System.Windows.Forms.BindingSource mediaGeneralInformationBindingSource;
        private System.Windows.Forms.BindingSource mediaFileInfoBindingSource;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeasonNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EpisodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EpisodeTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}