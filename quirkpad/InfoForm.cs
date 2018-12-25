/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/12/24
 * Time: PM 8:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace quirkpad
{
    /// <summary>
    /// a small info window that pops up. hopefully you learn visually.
    /// </summary>
    public partial class InfoForm : Form {
        public InfoForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void GithubLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
           System.Diagnostics.Process.Start("https://github.com/clocks-in-a-cooler/quirkpad");
        }
        
        void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
           System.Diagnostics.Process.Start("https://github.com/clocks-in-a-cooler/quirkpad/issues");
        }       
        
    }
}
