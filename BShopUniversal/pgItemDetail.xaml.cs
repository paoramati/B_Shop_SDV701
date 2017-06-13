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

        public pgItemDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DispatchInventoryForm(e.Parameter as clsInventory);
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
        }

        //private void SavePage()
        //{

        //}

        //private void CreateOrder()
        //{

        //}

        private bool IsValid()
        {
            bool lcResult = true;
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                //_ValidationErrors.Add("Description must not be empty");
                lcResult = false;
            }
            if (string.IsNullOrEmpty(txtCustomerEmail.Text))
            {
                //_ValidationErrors.Add("Description must not be empty");
                lcResult = false;
            }
            if (!clsBShopUtility.CheckIntValue(txtOrderQuantity.Text, 0))
            {
                //_ValidationErrors.Add("Quantity must be a number greater than 0");
                lcResult = false;
            }
            return lcResult;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                var confirmDlg = new ContentDialog
                {
                    Title = "Confirm Order",
                    Content = "Do you want to order this item?",
                    PrimaryButtonText = "OK",
                    SecondaryButtonText = "Cancel"
                };
                var lcResult = await confirmDlg.ShowAsync();

                if (lcResult == ContentDialogResult.Primary)
                {
                    try
                    {
                        PushData();
                        Frame.Navigate(typeof(pgConfirmOrder));
                    }
                    catch (Exception ex)
                    {
                        ContentDialog excep = new ContentDialog()
                        {
                            
                            Content = ex.Message + "\n" + ex.StackTrace,
                            PrimaryButtonText = "OK"
                            
                        };
                        await excep.ShowAsync();
                    }
                    
                }
                else
                    if (lcResult == ContentDialogResult.Secondary)
                {

                }


            }
            else
            {
                ContentDialog invalid = new ContentDialog()
                {
                    Content = "This form has errors",
                    //Content = ex.Message + "\n" + ex.StackTrace,
                    PrimaryButtonText = "OK"

                };
                await invalid.ShowAsync();
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private async void DisplayConfirmDialog()
        //{
        //    ContentDialog confirmOrderDialog = new ContentDialog()
        //    {
        //        Title = "Confirm Order",
        //        Content = "Do you want to order this item?",
        //        PrimaryButtonText = "OK",
        //        SecondaryButtonText = "Cancel"
        //    };
        //    //confirmOrderDialog.PrimaryButtonClick += ConfirmOrderDialog_PrimaryButtonClick;
        //    //confirmOrderDialog.SecondaryButtonClick += ConfirmOrderDialog_SecondaryButtonClick;
        //    var lcResult = await confirmOrderDialog.ShowAsync();       

        //    if (lcResult == ContentDialogResult.Primary)
        //    {

        //    }

            
        //}

        //private void ConfirmOrderDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        //{
        //    sender.Hide();
        //}

        //private void ConfirmOrderDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        //{
        //    sender.Hide();
        //    //PushData();
        //}
    }
}
