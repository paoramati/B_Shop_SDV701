///Title:   frmOrder.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Displays orders for all branches
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BShop_Management
{
    public partial class frmOrder : Form
    {
        private List<clsOrder> _OrderList;

        private decimal _TotalOrderValue;

        public frmOrder()
        {
            InitializeComponent();
        }

        public static void Run()
        {
            frmOrder lcOrderForm = new frmOrder();
            lcOrderForm.refreshFormFromDB();
            lcOrderForm.Show();
            lcOrderForm.Activate();
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
            _TotalOrderValue = 0;
            foreach (clsOrder lcOrder in _OrderList)
                _TotalOrderValue += (lcOrder.priceAtOrder * lcOrder.orderQuantity);
            txtOrderTotal.Enabled = false;
            txtOrderTotal.Text = _TotalOrderValue.ToString();
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

        private void lstBoxOrder_DoubleClick(object sender, EventArgs e)
        {
            frmOrderDetails.Run(lstBoxOrder.SelectedItem as clsOrder);
        }

        private async void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            int lcIndex = lstBoxOrder.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("are you sure?", "deleting order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    clsOrder lcOrder = lstBoxOrder.SelectedValue as clsOrder;
                    MessageBox.Show(await ServiceClient.DeleteOrderAsync(lcOrder.orderID));
                    refreshFormFromDB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }

            }
        }


    }
}
