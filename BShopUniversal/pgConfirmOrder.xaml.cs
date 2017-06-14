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
    public sealed partial class pgConfirmOrder : Page
    {
        private clsOrder _Order;

        public pgConfirmOrder()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UpdatePage(e.Parameter as clsOrder);
           



            //lblDescription.Text = _Order.description.ToString();

            //UpdatePage();
            //UpdatePage(e.Parameter as clsOrder);
            //UpdateDisplay(e.Parameter.ToString());
        }

        private async void UpdatePage(clsOrder prOrder)
        {
            try
            {
                _Order = prOrder;
                lblDescription.Text = _Order.description.ToString();
                txtOrderQuantity.Text = _Order.orderQuantity.ToString();
                txtCustomerName.Text = _Order.customerName;
                txtCustomerEmail.Text = _Order.customerEmail;
                txtTotal.Text = (_Order.orderQuantity * _Order.priceAtOrder).ToString();
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgMain));
        }
    }
}
