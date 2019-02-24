/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/11/23
 * Time: PM 5:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace quirkpad
{
    /// <summary>
    /// Description of HelpForm.
    /// </summary>
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            
            pathLabel.Text = OptionsReader.GetOptionsFilePath();
        }
        
        void FCTBLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/PavelTorgashov/FastColoredTextBox");
        }
        
        void MITLicenseLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://choosealicense.com/licenses/mit/");
        }
        
        void LGPLLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://choosealicense.com/licenses/lgpl-3.0/");
        }
        
        void SnippetCompilerLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://web.archive.org/web/20140110233726/http://www.sliver.com/dotnet/snippetcompiler/");
        }
    }
}
