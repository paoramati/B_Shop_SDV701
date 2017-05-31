﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_Shop
{
    public partial class frmBranchInventory : Form
    {
        public frmBranchInventory(string prBranchName)
        {
            InitializeComponent();
            lblBranchName.Text = prBranchName; 
            //will need to call a method here to discriminate inventory from prBranchName, and only show that

            ShowDialog();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //frm form2 = new frm();
            //form2.ShowDialog();
            //Form2.ActiveForm(); 
           
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {

        }

        private void frmBranchInventory_Load(object sender, EventArgs e)
        {
            using (bshopdbEntities bshop = new bshopdbEntities())
            {
                var inventory = bshop.tblinventories.ToList();
                IQueryable<tblinventory> inventoryQuery = from tblinventory in bshop.tblinventories
                                                          where tblinventory.branchID == 1
                                                          select tblinventory;

                dataGridView1.DataSource = inventoryQuery.ToList();
            }


            
        }
    }
}
