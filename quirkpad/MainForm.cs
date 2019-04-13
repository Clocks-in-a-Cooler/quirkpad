using System;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.IO;
using System.Linq;

namespace quirkpad {
    /// <summary>
    /// The main window of the application.
    /// </summary>
    public partial class MainForm : Form {
        
        //a bunch of variables
        string filePath = "";
        bool saved = false;
        string lang = ".txt";
        
        Styles styles = new Styles();
        
        Font textFont = new Font(OptionsReader.FontFamily, OptionsReader.FontSize);
        
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            
            fctb.Font = textFont;
                        
            fctb.CurrentLineColor = Color.FromArgb(30, Color.LightSeaGreen);
            
            OptionsReader.GetHighlightOption();
            
            saved = true;
        }
        
        #region code        
        private void InitStylesPriority() {           
            //add this style explicitly for drawing under other styles
            fctb.AddStyle(Styles.SameWords);
        }
        
        private void fctb_TextChanged(object sender, TextChangedEventArgs e) {
            statusLabel.Text = "Ready.";
            saved = false;

            //set left and right brackets
            fctb.LeftBracket = Highlighter.GetBrackets(lang).Left1;
            fctb.RightBracket = Highlighter.GetBrackets(lang).Right1;
            fctb.LeftBracket2 = Highlighter.GetBrackets(lang).Left2;
            fctb.RightBracket2 = Highlighter.GetBrackets(lang).Right2;
            
            Range highlightRange;
            switch (OptionsReader.HighlightOption) {
                case "all":
                    highlightRange = fctb.Range;
                    break;
                case "visible":
                    highlightRange = fctb.VisibleRange;
                    break;
                case "changed":
                    highlightRange = e.ChangedRange;
                    break;
                default:
                    highlightRange = fctb.Range;
                    break;
            }
            
            Highlighter.Highlight(highlightRange, lang);
        }
        
        private void fctb_SelectionChangedDelayed(object sender, EventArgs e) {
            fctb.VisibleRange.ClearStyle(Styles.SameWords);
            if (!fctb.Selection.IsEmpty)
                return; //user selected diapason

            //get fragment around caret
            var fragment = fctb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fctb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if (ranges.Length > 1)
            foreach (var r in ranges)
                r.SetStyle(Styles.SameWords);
        }

        const int maxBracketSearchIterations = 2000;

        void GoLeftBracket(FastColoredTextBox tb, char leftBracket, char rightBracket) {
            Range range = tb.Selection.Clone();//need to clone because we will move caret
            int counter = 0;
            int maxIterations = maxBracketSearchIterations;
            while (range.GoLeftThroughFolded()) {//move caret left
                if (range.CharAfterStart == leftBracket) counter++;
                if (range.CharAfterStart == rightBracket) counter--;
                if (counter == 1) {
                    //found
                    tb.Selection.Start = range.Start;
                    tb.DoSelectionVisible();
                    break;
                }
                maxIterations--;
                if (maxIterations <= 0) break;
            }
            tb.Invalidate();
        }

        void GoRightBracket(FastColoredTextBox tb, char leftBracket, char rightBracket) {
            var range = tb.Selection.Clone();//need clone because we will move caret
            int counter = 0;
            int maxIterations = maxBracketSearchIterations;
            do {
                if (range.CharAfterStart == leftBracket) counter++;
                if (range.CharAfterStart == rightBracket) counter--;
                if (counter == -1) {
                    //found
                    tb.Selection.Start = range.Start;
                    tb.Selection.GoRightThroughFolded();
                    tb.DoSelectionVisible();
                    break;
                }
                //
                maxIterations--;
                if (maxIterations <= 0) break;
            } while (range.GoRightThroughFolded());//move caret right

            tb.Invalidate();
        }

        private void fctb_AutoIndentNeeded(object sender, AutoIndentEventArgs args) {
            Highlighter.AutoIndent(sender, args);
        }

        private void fctb_CustomAction(object sender, CustomActionEventArgs e) {
            MessageBox.Show(e.Action.ToString());
        }
        #endregion
        #region new, open, save, save as
        //saving a new file
        void NewFile() {
            if (!saved) {
                WarnSave();
            }
            
            fctb.Text = "";
            filePath = "";
            lang = ".txt"; //default language: text
            
            Text = "New file - Quirkpad";
            
            saved = true;
            statusLabel.Text = "Ready.";
        }
        
        //opening a file
        void OpenFile() {
            statusLabel.Text = "Opening File...";
            openFileDialog.Filter = "All files|*.*";
            
            if (!saved) {
                WarnSave();
            }
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filePath = openFileDialog.FileName;
                
                //update the language
                lang = Path.GetExtension(filePath);
                
                //load the file
                fctb.OpenFile(filePath, new System.Text.UTF8Encoding());
                Text = Path.GetFileName(filePath) + " - Quirkpad";
                saved = true;
                
                Highlighter.Highlight(fctb.Range, lang);
            }
            
            statusLabel.Text = "Ready.";
        }
        
        public void OpenFile_(string path) {
            filePath = path;
            
            lang = Path.GetExtension(filePath);
            
            //load
            fctb.OpenFile(path, new System.Text.UTF8Encoding());
            
            statusLabel.Text = "File opened.";
            saved = true;
            this.Text = Path.GetFileName(filePath) + " - Quirkpad";
            
            Highlighter.Highlight(fctb.Range, lang);
        }
        
        //for saving files
        void SaveFile() {
            statusLabel.Text = "Saving...";
            
            //test if a file path exists
            if (filePath == "") {
                saveFileDialog.Filter = "Source code files |*" + lang + "| All files | *.*";
            
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = saveFileDialog.FileName;
                } else {
                    statusLabel.Text = "File not saved.";
                    return;
                }
            }
            
            lang = Path.GetExtension(filePath);
            
            fctb.SaveToFile(filePath, new System.Text.UTF8Encoding());
            saved = true;
            
            statusLabel.Text = "File Saved.";
            this.Text = Path.GetFileName(filePath) + " - Quirkpad";
            Highlighter.Highlight(fctb.Range, lang);
        }
        
        void WarnSave() {
            const string message = "Would you like to save your changes first?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            const string caption = "Save your changes first?";
            
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);
            
            if (result == System.Windows.Forms.DialogResult.Yes) {
                SaveFile();
            }
        }
        
        void SaveAs() {
            //a bit more involved. can't reuse SaveFile().
            statusLabel.Text = "Saving file...";
            saveFileDialog.Filter = "Source code files |*" + lang + "| All Files |*.*";
            
            DialogResult result = saveFileDialog.ShowDialog();
            
            if (result == DialogResult.OK) {
                filePath = saveFileDialog.FileName;
                
                //update the language first.
                lang = Path.GetExtension(filePath);
                
                saved = true;
                fctb.SaveToFile(filePath, new System.Text.UTF8Encoding());
                statusLabel.Text = "File saved.";
                this.Text = Path.GetFileName(filePath) + " - Quirkpad";
                Highlighter.Highlight(fctb.Range, lang);
            } else if (result == DialogResult.Cancel || result == DialogResult.Abort) {
                statusLabel.Text = "File not saved at a new location.";
            }
        }
        #endregion
        #region copy, past, and cut
        void Paste() {
            fctb.Paste();
        }
        
        void Cut() {
            fctb.Cut();
        }
        
        void Copy() {
            fctb.Copy();
        }
        #endregion
        #region event listeners
        void SaveToolStripButtonClick(object sender, EventArgs e) {
            SaveFile();
        }
        
        void NewToolStripButtonClick(object sender, EventArgs e) {
            NewFile();
        }
        void OpenToolStripButtonClick(object sender, EventArgs e) {
            OpenFile();
        }
        void SaveAsToolStripMenuItemClick(object sender, EventArgs e) {
            SaveAs();
        }
        void NewToolStripMenuItemClick(object sender, EventArgs e) {
            NewFile();
        }
        void SaveToolStripMenuItemClick(object sender, EventArgs e) {
            SaveFile();
        }
        void OpenToolStripMenuItemClick(object sender, EventArgs e) {
            OpenFile();
        }
        void ExitToolStripMenuItemClick(object sender, EventArgs e) {
            Application.Exit();
        }
        
        void FctbLoad(object sender, EventArgs e) { }
        
        void CutToolStripMenuItemClick(object sender, EventArgs e) {
            Cut();
        }
        
        void CopyToolStripMenuItemClick(object sender, EventArgs e) {
            Copy();
        }
        
        void PasteToolStripMenuItemClick(object sender, EventArgs e) {
            Paste();
        }
        
        void CutToolStripButtonClick(object sender, EventArgs e) {
            Cut();
        }
        
        void CopyToolStripButtonClick(object sender, EventArgs e) {
            Copy();
        }
        
        void PasteToolStripButtonClick(object sender, EventArgs e) {
            Paste();
        }
        
        //about window opens
        void AboutToolStripMenuItemClick(object sender, EventArgs e) {
            HelpForm hf = new HelpForm();
            hf.StartPosition = FormStartPosition.CenterParent;
            hf.ShowDialog(this);
        }
        
        void HelpToolStripButtonClick(object s, EventArgs e) {
            InfoForm info = new InfoForm();
            info.StartPosition = FormStartPosition.CenterParent;
            info.ShowDialog(this);
        }
        #endregion
        
        public Font GetFont() {
            return fctb.Font;
        }
        
        public void SetFont(Font f) {
            fctb.Font = f;
        }
        
        void ShowOptionsDialog() {
            OptionsForm optfrm = new OptionsForm(this);
            optfrm.StartPosition = FormStartPosition.CenterParent;
            optfrm.ShowDialog(this);
        }
        
        void OptionsToolStripMenuItemClick(object sender, EventArgs e) {
            ShowOptionsDialog();
        }
        
        void SaveAsToolStripButtonClick(object sender, EventArgs e) {
            SaveAs();
        }
        
        void FindToolStripMenuItemClick(object sender, EventArgs e) {
            fctb.ShowFindDialog();
        }
        
        void FindAndReplaceToolStripMenuItemClick(object sender, EventArgs e) {
            fctb.ShowReplaceDialog();
        }
        
        void UndoToolStripMenuItemClick(object sender, EventArgs e) {
            if (fctb.UndoEnabled) fctb.Undo();
        }
        
        void RedoToolStripMenuItemClick(object sender, EventArgs e) {
            if (fctb.RedoEnabled) fctb.Redo();
        }
        
        void HelpToolStripMenuItem1Click(object sender, EventArgs e) {
            InfoForm info = new InfoForm();
            info.StartPosition = FormStartPosition.CenterParent;
            info.ShowDialog(this);
        }
        
        void UndoToolStripButtonClick(object sender, EventArgs e) {
            if (fctb.UndoEnabled) fctb.Undo();
        }
        
        void RedoToolStripButtonClick(object sender, EventArgs e) {
            if (fctb.RedoEnabled) fctb.Redo();
        }
        
        void SelectAllToolStripMenuItemClick(object sender, EventArgs e) {
            fctb.SelectAll();
        }
        
        void OpenFolderToolStripMenuItemClick(object sender, EventArgs e) {
            string arg = "/Select, " + "\"" + filePath + "\"";
            System.Diagnostics.Process.Start("explorer.exe", arg);
        }
        
        void IncreaseIndentMenuItemClick(object sender, EventArgs e) {
            fctb.IncreaseIndent();
        }
        
        void DecreaseIndentMenuItemClick(object sender, EventArgs e) {
            fctb.DecreaseIndent();
        }
    }
}
