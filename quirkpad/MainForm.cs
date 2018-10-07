/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/10/4
 * Time: PM 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace quirkpad
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        string lang = "JS";
        string filePath = "";
        
        //styles
        TextStyle BrownStyle = new TextStyle(Brushes.Chocolate, null, FontStyle.Regular);
        TextStyle CyanStyle = new TextStyle(Brushes.DodgerBlue, null, FontStyle.Regular);
        TextStyle RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        TextStyle OrangeStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        TextStyle GrayStyle = new TextStyle(Brushes.LightSlateGray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.MediumOrchid, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.LimeGreen, null, FontStyle.Regular); 
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.LightSlateGray)));
        
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        private void InitStylesPriority()
        {           
            //add this style explicitly for drawing under other styles
            fctb.AddStyle(SameWordsStyle);
        }
        
        private void fctb_TextChanged(object sender, TextChangedEventArgs e) {
            switch (lang) {
                case "JS":
                    //For sample, we will highlight the syntax of C# manually, although could use built-in highlighter
                    JSHighlight(e);//custom highlighting
                    break;
                default:
                    break;//for highlighting of other languages, we using built-in FastColoredTextBox highlighter
            }

            if (fctb.Text.Trim().StartsWith("<?xml")) {
                fctb.Language = Language.XML;

                fctb.ClearStylesBuffer();
                fctb.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                fctb.AutoIndentNeeded -= fctb_AutoIndentNeeded;

                fctb.OnSyntaxHighlight(new TextChangedEventArgs(fctb.Range));
            }
        }   

        private void JSHighlight(TextChangedEventArgs e) {
            fctb.LeftBracket = '(';
            fctb.RightBracket = ')';
            fctb.LeftBracket2 = '{';
            fctb.RightBracket2 = '}';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BrownStyle, RedStyle, OrangeStyle, CyanStyle, GrayStyle, MagentaStyle, GreenStyle);

            //comment highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GrayStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GrayStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline|RegexOptions.RightToLeft);
            //string highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //number highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //keywords
            e.ChangedRange.SetStyle(OrangeStyle, @"\b(break|case|catch|class|const|continue|default|do|else|finally|for|function|goto|if|in|new|return|switch|this|throw|try|typeof|while|let|var|)\b");
            //get and set deserve their own
            e.ChangedRange.SetStyle(BrownStyle, @"\b(get|set)\b");
            //special values, such as true, false, null, and undefined
            e.ChangedRange.SetStyle(RedStyle, @"\b(true|false|null|undefined|Infinity|NaN|eval|prototype)\b");
            //all other letters are blue
            e.ChangedRange.SetStyle(CyanStyle, @"\w");
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e) {
            fctb.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e) {
            fctb.ShowReplaceDialog();
        }

        private void collapseSelectedBlockToolStripMenuItem_Click(object sender, EventArgs e) {
            fctb.CollapseBlock(fctb.Selection.Start.iLine, fctb.Selection.End.iLine);
        }

        private void exapndAllregionToolStripMenuItem_Click(object sender, EventArgs e) {
            //this example shows how to expand all #region blocks (C#)
            if (!lang.StartsWith("CSharp")) return;
            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
            {
                if (fctb[iLine].FoldingStartMarker == @"#region\b")//marker @"#region\b" was used in SetFoldingMarkers()
                    fctb.ExpandFoldedBlock(iLine);
            }
        }

        private void increaseIndentSiftTabToolStripMenuItem_Click(object sender, EventArgs e) {
            fctb.IncreaseIndent();
        }

        private void decreaseIndentTabToolStripMenuItem_Click(object sender, EventArgs e) {
            fctb.DecreaseIndent();
        }

        private void hTMLToolStripMenuItem1_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "HTML with <PRE> tag|*.html|HTML without <PRE> tag|*.html";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string html = "";

                if (sfd.FilterIndex == 1)
                {
                    html = fctb.Html;
                }
                if (sfd.FilterIndex == 2)
                {
                    
                    ExportToHTML exporter = new ExportToHTML();
                    exporter.UseBr = true;
                    exporter.UseNbsp = false;
                    exporter.UseForwardNbsp = true;
                    exporter.UseStyleTag = true;
                    html = exporter.GetHtml(fctb);
                }
                File.WriteAllText(sfd.FileName, html);
            }
        }

        private void fctb_SelectionChangedDelayed(object sender, EventArgs e)
        {
            fctb.VisibleRange.ClearStyle(SameWordsStyle);
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
                r.SetStyle(SameWordsStyle);
        }

        private void goForwardCtrlShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.NavigateForward();
        }

        private void goBackwardCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.NavigateBackward();
        }

        private void autoIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.DoAutoIndent();
        }

        const int maxBracketSearchIterations = 2000;

        void GoLeftBracket(FastColoredTextBox tb, char leftBracket, char rightBracket)
        {
            Range range = tb.Selection.Clone();//need to clone because we will move caret
            int counter = 0;
            int maxIterations = maxBracketSearchIterations;
            while (range.GoLeftThroughFolded())//move caret left
            {
                if (range.CharAfterStart == leftBracket) counter++;
                if (range.CharAfterStart == rightBracket) counter--;
                if (counter == 1)
                {
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

        void GoRightBracket(FastColoredTextBox tb, char leftBracket, char rightBracket)
        {
            var range = tb.Selection.Clone();//need clone because we will move caret
            int counter = 0;
            int maxIterations = maxBracketSearchIterations;
            do
            {
                if (range.CharAfterStart == leftBracket) counter++;
                if (range.CharAfterStart == rightBracket) counter--;
                if (counter == -1)
                {
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

        private void goLeftBracketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoLeftBracket(fctb, '{', '}');
        }

        private void goRightBracketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoRightBracket(fctb, '{', '}');
        }

        private void fctb_AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)"))//operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }

        Random rnd = new Random();

        private void setSelectedAsReadonlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Selection.ReadOnly = true;
        }

        private void setSelectedAsWritableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Selection.ReadOnly = false;
        }

        private void changeHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HotkeysEditorForm(fctb.HotkeysMapping);
            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                fctb.HotkeysMapping = form.GetHotkeys();
        }

        private void rTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RTF|*.rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string rtf = fctb.Rtf;
                File.WriteAllText(sfd.FileName, rtf);
            }
        }

        private void fctb_CustomAction(object sender, CustomActionEventArgs e)
        {
            MessageBox.Show(e.Action.ToString());
        }

        private void commentSelectedLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.InsertLinePrefix(fctb.CommentPrefix);
        }

        private void uncommentSelectedLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.RemoveLinePrefix(fctb.CommentPrefix);
        }
        
        //making a new file
        void NewFile() {
            fctb.Text = "";
            
            statusLabel.Text = "Ready.";
        }
        
        //opening a file
        void OpenFile() {
            statusLabel.Text = "Opening File...";
            openFileDialog.Filter = "Javascript files |*.js| All files |*.*";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filePath = openFileDialog.FileName;
                //load the file
                fctb.OpenFile(filePath, new System.Text.UTF8Encoding());
            }
            
            statusLabel.Text = "Ready.";
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
                    statusLabel.Text = "Ready.";
                    return;
                }
            }
            
            fctb.SaveToFile(filePath, new System.Text.UTF8Encoding());
            
            statusLabel.Text = "Ready.";
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
    }
}
