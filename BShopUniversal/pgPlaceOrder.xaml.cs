﻿using System;
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
    public sealed partial class pgPlaceOrder : Page
    {
        public pgPlaceOrder()
        {
            this.InitializeComponent();
        }

        private void textBlock1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock2_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock7_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgConfirmOrder));
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgInventory));
        }
    }
}
