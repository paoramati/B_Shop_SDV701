﻿///Title:   frmClothing.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Subclass of frmInventory, displays added clothing fields
namespace BShop_Management
{
    public sealed partial class frmClothing : frmInventory
    {
        //Singleton
        public static readonly frmClothing Instance = new frmClothing();

        private frmClothing()
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
            txtBoxClothingSize.Text = _Inventory.clothingSize.ToString();
            switch (_Inventory.clothingGender)
            {
                case "M": radioClothingMale.Select(); break;
                case "F": radioClothingFemale.Select(); break;
            }
        }

        protected override void PushData()
        {
            base.PushData();
            _Inventory.clothingSize = int.Parse(txtBoxClothingSize.Text);
            if (radioClothingMale.Checked)
                _Inventory.clothingGender = "M";
            else if (radioClothingFemale.Checked)
                _Inventory.clothingGender = "F";
        }

        protected override bool IsValid()
        {
            bool lcValid = true;
            if (!base.IsValid())
                lcValid = false;
            if (!clsBShopUtility.CheckIntValue(txtBoxClothingSize.Text))
            {
                _ValidationErrors.Add("Clothing size must be a number greater than or equal to 0");
                lcValid = false;
            }
            return lcValid; 
        }
    }
}
