///Title:   ucClothing.xaml.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: User control for clothing orders
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BShopUniversal
{
    public sealed partial class ucClothing : UserControl, IInventoryControl
    {
        public ucClothing()
        {
            this.InitializeComponent();
        }

        public void UpdateControl(clsInventory prInventory)
        {
            txtClothingSize.Text = prInventory.clothingSize.ToString();
            txtClothingGender.Text = prInventory.clothingGender;
        }
    }
}
