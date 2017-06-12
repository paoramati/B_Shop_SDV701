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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BShopUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgItemDetail : Page
    {
        private clsInventory _Inventory;

        private clsOrder _Order;

        public pgItemDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UpdatePage(e.Parameter as clsInventory);
            if (e.Parameter != null)
            {

            }
        }

        private void UpdatePage(clsInventory prInventory)
        {
            _Inventory = prInventory;
            lblDescription.Text = _Inventory.description;
            txtPrice.Text = _Inventory.pricePerItem.ToString();
            txtStockQuantity.Text = _Inventory.quantity.ToString();
            txtCategory.Text = _Inventory.category;
        }

        private void SavePage()
        {

        }

        private void CreateOrder()
        {

        }

        private bool IsValid()
        {
            return true;
        }

    }
}
