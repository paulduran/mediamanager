using Media.DAC;
using System.Xml;
using System.Xml.XPath;

namespace MediaManager2
{
    partial class CreateTables
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrentTask = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(11, 71);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(222, 23);
            this.progressBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Preparing Database...";
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.Location = new System.Drawing.Point(11, 52);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(0, 0);
            this.lblCurrentTask.TabIndex = 2;
            // 
            // CreateTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 105);
            this.Controls.Add(this.lblCurrentTask);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.progressBar);
            this.Name = "CreateTables";
            this.Text = "CreateTables";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentTask;

        public void Run()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("dbdefinition.xml");
            DBManager manager = new DBManager();
            
            foreach( XmlNode node in doc.SelectNodes("//tables/table") )
            {
                string name = node.Attributes["name"].Value;
                if (manager.TableExists(name))
                {
                    Debug("table: {0} already exists. not recreating", name);
                }
                else
                {
                    Debug("table: {0} does not exist. creating", name);
                    XmlNode createNode = node.SelectSingleNode("create");
                    string sql = createNode.InnerText;
                    manager.ExecuteNonQuery(sql);
                    Debug("table: {0} created. Inserting records", name);
                    foreach (XmlNode insertNode in node.SelectNodes("insert"))
                    {
                        sql = insertNode.InnerText;
                        int numRecords = manager.ExecuteNonQuery(sql);
                        Debug("{0} records inserted", numRecords);
                    }
                }
            }
        }

        private void Debug(string msg, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(msg, args));
        }
    }
}