///Title:   InputBox.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Input Box pop up for BShop windows form
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BShop_Management
{
    public partial class InputBox : Form
    {
        private string _Answer;

        public string Answer
        {
            get { return _Answer; }
        }

        public InputBox(string question, List<string> options)
        {
            InitializeComponent();
            lblQuestion.Text = question;
            lblError.Text = "";
            comboBoxAnswer.DataSource = null;
            comboBoxAnswer.DataSource = options;
            comboBoxAnswer.Focus();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _Answer = comboBoxAnswer.SelectedValue as string;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
