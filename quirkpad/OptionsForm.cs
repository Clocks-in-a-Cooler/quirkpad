/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/11/23
 * Time: PM 6:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace quirkpad {
    /// <summary>
    /// Description of OptionsForm.
    /// </summary>
    
    public partial class OptionsForm : Form {
        MainForm mnfrm;
        public OptionsForm(MainForm mf) {
            mnfrm = mf;
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void ChooseFontClick(object sender, EventArgs e) {
            fontDialog.Font = mnfrm.GetFont();
            
            if(fontDialog.ShowDialog() != DialogResult.Cancel ) {
                mnfrm.SetFont(fontDialog.Font);
            }
        }
        void OkButtonClick(object sender, EventArgs e) {
            this.Close();
        }
    }
}
