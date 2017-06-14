///
///
///


using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BShopUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgPlaceOrder : Page
    {
        private clsInventory _Inventory;

        private clsOrder _Order;

        public delegate void LoadInventoryControlDelegate(clsInventory prInventory);
        public void DispatchInventoryForm(clsInventory prInventory)
        {
            Dictionary<string, Delegate> _InventoryForm = new Dictionary<string, Delegate>
            {
                {"Clothing", new LoadInventoryControlDelegate(RunClothing)},
                {"Furniture", new LoadInventoryControlDelegate(RunFurniture)}
            };
            _InventoryForm[prInventory.category].DynamicInvoke(prInventory);
            UpdatePage(prInventory);
        }

        public pgPlaceOrder()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DispatchInventoryForm(e.Parameter as clsInventory);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }

        private void RunClothing(clsInventory prInventory)
        {
            ctcInventoryDetails.Content = new ucClothing();
        }

        private void RunFurniture(clsInventory prInventory)
        {
            ctcInventoryDetails.Content = new ucFurniture();
        }

        private void UpdatePage(clsInventory prInventory)
        {
            _Inventory = prInventory;
            lblDescription.Text = _Inventory.description;
            txtPrice.Text = _Inventory.pricePerItem.ToString();
            txtStockQuantity.Text = _Inventory.quantity.ToString();
            lblCategory.Text = _Inventory.category;
            (ctcInventoryDetails.Content as IInventoryControl).UpdateControl(prInventory);
        }

        private void PushData()
        {
            _Order = new clsOrder();
            _Order.itemID = _Inventory.itemID;
            _Order.priceAtOrder = _Inventory.pricePerItem;
            _Order.orderQuantity = int.Parse(txtOrderQuantity.Text);
            _Order.customerName = txtCustomerName.Text;
            _Order.customerEmail = txtCustomerEmail.Text;
            _Order.orderDateTime = DateTime.Now;

            _Inventory.quantity = _Inventory.quantity - _Order.orderQuantity;
        }

        private bool IsValid()
        {
            bool lcResult = true;
            if (string.IsNullOrEmpty(txtCustomerName.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtCustomerEmail.Text))
                lcResult = false;
            if (!clsBShopUtility.CheckIntValue(txtOrderQuantity.Text, 0))
                lcResult = false;
            //check whether current stock is enough
            if (int.Parse(txtOrderQuantity.Text) > _Inventory.quantity)
            {

                lcResult = false;
            }
            return lcResult;
        }

        private async void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            BshopDialog lcDialog = new BshopDialog();
            var lcResult = await lcDialog.ShowAsync();
            if (lcResult == ContentDialogResult.Primary)
            {
                if (IsValid())
                {
                    PushData();
                    try
                    {
                        await ServiceClient.UpdateInventoryAsync(_Inventory);
                        lcDialog.Content = await ServiceClient.InsertOrderAsync(_Order);
                        await lcDialog.ShowAsync();
                        Frame.GoBack();
                    }
                    catch (Exception ex)
                    {
                        lcDialog.Content = ex.Message;
                        lcDialog.SecondaryButtonText = "";
                        await lcDialog.ShowAsync();
                    }
                }
                else
                {
                    lcDialog.Content = "This form has errors";
                    lcDialog.SecondaryButtonText = "";
                    await lcDialog.ShowAsync();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
