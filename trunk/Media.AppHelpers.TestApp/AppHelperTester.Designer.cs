namespace Media.AppHelpers.TestApp
{
    partial class AppHelperTester
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
            this.tblOutputContext = new System.Windows.Forms.TableLayoutPanel();
            this.tblInputContext = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.drpHelperNames = new System.Windows.Forms.ComboBox();
            this.drpResults = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tblOutputContext
            // 
            this.tblOutputContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblOutputContext.AutoScroll = true;
            this.tblOutputContext.AutoSize = true;
            this.tblOutputContext.ColumnCount = 2;
            this.tblOutputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblOutputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblOutputContext.Location = new System.Drawing.Point(10, 162);
            this.tblOutputContext.Margin = new System.Windows.Forms.Padding(1);
            this.tblOutputContext.Name = "tblOutputContext";
            this.tblOutputContext.RowCount = 2;
            this.tblOutputContext.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblOutputContext.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblOutputContext.Size = new System.Drawing.Size(359, 100);
            this.tblOutputContext.TabIndex = 0;
            // 
            // tblInputContext
            // 
            this.tblInputContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblInputContext.AutoSize = true;
            this.tblInputContext.ColumnCount = 2;
            this.tblInputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInputContext.Location = new System.Drawing.Point(10, 39);
            this.tblInputContext.Margin = new System.Windows.Forms.Padding(1);
            this.tblInputContext.Name = "tblInputContext";
            this.tblInputContext.RowCount = 2;
            this.tblInputContext.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInputContext.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInputContext.Size = new System.Drawing.Size(359, 26);
            this.tblInputContext.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(294, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // drpHelperNames
            // 
            this.drpHelperNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpHelperNames.FormattingEnabled = true;
            this.drpHelperNames.Location = new System.Drawing.Point(78, 12);
            this.drpHelperNames.Name = "drpHelperNames";
            this.drpHelperNames.Size = new System.Drawing.Size(210, 21);
            this.drpHelperNames.TabIndex = 4;
            this.drpHelperNames.SelectedIndexChanged += new System.EventHandler(this.drpHelperNames_SelectedIndexChanged);
            // 
            // drpResults
            // 
            this.drpResults.FormattingEnabled = true;
            this.drpResults.Location = new System.Drawing.Point(78, 135);
            this.drpResults.Name = "drpResults";
            this.drpResults.Size = new System.Drawing.Size(210, 21);
            this.drpResults.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(294, 133);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 6;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Matches";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Helper";
            // 
            // AppHelperTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(379, 271);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.drpResults);
            this.Controls.Add(this.drpHelperNames);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tblInputContext);
            this.Controls.Add(this.tblOutputContext);
            this.Name = "AppHelperTester";
            this.Text = "AppHelperTester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblOutputContext;
        private System.Windows.Forms.TableLayoutPanel tblInputContext;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox drpHelperNames;
        private System.Windows.Forms.ComboBox drpResults;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}