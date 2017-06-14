///Title:   pgPopup.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: IPop up for BShop windows formusing System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BShop_Management
{
    public partial class pgPopup : Form
    {
        public pgPopup(string prMessage)
        {
            InitializeComponent();
            lblMessage.Text = prMessage;
            ShowDialog();
        }
    }
}
