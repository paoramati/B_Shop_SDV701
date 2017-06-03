using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SetDetails(await ServiceClient.GetBranchAsync(prBranchCode));
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {

        }

        private void frmBranch_Load(object sender, EventArgs e)
        {



        }



        private void lstBoxInventory_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                frmInventory.DispatchInventoryForm(lstBoxInventory.SelectedValue as clsInventory);
                //_WorksList.EditWork(lstWorks.SelectedIndex);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


//public static void Run(string prBranchCode)
//{
//    //MessageBox.Show(prBranchCode);
//    frmBranch lcBranchForm = new frmBranch();
//    lcBranchForm.refreshFormFromDB(prBranchCode);
//    lcBranchForm.Show();
//    lcBranchForm.Activate();
//}

//public static void Run(string prBranchCode)
//{
//    frmBranch lcBranchForm;
//    if (string.IsNullOrEmpty(prBranchCode) || !_BranchFormList.TryGetValue(prBranchCode, out lcBranchForm))
//    {
//        lcBranchForm = new frmBranch();
//        if (string.IsNullOrEmpty(prBranchCode))
//            lcBranchForm.SetDetails(new clsBranch());
//        else
//        {
//            _BranchFormList.Add(prBranchCode, lcBranchForm);
//            lcBranchForm.refreshFormFromDB(prBranchCode);
//        }
//    }
//    else
//    {
//        lcBranchForm.Show();
//        lcBranchForm.Activate();
//    }
//}
