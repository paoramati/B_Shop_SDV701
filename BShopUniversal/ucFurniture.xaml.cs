using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
