using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Media.BC;
using Media.BE;

namespace Media.AppHelpers.TestApp
{
    public partial class AppHelperTester : Form
    {
        private AppHelperFactory factory = new AppHelperFactory(@"C:\Documents and Settings\pauld\My Documents\Visual Studio 2005\Projects\MediaManager2\MediaManager2\AppHelpers.xml");

        private IAppHelper helper;
        private AppHelperContext context;

        public AppHelperTester()
        {
            InitializeComponent();

            foreach (string appHelperName in factory.GetAppHelperNames())
            {
                drpHelperNames.Items.Add(appHelperName);
            }
        }

        private void drpHelperNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpHelperNames.SelectedItem == null)
            {
                return;
            }
            string appHelperName = (string)drpHelperNames.SelectedItem;
            context = factory.GetAppHelperContext(appHelperName);
/*
            tblInputContext.Controls.Clear();
           // tblInputContext.ColumnCount = 2;
            tblInputContext.RowCount = context.InputFields.Length;
            int row = 0;
            foreach (string fieldname in context.InputFields)
            {
                System.Diagnostics.Debug.WriteLine("received input field: " + fieldname);
                Label l = new Label();
                l.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                l.Text = fieldname;
                TextBox textField = new TextBox();
                textField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                tblInputContext.Controls.Add(l, 0, row);
                tblInputContext.Controls.Add(textField, 1, row);
                row++;
            }*/

            tblInputContext.SuspendLayout();

            tblInputContext.Controls.Clear();
            tblInputContext.ColumnCount = 2;
            this.tblInputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblInputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblInputContext.RowCount = context.InputFields.Length;
            for (int i = 0; i < tblInputContext.RowCount; i++)
            {
                this.tblInputContext.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            }

            int row = 0;
            foreach (string fieldname in context.InputFields)
            {
                System.Diagnostics.Debug.WriteLine("received input field: " + fieldname);
                Label label = new Label();
                //label.Size = new Size((int)(fieldname.Length * 8.5), 14);
                label.AutoSize = true;
                label.Anchor = AnchorStyles.Left;
                label.Text = fieldname;
                TextBox textField = new TextBox();
                //textField.Size = new System.Drawing.Size(249, 20);
                textField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                tblInputContext.Controls.Add(label, 0, row);
                tblInputContext.Controls.Add(textField, 1, row);
                row++;
            }

            tblInputContext.ResumeLayout();
            tblOutputContext.SuspendLayout();

            tblOutputContext.Controls.Clear();
            tblOutputContext.ColumnCount = 2;
            this.tblOutputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
            this.tblOutputContext.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            tblOutputContext.RowCount = context.OutputFields.Length;
            for (int i = 0; i < tblOutputContext.RowCount; i++)
            {
                this.tblOutputContext.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            }
            row = 0;
            foreach (string fieldname in context.OutputFields)
            {                
                System.Diagnostics.Debug.WriteLine("received output field: " + fieldname);
                Label l = new Label();
                l.AutoSize = true;
                l.Anchor = AnchorStyles.Left;
                l.Text = fieldname;
                TextBox textField = new TextBox();                
                textField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                tblOutputContext.Controls.Add(l, 0, row);
                tblOutputContext.Controls.Add(textField, 1, row);
                row++;
            }

            tblOutputContext.ResumeLayout();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string appHelperName = (string)drpHelperNames.SelectedItem;
            string contextFieldName = null;
            foreach (Control c in tblInputContext.Controls)
            {
                if (c is Label)
                {
                    contextFieldName = c.Text;
                }
                else if (c is TextBox)
                {
                    if (contextFieldName != null && c.Text.Length > 0)
                        context[contextFieldName] = c.Text;
                    else if (contextFieldName != null)
                        context[contextFieldName] = null;
                }
            }
            helper = factory.GetAppHelper(appHelperName);
            drpResults.Controls.Clear();
            AppHelperItem []items = helper.LocateItems(context);
            foreach (AppHelperItem item in items)
            {
                drpResults.Items.Add(new ItemHolder(item));
            }
        }

        private class ItemHolder
        {
            public AppHelperItem item;
            public ItemHolder(AppHelperItem item)
            {
                this.item = item;
            }

            public override string ToString()
            {
                return item.Name;
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            ItemHolder holder = (ItemHolder)drpResults.SelectedItem;
            if (holder == null)
                return;

            if (helper.LoadItem(holder.item, context))
            {
                int row = 0;
                foreach (string fieldname in context.OutputFields)
                {
                    object val = context[fieldname];
                    if( val != null )
                        tblOutputContext.Controls[(row * 2) + 1].Text = val.ToString();
                    else
                        tblOutputContext.Controls[(row * 2) + 1].Text = "";
                    row++;
                }
            }
        }
    }
}