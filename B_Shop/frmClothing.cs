using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BShop_Management
{
    public partial class frmClothing : BShop_Management.frmInventory
    {
        //Singleton
        public static readonly frmClothing Instance = new frmClothing();

        private frmClothing()
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
            txtBoxClothingSize.Text = _InventoryItem.clothingSize.Value.ToString();
            if (_InventoryItem.clothingGender.Equals("M"))
                radioClothingMale.Select();
            else if (_InventoryItem.clothingGender.Equals("F"))
                radioClothingFemale.Select();
        }

        protected override void PushData()
        {
            base.PushData();
            _InventoryItem.clothingSize = int.Parse(txtBoxClothingSize.Text);
            if (radioClothingMale.Checked)
                _InventoryItem.clothingGender = "M";
            else if (radioClothingFemale.Checked)
                _InventoryItem.clothingGender = "F";
        }

        protected override bool IsValid()
        {
            base.IsValid();

            return true;
        }
    }
}
