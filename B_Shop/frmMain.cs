﻿///Title:   frmMain.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Main form for bshops windows form application
using System;
using System.Windows.Forms;

namespace BShop_Management
{
    public sealed partial class frmMain : Form
    {  
        private static readonly frmMain _Instance = new frmMain();   //Singleton

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public async void UpdateDisplay()
        {
            try
            {
                comboBoxBranch.DataSource = null;
                comboBoxBranch.DataSource = await ServiceClient.GetBranchCodesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnGoInventory_Click(object sender, EventArgs e)
        {
            frmBranch.Run((string)comboBoxBranch.SelectedValue);
        }

        private void btnGoOrders_Click(object sender, EventArgs e)
        {
            frmOrder.Run();
        }

    }
}
