using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BShop_Management
{
    public sealed partial class frmFurniture : BShop_Management.frmInventory
    {
        //Singleton
        public static readonly frmFurniture Instance = new frmFurniture();

        private frmFurniture()
        {
            InitializeComponent();
        }

        public static void Run(clsInventory prInventory)
        {
            Instance.SetDetails(prInventory);
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtBoxFurnitureWeight.Text = _Inventory.furnitureWeight.ToString();
            if (_Inventory.furnitureNumParts.HasValue)
                updownFurnitureNumParts.Value = _Inventory.furnitureNumParts.Value;
        }

        protected override void PushData()
        {
            base.PushData();
            _Inventory.furnitureWeight = float.Parse(txtBoxFurnitureWeight.Text);
            _Inventory.furnitureNumParts = (int)updownFurnitureNumParts.Value;
        }

        protected override bool IsValid()
        {
            base.IsValid();
            if (!clsBShopUtility.CheckFloatValue(txtBoxFurnitureWeight.Text))
                return false;
            if (!clsBShopUtility.CheckIntValue(updownFurnitureNumParts.Value.ToString()))
                return false;
            return true;
        }
    }
}
