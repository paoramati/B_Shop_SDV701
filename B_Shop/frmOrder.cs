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
    public partial class frmOrder : Form
    {
        private List<clsOrder> _OrderList;

        private static Dictionary<int, frmOrder> _OrderFormList =
            new Dictionary<int, frmOrder>();

        public frmOrder()
        {
            InitializeComponent();
        }

        public static void Run()
        {
            frmOrder lcOrderForm = new frmOrder();
            //if (!_OrderFormList.TryGetValue(prOrderID, out lcOrderForm))
            //{
            //    lcOrderForm = new frmOrder();
            //    _OrderFormList.Add(prOrderID, lcOrderForm);
            //    lcOrderForm.refreshFormFromDB(prOrderID);
            //}
            //else
            {
                lcOrderForm.refreshFormFromDB();
                lcOrderForm.Show();
                lcOrderForm.Activate();
            }
        }

        private async void refreshFormFromDB()
        {
            try
            {
                SetDetails(await ServiceClient.GetOrderListAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void SetDetails(List<clsOrder> prOrderList)
        {
            _OrderList = prOrderList;
            UpdateForm();
            UpdateDisplay();
            Show();
        }

        public void UpdateForm()
        {
            //lblBranchCode.Text = _Branch.branchCode;
            //lblBranchAddress.Text = _Branch.branchAddress;
            //lblBranchPhone.Text = _Branch.branchPhone;
        }

        private void UpdateDisplay()
        {
            lstBoxOrder.DataSource = null;
            lstBoxOrder.DataSource = _OrderList.ToList();
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

        private void lstBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {

        }

        private void lstBoxOrder_DoubleClick(object sender, EventArgs e)
        {
            frmOrderDetails.Run(lstBoxOrder.SelectedItem as clsOrder);
        }
    }
}
