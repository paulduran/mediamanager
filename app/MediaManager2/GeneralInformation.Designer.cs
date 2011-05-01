namespace MediaManager2
{
    partial class GeneralInformation
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
            this.image = new System.Windows.Forms.PictureBox();
            this.imageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectLocalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectImageURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.lblCast = new System.Windows.Forms.Label();
            this.txtCast = new System.Windows.Forms.TextBox();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.richText = new RichTextBoxSupportsXHTML.RichTextBoxSupportsXHTML();
            this.btnEditDescription = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.imageContextMenu.SuspendLayout();
            this.grpInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.image.ContextMenuStrip = this.imageContextMenu;
            this.image.Location = new System.Drawing.Point(4, 40);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(132, 164);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            this.image.DragDrop += new System.Windows.Forms.DragEventHandler(this.image_DragDrop);
            this.image.DragEnter += new System.Windows.Forms.DragEventHandler(this.image_DragEnter);
            // 
            // imageContextMenu
            // 
            this.imageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectLocalImageToolStripMenuItem,
            this.selectImageURLToolStripMenuItem});
            this.imageContextMenu.Name = "imageContextMenu";
            this.imageContextMenu.Size = new System.Drawing.Size(187, 48);
            // 
            // selectLocalImageToolStripMenuItem
            // 
            this.selectLocalImageToolStripMenuItem.Name = "selectLocalImageToolStripMenuItem";
            this.selectLocalImageToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.selectLocalImageToolStripMenuItem.Text = "Select Local Image...";
            // 
            // selectImageURLToolStripMenuItem
            // 
            this.selectImageURLToolStripMenuItem.Name = "selectImageURLToolStripMenuItem";
            this.selectImageURLToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.selectImageURLToolStripMenuItem.Text = "Enter Image URL";
            // 
            // grpInformation
            // 
            this.grpInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInformation.Controls.Add(this.txtRating);
            this.grpInformation.Controls.Add(this.txtCountry);
            this.grpInformation.Controls.Add(this.txtLength);
            this.grpInformation.Controls.Add(this.txtDirector);
            this.grpInformation.Controls.Add(this.txtdate);
            this.grpInformation.Controls.Add(this.lblRating);
            this.grpInformation.Controls.Add(this.lblCountry);
            this.grpInformation.Controls.Add(this.lblLength);
            this.grpInformation.Controls.Add(this.lblDirector);
            this.grpInformation.Controls.Add(this.lblDate);
            this.grpInformation.Location = new System.Drawing.Point(142, 40);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(223, 164);
            this.grpInformation.TabIndex = 1;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "Information";
            // 
            // txtRating
            // 
            this.txtRating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRating.Location = new System.Drawing.Point(60, 132);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(153, 20);
            this.txtRating.TabIndex = 9;
            // 
            // txtCountry
            // 
            this.txtCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountry.Location = new System.Drawing.Point(60, 103);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(153, 20);
            this.txtCountry.TabIndex = 8;
            // 
            // txtLength
            // 
            this.txtLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLength.Location = new System.Drawing.Point(60, 74);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(153, 20);
            this.txtLength.TabIndex = 7;
            // 
            // txtDirector
            // 
            this.txtDirector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirector.Location = new System.Drawing.Point(60, 45);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(153, 20);
            this.txtDirector.TabIndex = 6;
            // 
            // txtdate
            // 
            this.txtdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdate.Location = new System.Drawing.Point(60, 16);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(153, 20);
            this.txtdate.TabIndex = 5;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(5, 135);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(38, 13);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Rating";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(5, 106);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 3;
            this.lblCountry.Text = "Country";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(6, 77);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 2;
            this.lblLength.Text = "Length";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(5, 48);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(44, 13);
            this.lblDirector.TabIndex = 1;
            this.lblDirector.Text = "Director";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(3, 223);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Genre";
            // 
            // txtGenre
            // 
            this.txtGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenre.Location = new System.Drawing.Point(66, 220);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(299, 20);
            this.txtGenre.TabIndex = 3;
            // 
            // lblCast
            // 
            this.lblCast.AutoSize = true;
            this.lblCast.Location = new System.Drawing.Point(3, 252);
            this.lblCast.Name = "lblCast";
            this.lblCast.Size = new System.Drawing.Size(28, 13);
            this.lblCast.TabIndex = 4;
            this.lblCast.Text = "Cast";
            // 
            // txtCast
            // 
            this.txtCast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCast.Location = new System.Drawing.Point(66, 249);
            this.txtCast.Name = "txtCast";
            this.txtCast.Size = new System.Drawing.Size(299, 20);
            this.txtCast.TabIndex = 5;
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSynopsis.Location = new System.Drawing.Point(66, 278);
            this.txtSynopsis.Multiline = true;
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSynopsis.Size = new System.Drawing.Size(299, 84);
            this.txtSynopsis.TabIndex = 6;
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.AutoSize = true;
            this.lblSynopsis.Location = new System.Drawing.Point(3, 281);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(60, 13);
            this.lblSynopsis.TabIndex = 7;
            this.lblSynopsis.Text = "Description";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 13);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Original Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(74, 6);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(291, 20);
            this.txtTitle.TabIndex = 10;
            // 
            // richText
            // 
            this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richText.Location = new System.Drawing.Point(66, 278);
            this.richText.Name = "richText";
            this.richText.ReadOnly = true;
            this.richText.Size = new System.Drawing.Size(299, 85);
            this.richText.TabIndex = 11;
            this.richText.Text = "";
            // 
            // btnEditDescription
            // 
            this.btnEditDescription.Location = new System.Drawing.Point(9, 297);
            this.btnEditDescription.Name = "btnEditDescription";
            this.btnEditDescription.Size = new System.Drawing.Size(54, 23);
            this.btnEditDescription.TabIndex = 12;
            this.btnEditDescription.Text = "Edit";
            this.btnEditDescription.UseVisualStyleBackColor = true;
            this.btnEditDescription.Click += new System.EventHandler(this.btnEditDescription_Click);
            // 
            // GeneralInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditDescription);
            this.Controls.Add(this.richText);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.grpInformation);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.image);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.txtCast);
            this.Controls.Add(this.lblCast);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblGenre);
            this.Name = "GeneralInformation";
            this.Size = new System.Drawing.Size(368, 363);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.imageContextMenu.ResumeLayout(false);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label lblCast;
        private System.Windows.Forms.TextBox txtCast;
        private System.Windows.Forms.TextBox txtSynopsis;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.ContextMenuStrip imageContextMenu;
        private System.Windows.Forms.ToolStripMenuItem selectLocalImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectImageURLToolStripMenuItem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private RichTextBoxSupportsXHTML.RichTextBoxSupportsXHTML richText;
        private System.Windows.Forms.Button btnEditDescription;
    }
}
