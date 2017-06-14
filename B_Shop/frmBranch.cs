///Title:   frmBranch.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Displays details and inventory for a branch for the bshop windows forms application
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BShop_Management
{
    public partial class frmBranch : Form
    {
        private clsBranch _Branch;

        private static Dictionary<string, frmBranch> _BranchFormList =
            new Dictionary<string, frmBranch>();

        private frmBranch()
        {
            InitializeComponent();
        }

        public static void Run(string prBranchCode)
        {
            frmBranch lcBranchForm;
            if (!_BranchFormList.TryGetValue(prBranchCode, out lcBranchForm))
            {
                lcBranchForm = new frmBranch();
                _BranchFormList.Add(prBranchCode, lcBranchForm);
                lcBranchForm.refreshFormFromDB(prBranchCode);
            }
            else
            {
                lcBranchForm.Show();
                lcBranchForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prBranchCode)
        {
            try
            {
                SetDetails(await ServiceClient.GetBranchAsync(prBranchCode));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void SetDetails(clsBranch prBranch)
        {
            _Branch = prBranch;
            UpdateForm();
            UpdateDisplay();
            Show();
        }

        public void UpdateForm()
        {
            lblBranchCode.Text = _Branch.branchCode;
            lblBranchAddress.Text = _Branch.branchAddress;
            lblBranchPhone.Text = _Branch.branchPhone;
        }

        private void UpdateDisplay()
        {
            lstBoxInventory.DataSource = null;
            lstBoxInventory.DataSource = _Branch.Inventory;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain.Instance.UpdateDisplay();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            try
            {
                string lcReply = new InputBox(clsInventory.FACTORY_PROMPT, clsInventory.ItemCategories).Answer;
                clsInventory lcInventory = clsInventory.NewInventory(lcReply);
                if (!string.IsNullOrEmpty(lcReply))  // not cancelled?
                {
                    if (lcInventory != null)    //valid inventory created?
                    {
                        lcInventory.branchCode = _Branch.branchCode;
                        frmInventory.DispatchInventoryForm(lcInventory);
                        if (!string.IsNullOrEmpty(lcInventory.description)) // not cancelled?
                        {
                            refreshFormFromDB(_Branch.branchCode);
                            UpdateDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void lstBoxInventory_DoubleClick(object sender, EventArgs e)
        {
            UpdateBranchInventory();
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            UpdateBranchInventory();
        }

        private void UpdateBranchInventory()
        {
            try
            {
                frmInventory.DispatchInventoryForm(lstBoxInventory.SelectedValue as clsInventory);
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private async void btnDeleteInventory_Click(object sender, EventArgs e)
        {
            int lcIndex = lstBoxInventory.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("are you sure?", "deleting inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsInventory lcInventory = lstBoxInventory.SelectedValue as clsInventory;
                try
                {
                    MessageBox.Show(await ServiceClient.DeleteInventoryAsync(lcInventory.itemID));
                    refreshFormFromDB(_Branch.branchCode);
                    frmMain.Instance.UpdateDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }

            }
        }
    }
}