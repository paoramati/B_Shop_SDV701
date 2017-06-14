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
