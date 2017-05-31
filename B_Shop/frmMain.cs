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
        //private clsBranch 

        private string _BranchName;

        private frmMain()
        {
            InitializeComponent();
            _BranchName = (string)comboBoxBranch.SelectedValue;
        }

        public static frmMain Instance
        {
            get
            {
                return _Instance;
            }
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
            comboBoxBranch.DataSource = lcBranchList.GetBranchNames();


            //this displays the branches!!!
            //clsBranchList lcBranchList = new clsBranchList();
            //List<string> _BranchList = new List<string>();
            //_BranchList = lcBranchList.GetBranchNames();
            //comboBoxBranch.DataSource = _BranchList;        

        }

        //this method may be redundant. See commented instantiation of frmBranchInventory below
        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _BranchName = (string)comboBoxBranch.SelectedValue;
        }

        private void btnGoInventory_Click(object sender, EventArgs e)
        {
            new frmBranchInventory((string)comboBoxBranch.SelectedValue);
            //new frmBranchInventory(_BranchName);


            //frm form2 = new frm();
            //form2.ShowDialog();
            //Form2.ActiveForm(); 



        }

        private void btnGoOrders_Click(object sender, EventArgs e)
        {

        }

    }
}
