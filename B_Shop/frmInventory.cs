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
    public partial class frmInventory : Form
    {
        protected clsInventory _Inventory;

        protected List<string> _ValidationErrors;

        public frmInventory()
        {
            InitializeComponent();
        }

        public delegate void LoadInventoryFormDelegate(clsInventory prInventory);

        private static Dictionary<string, Delegate> _InventoryForm = new Dictionary<string, Delegate>
        {
            {"Clothing", new LoadInventoryFormDelegate(frmClothing.Run)},
            {"Furniture", new LoadInventoryFormDelegate(frmFurniture.Run)},
        };

        public static void DispatchInventoryForm(clsInventory prInventory)
        {
            _InventoryForm[prInventory.category].DynamicInvoke(prInventory);
        }

        public void SetDetails(clsInventory prInventory)
        {
            _Inventory = prInventory;
            UpdateForm();
            ShowDialog();
        }

        protected virtual void UpdateForm()
        {
            //_ValidationErrors.Clear();
            _ValidationErrors = new List<string>();
            txtBoxBranch.Enabled = false;
            txtBoxDateModified.Enabled = false;

            txtBoxDescription.Text = _Inventory.description;
            txtBoxPrice.Text = _Inventory.pricePerItem.ToString();
            txtBoxQuantity.Text = _Inventory.quantity.ToString();
            txtBoxBranch.Text = _Inventory.branchCode;
            txtBoxDateModified.Text = _Inventory.lastModified.ToShortDateString();
        }

        protected virtual void PushData()
        {
            _Inventory.description = txtBoxDescription.Text;
            _Inventory.pricePerItem = decimal.Parse(txtBoxPrice.Text);
            _Inventory.quantity = int.Parse(txtBoxQuantity.Text);
            _Inventory.branchCode = txtBoxBranch.Text;
            _Inventory.lastModified = DateTime.Now;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            _ValidationErrors.Clear();
            try
            {
                if (IsValid())
                {
                    PushData();
                    if(_Inventory.itemID == 0)      //if item is new
                        MessageBox.Show(await ServiceClient.InsertInventoryAsync(_Inventory));
                    else
                        MessageBox.Show(await ServiceClient.UpdateInventoryAsync(_Inventory));
                    Close();
                }
                else
                {

                    //shoot off validation errors, perhaps return focus to first offending input
                    //MessageBox.Show("There are errors with this form");
                    MessageBox.Show(String.Join("\n", _ValidationErrors));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool IsValid()
        {
            bool lcResult = true;
            if (string.IsNullOrEmpty(txtBoxDescription.Text))
            {
                _ValidationErrors.Add("Description must not be empty");
                lcResult = false;
            }
            if (!clsBShopUtility.CheckDecimalValue(txtBoxPrice.Text))
            {
                _ValidationErrors.Add("Price must be a number greater than 0");
                lcResult = false;
            }
            if (!clsBShopUtility.CheckIntValue(txtBoxQuantity.Text))
            {
                _ValidationErrors.Add("Quantity must be a number greater than 0");
                lcResult = false;
            }
            return lcResult;
        }
    }


}
