/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/10/4
 * Time: PM 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace quirkpad {
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form {
        
        //a bunch of variables
        string filePath = "";
        bool saved = false;
        
        Styles styles = new Styles();
        string[] keywords = OptionsReader.GetKeywords();
        
        Font textFont = new Font(OptionsReader.GetFontOption(), OptionsReader.GetFontSize());
        
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
            
            styles.Links = Styles.LinkStyle;
            styles.Comment = Styles.Gray;
            styles.String = Styles.Purple;
            styles.Number = Styles.Green;
            styles.KeyWords = Styles.Orange;
            styles.SpecialKeyWords = Styles.Brown;
            styles.SpecialValues = Styles.Red;
            styles.Letters = Styles.Blue;
            
            saved = true;
        }
        
        private void InitStylesPriority() {           
            //add this style explicitly for drawing under other styles
            fctb.AddStyle(Styles.SameWords);
        }
        
        private void fctb_TextChanged(object sender, TextChangedEventArgs e) {
            statusLabel.Text = "Ready.";
            saved = false;
            Highlight(e);
        }

        private void Highlight(TextChangedEventArgs e) {            
            fctb.LeftBracket = '(';
            fctb.RightBracket = ')';
            fctb.LeftBracket2 = '{';
            fctb.RightBracket2 = '}';
            //clear style of changed range
            e.ChangedRange.ClearStyle(styles.Comment, styles.String, styles.Number, styles.KeyWords, styles.SpecialKeyWords, styles.SpecialValues, styles.Letters);

            //hyperlink highlighting
            e.ChangedRange.SetStyle(styles.Links, @"\bhttps?:\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?\b");
            //comment highlighting
            e.ChangedRange.SetStyle(styles.Comment, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(styles.Comment, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(styles.Comment, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline|RegexOptions.RightToLeft);
            //string highlighting
            e.ChangedRange.SetStyle(styles.String, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //number highlighting
            e.ChangedRange.SetStyle(styles.Number, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //keywords
            e.ChangedRange.SetStyle(styles.KeyWords, keywords[0]);
            //get and set deserve their own
            e.ChangedRange.SetStyle(styles.SpecialKeyWords, keywords[1]);
            //special values, such as true, false, null, and undefined
            e.ChangedRange.SetStyle(styles.SpecialValues, keywords[2]);
            //all other letters are blue
            e.ChangedRange.SetStyle(styles.Letters, @"\w");
        }

        private void fctb_SelectionChangedDelayed(object sender, EventArgs e) {
            fctb.VisibleRange.ClearStyle(Styles.SameWords);
            if (!fctb.Selection.IsEmpty)
                return;//user selected diapason

            //get fragment around caret
            var fragment = fctb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fctb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if(ranges.Length>1)
            foreach(var r in ranges)
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
                //
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
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{")) {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"\}[^""']*$")) {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:")) {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)")) {
                args.Shift = -args.TabLength / 2;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)")) {//operator is unclosed
                    args.Shift = args.TabLength;
                    return;
                }
        }

        private void fctb_CustomAction(object sender, CustomActionEventArgs e) {
            MessageBox.Show(e.Action.ToString());
        }
        
        //saving a new file
        void NewFile() {
            if (!saved) {
                WarnSave();
            }
            
            fctb.Text = "";
            filePath = "";
            
            Text = "New file - Quirkpad";
            
            saved = true;
            statusLabel.Text = "Ready.";
        }
        
        //opening a file
        void OpenFile() {
            statusLabel.Text = "Opening File...";
            openFileDialog.Filter = "Javascript files |*.js| All files |*.*";
            
            if (!saved) {
                WarnSave();
            }
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filePath = openFileDialog.FileName;
                //load the file
                fctb.OpenFile(filePath, new System.Text.UTF8Encoding());
                Text = Path.GetFileName(filePath) + " - Quirkpad";
                saved = true;
            }
            
            statusLabel.Text = "Ready.";
        }
        
        public void OpenFile_(string path) {
            filePath = path;
            
            //load
            fctb.OpenFile(path, new System.Text.UTF8Encoding());
            
            statusLabel.Text = "File opened.";
            saved = true;
            Text = Path.GetFileName(filePath) + " - Quirkpad";
        }
        
        //for saving files
        void SaveFile() {
            statusLabel.Text = "Saving...";
            
            //test if a file path exists
            if (filePath == "") {
                saveFileDialog.Filter = "Javascript files |*.js| All files | *.*";
            
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = saveFileDialog.FileName;
                } else {
                    statusLabel.Text = "File not saved.";
                    return;
                }
            }
            
            fctb.SaveToFile(filePath, new System.Text.UTF8Encoding());
            saved = true;
            
            statusLabel.Text = "File Saved.";
            this.Text = Path.GetFileName(filePath) + " - Quirkpad";
        }
        
        void WarnSave() {
            const string message = "Would you like to save your changes first?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            const string caption = "Save file first?";
            
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);
            
            if (result == System.Windows.Forms.DialogResult.Yes) {
                SaveFile();
            }
        }
        
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
            filePath = "";
            SaveFile();
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
        
        void Paste() {
            fctb.Paste();
        }
        
        void Cut() {
            fctb.Cut();
        }
        
        void Copy() {
            fctb.Copy();
        }
        
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
            hf.ShowDialog();
        }
        
        void HelpToolStripButtonClick(object s, EventArgs e) {
            new InfoForm().ShowDialog();
        }
        
        public Font GetFont() {
            return this.fctb.Font;
        }
        
        public void SetFont(Font f) {
            this.fctb.Font = f;
        }
        
        void ShowOptionsDialog() {
            OptionsForm optfrm = new OptionsForm(this);
            optfrm.ShowDialog();
        }
        
        void OptionsToolStripMenuItemClick(object sender, EventArgs e) {
            ShowOptionsDialog();
        }
        void SaveAsToolStripButtonClick(object sender, EventArgs e) {
            filePath = "";
            SaveFile();
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
            new InfoForm().ShowDialog();
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
    }
}
