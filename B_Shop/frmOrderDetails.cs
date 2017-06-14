///Title:   frmOrderDetails.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Displays details for a particular order 
using System;
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
            frmOrderDetails lcOrderDetailsForm;
            lcOrderDetailsForm = new frmOrderDetails();
            lcOrderDetailsForm.refreshFormFromDB(prOrder.orderID);
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
            txtDescription.Enabled = false;
            txtCustomerName.Enabled = false;
            txtCustomerEmail.Enabled = false;
            txtOrderQuantity.Enabled = false;
            txtPriceAtOrder.Enabled = false;
            txtOrderDate.Enabled = false;

            txtOrderID.Text = _Order.orderID.ToString();
            txtDescription.Text = _Order.description;
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
