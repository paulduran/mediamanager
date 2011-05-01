using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Media.BE;

namespace MediaManager2
{
    public delegate void SelectedMediaItemsHandler( List<MediaFile> selectedMediaItems );

    public partial class TvEpisodeImportDialog : Form
    {
        /// <summary>
        /// called when media items are checked and the ok button is pressed
        /// </summary>
        public event SelectedMediaItemsHandler MediaItemsSelected;

        public TvEpisodeImportDialog()
        {
            InitializeComponent();
        }

        private List<MediaFile> mediaItems;

        public List<MediaFile> MediaItems
        {
            get { return mediaItems; }
            set 
            { 
                mediaItems = value;
                grdMediaItems.DataSource = value;
            }
        }

        private void RaiseMediaItemsSelectedEvent(List<MediaFile> selectedItems)
        {
            if (MediaItemsSelected != null)
                MediaItemsSelected(selectedItems);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<MediaFile> selectedItems = new List<MediaFile>();
            foreach (DataGridViewRow row in grdMediaItems.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells["chkAdd"];
                if (cell.Value == cell.TrueValue)
                {
                    selectedItems.Add((MediaFile)row.DataBoundItem);
                }
            }
            if (selectedItems.Count > 0)
                RaiseMediaItemsSelectedEvent(selectedItems);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grdMediaItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void UpdateCheckboxState()
        {
            bool allChecked = true;
            bool allUnchecked = true;
            foreach (DataGridViewRow row in grdMediaItems.Rows)
            {
                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell )row.Cells[0];
                if (cb.Value == cb.TrueValue)
                {
                    allUnchecked = false;
                }
                else if (cb.Value == cb.FalseValue)
                    allChecked = false;
            }
            if (allChecked)
                chkSelectAll.Checked = true;
            else if (allUnchecked)
                chkSelectAll.Checked = false;
            else
                chkSelectAll.CheckState = CheckState.Indeterminate;
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            if (chkSelectAll.CheckState == CheckState.Checked)
            {
                SetAllChecked(true);
            }
            else
            {
                chkSelectAll.CheckState = CheckState.Unchecked;
                SetAllChecked(false);
            }
        }

        private void SetAllChecked(bool isChecked )
        {
            foreach (DataGridViewRow row in grdMediaItems.Rows)
            {
                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells[0];
                cb.Value = (isChecked) ? cb.TrueValue : cb.FalseValue;
            }
        }

        private void grdMediaItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCheckboxState();
        }
    }
}