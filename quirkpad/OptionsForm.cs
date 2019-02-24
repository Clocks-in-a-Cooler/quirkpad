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
        
        const string allDescription = "Highlights all of the text in the current document.\nThis option offers the most accurate highlighting, but at the cost of performance.";
        const string visibleDescription = "Highlights only what's currently visible in the window.";
        const string changedDescription = "Highlights only what text has changed.\nThis option offers the best performance, but won't highlight multiline comments properly.";
        
        public OptionsForm(MainForm mf) {
            mnfrm = mf;
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            
            fontLabel2.Font = new Font(OptionsReader.GetFontOption(), OptionsReader.GetFontSize());
            fontLabel2.Text = OptionsReader.GetFontOption();
            
            switch (OptionsReader.HighlightOption) {
                case "all":
                    allRadioButton.Checked = true;
                    highlightRangeLabel.Text = allDescription;
                    break;
                case "visible":
                    visibleRadioButton.Checked = true;
                    highlightRangeLabel.Text = visibleDescription;
                    break;
                case "changed":
                    changedRadioButton.Checked = true;
                    highlightRangeLabel.Text = changedDescription;
                    break;
                default:
                    allRadioButton.Checked = true;
                    highlightRangeLabel.Text = allDescription;
                    break;
            }
        }
        
        void ChooseFontClick(object sender, EventArgs e) {
            fontDialog.Font = mnfrm.GetFont();
            
            if (fontDialog.ShowDialog() != DialogResult.Cancel ) {
                mnfrm.SetFont(fontDialog.Font);
                OptionsReader.SetFontOption(fontDialog.Font.FontFamily.Name);
                OptionsReader.SetFontSize(fontDialog.Font.Size);
                
                fontLabel2.Font = new Font(OptionsReader.GetFontOption(), OptionsReader.GetFontSize());
                fontLabel2.Text = OptionsReader.GetFontOption();
            }
        }
        
        void RadioButtonCheckChanged(object sender, EventArgs e) {
            if (sender is RadioButton) {
                RadioButton rb = (RadioButton) sender;
                
                if (rb == allRadioButton) {
                    OptionsReader.SetHighlightOption("all");
                    highlightRangeLabel.Text = allDescription;
                }
                
                if (rb == visibleRadioButton) {
                    OptionsReader.SetHighlightOption("visible");
                    highlightRangeLabel.Text = visibleDescription;
                }
                
                if (rb == changedRadioButton) {
                    OptionsReader.SetHighlightOption("changed");
                    highlightRangeLabel.Text = changedDescription;
                }
            }
        }
        
        void OkButtonClick(object sender, EventArgs e) {            
            Close();
        }
    }
}
