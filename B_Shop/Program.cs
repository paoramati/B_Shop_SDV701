///Title:   Program.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Main program for BShop windows forms program
using System;
using System.Windows.Forms;

namespace BShop_Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(frmMain.Instance);
        }
    }
}
