﻿///Title:   pgBranch.xaml.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Display details for a branch w/ inventory of that branch for UWP app
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BShopUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgBranch : Page
    {
        private clsBranch _Branch;

        public pgBranch()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UpdatePage(e.Parameter.ToString());
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }

        private async void UpdatePage(string prBranchCode)
        {
            try
            {
                SetDetails(await ServiceClient.GetBranchAsync(prBranchCode));
            }
            catch (Exception ex)
            {
                txtBlockMsg.Text = ex.Message;
            }
        }

        private void SetDetails(clsBranch prBranch)
        {
            _Branch = prBranch;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            txtBranchCode.Text = _Branch.branchCode;
            txtBranchPhone.Text = _Branch.branchPhone;
            lstBoxInventory.ItemsSource = _Branch.Inventory.ToList();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxInventory.SelectedItem == null)
                txtBlockMsg.Text = "Please select an item";
            else
                Frame.Navigate(typeof(pgPlaceOrder), (clsInventory)lstBoxInventory.SelectedValue);
        }

        private void lstBoxInventory_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgPlaceOrder), (clsInventory)lstBoxInventory.SelectedValue);
        }
    }
}
