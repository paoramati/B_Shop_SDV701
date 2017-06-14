///Title:   pgMain.xaml.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Main page of UWP BShop app
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BShopUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgMain : Page
    {
        public pgMain()
        {
            this.InitializeComponent();
        }

        private async void B_Shop_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                comboBoxBranch.ItemsSource = await ServiceClient.GetBranchCodesAsync();
            }
            catch (Exception ex)
            {
                txtBlockMessage.Text = (ex.Message);
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxBranch.SelectedItem == null)
                txtBlockMessage.Text = "Please select a store";
            else
                Frame.Navigate(typeof(pgBranch), (string)comboBoxBranch.SelectedValue);
        }
    }
}
