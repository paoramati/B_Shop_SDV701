using B_Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_Shop_Windows
{
    public sealed partial class frmMain : Form
    {
        //singleton
        private static readonly frmMain _Instance = new frmMain();

        private frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get
            {
                return _Instance;
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            //frm form2 = new frm();
            //form2.ShowDialog();
            //Form2.ActiveForm(); 
            


        }

        private void btnOrders_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //using (bshopdbEntities bshop = new bshopdbEntities())
            //{
            //    var _Branches = bshop.tblbranches.ToList();

            //    foreach (var lcBranch in _Branches)
            //    {
            //        clsBranch branch = new clsBranch();
            //        branch.BranchID = lcBranch.branchID;
            //        branch.BranchName = lcBranch.branchName;
            //        branch.BranchAddress = lcBranch.branchAddress;
            //        branch.BranchPhone = lcBranch.branchPhone;
            //        //comboBoxBranch.DataSource = branch.BranchName;
            //    }
            //}

            clsBranchList lcBranchList = new clsBranchList();

            List<string> _BranchList = new List<string>();
            _BranchList = lcBranchList.GetBranchNames();

            comboBoxBranch.DataSource = _BranchList;        //this displays the branches!!!

        }

        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
