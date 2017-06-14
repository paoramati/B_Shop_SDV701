///Title:   frmFurniture.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Subclass of frmInventory, displays added furniture fields
namespace BShop_Management
{
    public sealed partial class frmFurniture : frmInventory
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
            bool lcValid = true;
            if (!base.IsValid())
                lcValid = false;
            if (!clsBShopUtility.CheckFloatValue(txtBoxFurnitureWeight.Text))
            {
                _ValidationErrors.Add("Furniture weight must be a number greater than 0");
                lcValid = false;
            }
            if (!clsBShopUtility.CheckIntValue(updownFurnitureNumParts.Value.ToString()))
            {
                _ValidationErrors.Add("Furniture parts must be a number greater than 0");
                lcValid = false;
            }
            return lcValid;
        }
    }
}
