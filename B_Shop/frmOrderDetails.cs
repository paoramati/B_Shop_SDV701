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
    public sealed partial class frmOrderDetails : Form
    {
        //Singleton
        public static readonly frmOrderDetails Instance = new frmOrderDetails();

        private clsOrder _Order;

        public frmOrderDetails()
        {
            InitializeComponent();
        }

        public static void Run(clsOrder prOrder)
        {
            //Instance.SetDetails(prOrder);
            frmOrderDetails lcOrderDetailsForm;
            //if (!_BranchFormList.TryGetValue(prBranchCode, out lcBranchForm))
            //{
            lcOrderDetailsForm = new frmOrderDetails();
            lcOrderDetailsForm.refreshFormFromDB(prOrder.orderID);
            //    lcBranchForm = new frmBranch();
            //    _BranchFormList.Add(prBranchCode, lcBranchForm);
            //    lcBranchForm.refreshFormFromDB(prBranchCode);
            ////}
            //else
            //{
            //    lcOrderDetailsForm.Show();
            //    lcOrderDetailsForm.Activate();
            ////}
        }

        private async void refreshFormFromDB(int prOrderID)
        {
            try
            {
                SetDetails(await ServiceClient.GetOrderAsync(prOrderID));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void SetDetails(clsOrder prOrder)
        {
            _Order = prOrder;
            UpdateForm();
            ShowDialog();
        }

        private void UpdateForm()
        {
            txtOrderID.Enabled = false;
            txtItemID.Enabled = false;
            txtCustomerName.Enabled = false;
            txtCustomerEmail.Enabled = false;
            txtOrderQuantity.Enabled = false;
            txtPriceAtOrder.Enabled = false;
            txtOrderDate.Enabled = false;

            txtOrderID.Text = _Order.orderID.ToString();
            txtItemID.Text = _Order.itemID.ToString();
            txtOrderDate.Text = _Order.orderDateTime.ToString();
            txtOrderQuantity.Text = _Order.orderQuantity.ToString();
            txtPriceAtOrder.Text = _Order.priceAtOrder.ToString();
            txtCustomerName.Text = _Order.customerName.ToString();
            txtCustomerEmail.Text = _Order.customerEmail.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
