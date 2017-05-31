using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_Shop
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
