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

        //public static void Run(string prBranchCode)
        //{
        //    //new pgPopup(prBranchCode);
        //    frmBranch lcBranchForm;
        //    lcBranchForm = new frmBranch();
        //    //lcBranchForm.refreshFormFromDB(prBranchCode);
            
        //    lcBranchForm.Show();
        //    lcBranchForm.Activate();
        //    //lcBranchForm.refreshFormFromDB(prBranchCode);

            //if (string.IsNullOrEmpty(prBranchCode) || !_BranchFormList.TryGetValue(prBranchCode, out lcBranchForm))
            //{
            //    lcBranchForm = new frmBranch();
            //    if (string.IsNullOrEmpty(prBranchCode))
            //    {
            //        //lcBranchForm.SetDetails(new clsBranch());
            //    }

            //    else
            //    {
            //        //_BranchFormList.Add(prBranchCode, lcBranchForm);
            //        //lcBranchForm.refreshFormFromDB(prBranchCode);
            //    }
            //}
            //else
            //{
            //    lcBranchForm.Show();
            //    lcBranchForm.Activate();
            //}
        //}

        public static void Run(string prBranchCode)
        {
            new pgPopup(prBranchCode);
            frmBranch lcBranchForm = new frmBranch();
            lcBranchForm.refreshFormFromDB(prBranchCode);
            lcBranchForm.Show();
            lcBranchForm.Activate();

            //if (string.IsNullOrEmpty(prBranchCode) ||
            //!_BranchFormList.TryGetValue(prBranchCode, out lcBranchForm))
            //{
            //    lcBranchForm = new frmBranch();
            //    if (string.IsNullOrEmpty(prBranchCode))
            //        lcBranchForm.SetDetails(new clsBranch());
            //    else
            //    {
            //        _BranchFormList.Add(prBranchCode, lcBranchForm);
            //        lcBranchForm.refreshFormFromDB(prBranchCode);
            //    }
            //}
            //else
            //{
            //    lcBranchForm.Show();
            //    lcBranchForm.Activate();
            //}
        }

        private async void refreshFormFromDB(string prBranchCode)
        {
            SetDetails(await ServiceClient.GetBranchAsync(prBranchCode.ToUpper()));
        }

        public void SetDetails(clsBranch prBranch)
        {
            _Branch = prBranch;
            lblBranchName.Text = _Branch.branchCode;
            UpdateForm();
            UpdateDisplay();
            //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
            Show();

        }

        public void UpdateForm()
        {

 //           throw new NotImplementedException();
        }

        private void UpdateDisplay()
        {
            lstBoxInventory.DataSource = null;
            //lstBoxInventory.DataSource =  _Branch.Inventory;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //frm form2 = new frm();
            //form2.ShowDialog();
            //Form2.ActiveForm(); 
           
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {

        }

        private void frmBranch_Load(object sender, EventArgs e)
        {
 

            
        }
    }
}
