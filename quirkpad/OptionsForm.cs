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
        const string changedDescription = "Highlights only what text has changed.\nThis option offers the best performance, but multiline won't highlight properly.";
        
        public OptionsForm(MainForm mf) {
            mnfrm = mf;
            
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            
            fontLabel2.Font = new Font(OptionsReader.FontFamily, OptionsReader.FontSize);
            fontLabel2.Text = OptionsReader.FontFamily;
            
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
            
            switch (OptionsReader.Theme) {
                case "dark":
                    darkThemeRadioButton.Checked = true;
                    break;
                case "light":
                    lightThemeRadioButton.Checked = true;
                    break;
                default:
                    lightThemeRadioButton.Checked = true;
                    break;
            }
        }
        
        void ChooseFontClick(object sender, EventArgs e) {
            fontDialog.Font = mnfrm.GetFont();
            
            if (fontDialog.ShowDialog() != DialogResult.Cancel ) {
                mnfrm.SetFont(fontDialog.Font);
                OptionsReader.FontFamily = fontDialog.Font.FontFamily.Name;
                OptionsReader.FontSize = fontDialog.Font.Size;
                
                fontLabel2.Font = new Font(OptionsReader.FontFamily, OptionsReader.FontSize);
                fontLabel2.Text = OptionsReader.FontFamily;
            }
        }
        
        void LightThemeRadioButtonCheckedChanged(object sender, EventArgs e) {
            OptionsReader.Theme = "light";
            mnfrm.ApplyTheme("light");
        }
        
        void DarkThemeRadioButtonCheckedChanged(object sender, EventArgs e) {
            OptionsReader.Theme = "dark";
            mnfrm.ApplyTheme("dark");
        }
        
        void OkButtonClick(object sender, EventArgs e) {            
            Close();
        }
        
        void AllRadioButtonCheckedChanged(object sender, EventArgs e) {
            OptionsReader.SetHighlightOption("all");
            highlightRangeLabel.Text = allDescription;
        }
        
        void VisibleRadioButtonCheckedChanged(object sender, EventArgs e) {
            OptionsReader.SetHighlightOption("visible");
            highlightRangeLabel.Text = visibleDescription;
        }
        
        void ChangedRadioButtonCheckedChanged(object sender, EventArgs e) {
            OptionsReader.SetHighlightOption("changed");
            highlightRangeLabel.Text = changedDescription;
        }
    }
}
