using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BShop_Management
{
    public partial class frmFurniture : BShop_Management.frmInventory
    {
        //Singleton
        public static readonly frmFurniture Instance = new frmFurniture();

        private frmFurniture()
        {
            InitializeComponent();
        }

        public static void Run(clsInventory prInventoryItem)
        {
            Instance.SetDetails(prInventoryItem);
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtBoxFurnitureWeight.Text = _InventoryItem.furnitureWeight.ToString();
            updownFurnitureNumParts.Value = _InventoryItem.furnitureNumParts.Value;
        }

        protected override void PushData()
        {
            base.PushData();
            _InventoryItem.furnitureWeight = float.Parse(txtBoxFurnitureWeight.Text);
            _InventoryItem.furnitureNumParts = (int)updownFurnitureNumParts.Value;
            //_Work.Width = float.Parse(txtWidth.Text);
            //_Work.Height = float.Parse(txtHeight.Text);
            //_Work.Type = txtType.Text;
        }
    }
}
