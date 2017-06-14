///Title:   ucFurniture.xaml.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: User control for furniture orders
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BShopUniversal
{
    public sealed partial class ucFurniture : UserControl, IInventoryControl
    {
        public ucFurniture()
        {
            this.InitializeComponent();
        }

        //public void PushData(clsInventory prInventory)
        //{
        //    throw new NotImplementedException();
        //}

        public void UpdateControl(clsInventory prInventory)
        {
            txtFurnitureWeight.Text = prInventory.furnitureWeight.ToString();
            txtFurnitureNumParts.Text = prInventory.furnitureNumParts.ToString();
        }
    }
}
