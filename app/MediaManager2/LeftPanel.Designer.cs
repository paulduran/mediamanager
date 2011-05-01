namespace MediaManager2
{
    partial class LeftPanel
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
            this.stackStripSplitter = new System.Windows.Forms.SplitContainer();
            this.titleStrip = new OLAF.Controls.HeaderStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.mediaItemTree1 = new MediaManager2.MediaItemTree();
            this.stackStrip = new OLAF.Controls.StackStrip();
            this.stackStripSplitter.Panel1.SuspendLayout();
            this.stackStripSplitter.SuspendLayout();
            this.titleStrip.SuspendLayout();
            this.stackStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackStripSplitter
            // 
            this.stackStripSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackStripSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.stackStripSplitter.Location = new System.Drawing.Point(0, 0);
            this.stackStripSplitter.Name = "stackStripSplitter";
            this.stackStripSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // stackStripSplitter.Panel1
            // 
            this.stackStripSplitter.Panel1.Controls.Add(this.mediaItemTree1);
            this.stackStripSplitter.Panel1.Controls.Add(this.titleStrip);
            this.stackStripSplitter.Panel2.Controls.Add(this.stackStrip);
            this.stackStripSplitter.Size = new System.Drawing.Size(300, 450);
            this.stackStripSplitter.SplitterDistance = 330;
            this.stackStripSplitter.SplitterWidth = 7;
            this.stackStripSplitter.TabIndex = 0;
            // 
            // titleStrip
            // 
            this.titleStrip.AutoSize = false;
            this.titleStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.titleStrip.ForeColor = System.Drawing.Color.White;
            this.titleStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.titleStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.titleStrip.Location = new System.Drawing.Point(0, 0);
            this.titleStrip.Name = "titleStrip";
            this.titleStrip.Size = new System.Drawing.Size(300, 25);
            this.titleStrip.TabIndex = 2;
            this.titleStrip.Text = "headerStrip2";
            // 
            // stackStrip
            // 
            this.stackStrip.AutoSize = false;
            this.stackStrip.CanOverflow = false;
            this.stackStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackStrip.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.stackStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stackStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
 
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 22);
            this.toolStripLabel1.Text = " Tv Series";
            // 
            // mediaItemTree1
            // 
            this.mediaItemTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaItemTree1.Location = new System.Drawing.Point(0, 25);
            this.mediaItemTree1.Name = "mediaItemTree1";
            this.mediaItemTree1.SelectedItem = null;
            this.mediaItemTree1.Size = new System.Drawing.Size(300, 305);
            this.mediaItemTree1.TabIndex = 3;
            // 
            // LeftPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackStripSplitter);
            this.Name = "LeftPanel";
            this.Size = new System.Drawing.Size(300, 450);
            this.stackStripSplitter.Panel1.ResumeLayout(false);
            this.stackStripSplitter.ResumeLayout(false);
            this.titleStrip.ResumeLayout(false);
            this.titleStrip.PerformLayout();
            this.stackStrip.ResumeLayout(false);
            this.stackStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer stackStripSplitter;
        private OLAF.Controls.HeaderStrip titleStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private MediaItemTree mediaItemTree1;
        private OLAF.Controls.StackStrip stackStrip;
    }
}
