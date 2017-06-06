using BShop_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BShop_Management
{
    public sealed partial class frmMain : Form
    {  
        private static readonly frmMain _Instance = new frmMain();   //Singleton

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public async void UpdateDisplay()
        {
            try
            {
                comboBoxBranch.DataSource = null;
                comboBoxBranch.DataSource = await ServiceClient.GetBranchCodesAsync();
            }
            catch
            {

            }
        }

        //this method may be redundant. See commented instantiation of frmBranchInventory below
        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnGoInventory_Click(object sender, EventArgs e)
        {
            //new pgPopup(comboBoxBranch.SelectedValue);
            frmBranch.Run((string)comboBoxBranch.SelectedValue);

            //string lcKey;

            //lcKey = Convert.ToString(comboBoxBranch.SelectedText as string);
            //if (lcKey != null)
            //    try
            //    {
            //        frmBranch.Run(comboBoxBranch.SelectedText as string);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "This should never occur");
            //    }

        }

        private void btnGoOrders_Click(object sender, EventArgs e)
        {
            frmOrder.Run();
        }

    }
}
