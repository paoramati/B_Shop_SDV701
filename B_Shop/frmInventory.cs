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
        protected clsInventory _InventoryItem;

        public frmInventory()
        {
            InitializeComponent();
        }

        public delegate void LoadInventoryFormDelegate(clsInventory prInventoryItem);

        private static Dictionary<string, Delegate> _InventoryForm = new Dictionary<string, Delegate>
        {
            {"Clothing", new LoadInventoryFormDelegate(frmClothing.Run)},
            {"Furniture", new LoadInventoryFormDelegate(frmFurniture.Run)},
        };

        public static void DispatchInventoryForm(clsInventory prInventoryItem)
        {
            _InventoryForm[prInventoryItem.category].DynamicInvoke(prInventoryItem);
        }

        public void SetDetails(clsInventory prInventoryItem)
        {
            _InventoryItem = prInventoryItem;
            UpdateForm();
            ShowDialog();
        }

        protected virtual void UpdateForm()
        {
            //txtBoxBranch.Enabled = string.IsNullOrEmpty(_InventoryItem.branchCode);
            txtBoxBranch.Enabled = false;
            txtBoxDateModified.Enabled = false;

            txtBoxDescription.Text = _InventoryItem.description;
            txtBoxPrice.Text = _InventoryItem.pricePerItem.ToString();
            txtBoxQuantity.Text = _InventoryItem.quantity.ToString();
            txtBoxBranch.Text = _InventoryItem.branchCode;
            txtBoxDateModified.Text = _InventoryItem.lastModified.ToShortDateString();
        }

        protected virtual void PushData()
        {
            _InventoryItem.description = txtBoxDescription.Text;
            _InventoryItem.pricePerItem = decimal.Parse(txtBoxPrice.Text);
            _InventoryItem.quantity = int.Parse(txtBoxQuantity.Text);
            _InventoryItem.branchCode = txtBoxBranch.Text;
            _InventoryItem.lastModified = DateTime.Parse(txtBoxDateModified.Text);
        }

        protected virtual bool IsValid()
        {
            return true;
        }

    }


}
