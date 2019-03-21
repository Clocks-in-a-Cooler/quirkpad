using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Linq;

namespace quirkpad {
    
    /// <summary>
    /// Hightlights languages, because I like my own custom themes.
    /// </summary>
    public static class Highlighter {
        
        //patterns, for code readability.
        
        /// <summary>Regex pattern for single line comments (with the two forward slashes, <c>//</c>).</summary>
        /// <remarks>Use with <c>RegexOptions.Multiline.</c></remarks>
        public static string ForwardSlashCommentPattern = @"[^(https?:)""']///?.*$";
        
        /// <summary>Regex pattern for single line comments (with the hashtag, <c>#</c>).</summary>
        /// <remarks>Use with <c>RegexOptions.Multiline</c>.</remarks>
        public static string HashtagCommentPattern = @"[""']#.*$";
        
        /// <summary>Regex pattern for quotes (both single and double quotes)</summary>
        public static string StringPattern = @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'";
        
        /// <summary>Regex pattern for multiline comments <c>/*</c> and <c>*/</c>.</summary>
        /// <remarks>Use with <c>RegexOptions.Singleline</c>.</remarks>
        public static string MultilineCommentPattern1 = @"(/\*.*?\*/)|(/\*.*)";
        
        /// <summary>Regex pattern for multiline comments <c>/*</c> and <c>*/</c>.</summary>
        /// <remarks>Use with <c>RegexOptions.Singleline</c> and <c>RegexOptions.RightToLeft</c>.</remarks>
        public static string MultilineCommentPattern2 = @"(/\*.*?\*/)|(.*?\*/)";
        
        /// <summary>Regex pattern for hyperlinks.</summary>
        public static string HyperLinkPattern = @"\bhttps?:\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?\b";
        
        /// <summary>Regex pattern for numbers.</summary>
        public static string NumberPattern = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b";
        
        /// <summary>Regex pattern for HTML and CSS attributes.</summary>
        public static string AttributePattern = @"(\-?\w+)+";
        
        /// <summary>Regex pattern for CSS properties.</summary>
        public static string CSSPropertyPattern = @"(?<range>(\-?\w+?)+?)\s*:";
        
        /// <summary>Regex pattern for HTML escape characters.</summary>
        public static string HTMLEscapePattern = @"&.*?;";
        
        /// <summary>Regex pattern for <c>&lt;style&gt;</c> tags within HTML.</summary>
        public static string StyleTagPattern = @"<style[^>]*>(?<range>.*?)</style>";
        
        /// <summary>Regex pattern for <c>&lt;script&gt;</c> tags within HTML.</summary>
        public static string ScriptTagPattern = @"<script[^>]*>(?<range>.*?)</script>";
        
        /// <summary>
        /// method for highlighting
        /// </summary>
        /// <param name="r"> the range to highlight </param>
        /// <param name="ext"> the file extension, which identifies the language</param>
        public static void Highlight(Range r, string ext) {
            switch (ext.ToLower()) {
                //identify each language based on the file extension
                case ".cs":
                    H_CSharp(r);
                    break;
                case ".css":
                    H_CSS(r);
                    break;
                case ".html":
                case ".htm":
                    H_HTML(r);
                    break;
                case ".java":
                    H_Java(r);
                    break;
                case ".js":
                    H_Javascript(r);
                    break;
                case ".json":
                    H_JSON(r);
                    break;
                case ".md":
                case ".markdown":
                    H_Markdown(r);
                    break;
                case ".py":
                    H_Python(r);
                    break;
            }
        }
        
        //languages are arranged in alphabetical order
        
        /// <summary>
        /// highlights the given range according to c# syntax
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_CSharp(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //finish this
            
            //comments first!
            r.SetStyle(Styles.Gray, ForwardSlashCommentPattern, RegexOptions.Multiline);
            r.SetStyle(Styles.Gray, MultilineCommentPattern1, RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, MultilineCommentPattern2, RegexOptions.Singleline | RegexOptions.RightToLeft);
            
            //then strings
            r.SetStyle(Styles.Orange, StringPattern);
            
            //#region and #endregion tags
            r.SetStyle(Styles.DarkCyan, @"#region.*$", RegexOptions.Multiline);
            r.SetStyle(Styles.DarkCyan, @"#endregion.*$", RegexOptions.Multiline);
            
            //then numbers
            r.SetStyle(Styles.Red, NumberPattern);
            
            //then attributes
            r.SetStyle(Styles.Magenta, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            
            //then class names //\s+(?<range>\w+?)
            r.SetStyle(Styles.DarkGreen, @"\b(class|struct|enum|interface)\b");
            
            //then keywords
            r.SetStyle(Styles.DarkBlue, @"\b(abstract|as|base|break|case|catch|checked|const|continue|default|do|else|explicit|extern|finally|fixed|for|foreach|goto|if|implicit|in|internal|is|lock|namespace|new|object|operator|override|private|protected|public|readonly|ref|return|sealed|sizeof|stackalloc|static|switch|this|throw|try|typeof|unchecked|unsafe|using|virtual|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|where|yield)\b");
            
            //the primitive types
            r.SetStyle(Styles.Purple, @"\b(bool|byte|char|decimal|delegate|double|enum|event|float|int|interface|long|sbyte|short|string|uint|ulong|ushort|void|var|volatile)\b");
            
            //some special values
            r.SetStyle(Styles.Green, @"\b(true|false|null|undefined|params|out)\b");
            
            //the rest
            r.SetStyle(Styles.Blue, @"\w");
        }
        
        /// <summary>
        /// highlights the given range in css
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_CSS(Range r) {
            r.ClearStyle(Styles.AllStyles); //easily clear everything
            
            //highlight links first
            r.SetStyle(Styles.LinkStyle, HyperLinkPattern);
            
            //then highlight comments
            r.SetStyle(Styles.Gray, MultilineCommentPattern1, RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, MultilineCommentPattern2, RegexOptions.Singleline |  RegexOptions.RightToLeft);
            
            //then strings
            r.SetStyle(Styles.DarkCyan, StringPattern);
            
            //then colour codes
            r.SetStyle(Styles.Crimson, @"\#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})");
            
            //then numbers
            r.SetStyle(Styles.Green, @"\b\d+[\.]?\d*?(px|em|pt)?\b");
            r.SetStyle(Styles.Green, @"\b\d+\.?\d*?%?"); //percents
            
            //tags
            r.SetStyle(Styles.Orange, @"(?<range>(area|article|aside|a|blockquote|body|button|canvas|caption|code|col|details|div|form|p)).*\{");
            
            //names of html classes
            r.SetStyle(Styles.Blue, @"\." + AttributePattern + @"\b");
            
            //names of html ids
            r.SetStyle(Styles.Pink, @"\#" + AttributePattern + @"\b");
            
            //psuedoclasses
            r.SetStyle(Styles.Brown, @":\b(?<range>" + AttributePattern + @")\b");
            r.SetStyle(Styles.Brown, @"\[\b(?<range>" + AttributePattern + @")\b\]");
            
            //hairy part: properties and their values
            r.SetStyle(Styles.DarkYellow, CSSPropertyPattern);
            
            //match HTML colours, such as "white" and "mediumslateblue"
            r.SetStyle(Styles.Crimson, @"\b(AliceBlue|AntiqueWhite|Aqua|Aquamarine|Azure|Beige|Bisque|Black|BlanchedAlmond|Blue|BlueViolet|Brown|BurlyWood|CadetBlue|Chartreuse|Chocolate|Coral|CornflowerBlue|Cornsilk|Crimson|Cyan|DarkBlue|DarkCyan|DarkGoldenRod|DarkGray|DarkGrey|DarkGreen|DarkKhaki|DarkMagenta|DarkOliveGreen|DarkOrange|DarkOrchid|DarkRed|DarkSalmon|DarkSeaGreen|DarkSlateBlue|DarkSlateGray|DarkSlateGrey|DarkTurquoise|DarkViolet|DeepPink|DeepSkyBlue|DimGray|DimGrey|DodgerBlue|FireBrick|FloralWhite|ForestGreen|Fuchsia|Gainsboro|GhostWhite|Gold|GoldenRod|Gray|Grey|Green|GreenYellow|HoneyDew|HotPink|IndianRed|Indigo|Ivory|Khaki|Lavender|LavenderBlush|LawnGreen|LemonChiffon|LightBlue|LightCoral|LightCyan|LightGoldenRodYellow|MixLightGray|LightGrey|LightGreen|LightPink|LightSalmon|LightSeaGreen|LightSkyBlue|LightSlateGray|LightSlateGrey|LightSteelBlue|LightYellow|Lime|LimeGreen|Linen|Magenta|Maroon|MediumAquaMarine|MediumBlue|MediumOrchid|MediumPurple|MediumSeaGreen|MediumSlateBlue|MediumSpringGreen|MediumTurquoise|MediumVioletRed|MidnightBlue|MintCream|MistyRose|Moccasin|NavajoWhite|Navy|OldLace|Olive|OliveDrab|Orange|OrangeRed|Orchid|PaleGoldenRod|PaleGreen|PaleTurquoise|PaleVioletRed|PapayaWhip|PeachPuff|Peru|Pink|Plum|PowderBlue|Purple|RebeccaPurple|Red|RosyBrown|RoyalBlue|SaddleBrown|Salmon|SandyBrown|SeaGreen|SeaShell|Sienna|Silver|SkyBlue|SlateBlue|SlateGray|SlateGrey|Snow|SpringGreen|SteelBlue|Tan|Teal|Thistle|Tomato|Turquoise|Violet|Wheat|White|WhiteSmoke|Yellow|YellowGreen)\b", RegexOptions.IgnoreCase);
            
            //match values of those propeties
            r.SetStyle(Styles.Purple, AttributePattern);
        }
        
        /// <summary>
        /// highlights the given range in HTML.
        /// this method also gets all of the CSS (<c>&lt;style&gt;</c>) and JS (<c>&lt;script&gt;</c>) and highlights them accordingly.
        /// </summary>
        /// <param name="r">the range to be highlighted</param>
        static void H_HTML(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //comments first!
            r.SetStyle(Styles.Gray, @"<!--(\n|.)*?-->", RegexOptions.Multiline);
            
            //the <!DOCTYPE> tag at the top
            r.SetStyle(Styles.Yellow, @"<!DOCTYPE\s\w*?>");
            
            //tags
            foreach(Range ra in r.GetRanges(@"</?\b\w+?\b")) {
                ra.SetStyle(Styles.DarkGreen, @"\w");
            }
                        
            //the links!
            r.SetStyle(Styles.LinkStyle, HyperLinkPattern);
            
            //strings
            r.SetStyle(Styles.DarkCyan, StringPattern);
            
            //escape characters
            r.SetStyle(Styles.Crimson, HTMLEscapePattern);
            
            //get all the css
            foreach (Range ra in r.GetRanges(@"<style[^>]*>.*?</style>", RegexOptions.Singleline)) {
                foreach (Range range in ra.GetRanges(@">.*<", RegexOptions.Singleline)) {
                    H_CSS(range); //i've deliberately used the greedy operator
                }
            }
            
            //attributes
            foreach (Range ra in r.GetRanges(@"\w+\-?\=")) {
                ra.SetStyle(Styles.Blue, @"\w+\-?");
            }
            
            //gets all of the javascript
            foreach (Range ra in r.GetRanges(@"<script[^>]*>.*?</script>", RegexOptions.Singleline)) {
                foreach(Range range in ra.GetRanges(@">.*<", RegexOptions.Singleline)) {
                    H_Javascript(range); //there should only be one, anyway
                }
            }
            //still buggy
            
        }
        
        /// <summary>
        /// highlights the given range according to Java syntax
        /// </summary>
        /// <param name="r"></param>
        public static void H_Java(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //highlight comments
            r.SetStyle(Styles.Gray, ForwardSlashCommentPattern, RegexOptions.Multiline);
            r.SetStyle(Styles.Gray, MultilineCommentPattern1, RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, MultilineCommentPattern2, RegexOptions.Singleline | RegexOptions.RightToLeft);
            
            //strings
            r.SetStyle(Styles.Orange, StringPattern);
            
            //keywords
            r.SetStyle(Styles.DarkYellow, @"\b(abstract|assert|break|case|catch|class|const|continue|default|do|else|exports|extends|final|finally|for|goto|if|implements|interface|native|new|package|private|protected|public|requires|return|static|strictfp|super|switch|synchronized|this|throw|throws|transient|try|var|volatile|while)\b");
            
            //types
            r.SetStyle(Styles.Green, @"\b(boolean|byte|char|double|enum|float|int|long|module|short|void)\b");
            r.SetStyle(Styles.Green, @"\b[A-Z]\w*?\b");
            
            //methods, which are always followed by an opening parenthesis--such as "foo("
            //foreach(Range ra in r.GetRanges(@"\b\w+?\b\(")) {
            //    ra.SetStyle(Styles.DarkGreen, @"\w");
            //}
            r.SetStyle(Styles.DarkGreen, @"\b(?<range>\w+?)\(");
            
            //special words
            r.SetStyle(Styles.Brown, @"\b(package|import)\b");
            
            //numbers
            r.SetStyle(Styles.Red, NumberPattern);
            
            //special values
            r.SetStyle(Styles.Purple, @"\b(true|false|undefined|null)\b");
            
            //the rest in dark cyan
            r.SetStyle(Styles.DarkCyan, @"\w");
        }
        
        /// <summary>
        /// highlights the given range according to Javascript syntax
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_Javascript(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //highlight comments
            r.SetStyle(Styles.Gray, ForwardSlashCommentPattern, RegexOptions.Multiline);
            r.SetStyle(Styles.Gray, MultilineCommentPattern1, RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, MultilineCommentPattern2, RegexOptions.Singleline |  RegexOptions.RightToLeft);
        
            //string highlighting
            r.SetStyle(Styles.Purple, StringPattern);
            //number highlighting
            r.SetStyle(Styles.Green, NumberPattern);
            //keywords
            r.SetStyle(Styles.Orange, @"\b(break|case|catch|const|continue|default|delete|do|else|finally|for|function|if|import|in|instanceof|new|return|switch|this|throw|try|typeof|var|while|with|yield)\b");
            //get and set deserve their own
            r.SetStyle(Styles.Brown, @"\b(get|set|prototype)\b");
            //special values, such as true, false, null, and undefined
            r.SetStyle(Styles.Red, @"\b(null|undefined|NaN|Infinity|true|false)\b");
            //all other letters are blue
            r.SetStyle(Styles.Blue, @"\w");
        }
        
        /// <summary>
        /// hightlights the range in JSON.
        /// this is different from JS, because why not?
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_JSON(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //strings. what else?
            r.SetStyle(Styles.Crimson, StringPattern);
        }
        
        /// <summary>
        /// highlights the range according to Github's markdown syntax
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_Markdown(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //finish this
                      
            //italics and bold
            r.SetStyle(Styles.Purple, @"[\*|_]{1,2}.*?[\*|_]{1,2}");
            
            //block quotes
            r.SetStyle(Styles.Pink, @"^> .*$", RegexOptions.Multiline);
            
            //links
            r.SetStyle(Styles.LinkStyle, HyperLinkPattern);
            foreach(Range ra in r.GetRanges(@"\[.*\]")) {
                ra.SetStyle(Styles.LinkStyle, @"[^\[\]]");
            }
            
            // # for headers
            r.SetStyle(Styles.Magenta, @"#+ .*$", RegexOptions.Multiline);
            
            //escaped characters
            r.SetStyle(Styles.Crimson, HTMLEscapePattern);
            
            //code snippets
            foreach(Range ra in r.GetRanges(@"\`.*?\`")) {
                H_Javascript(ra);
            }
        }
        
        /// <summary>
        /// highlights the range according to Python syntax
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_Python(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //finish this
        }

        /// <summary>
        /// highlights the range in VB.
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_VB(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //comments
            
        }
        
        //
        // TODO: come up with some colour themes and finish the highlighting rules for more languages
        //
        
        //regex patterns for various brackets and braces below.
        public static string OpenBrace = @"^.*[^""'(\/\/)]*\{[^\}]*$";
        public static string CloseBrace = @"^[^\{""'(\/\/)]*\}.*$";
        public static string OpenTag = @"\<[^\/!]+\>";
        public static string CloseTag = @"\<\/.+\>";
        //TODO: add more patterns.
        
        ///<summary>does autoindenting</summary>
        public static void AutoIndent(object sender, AutoIndentEventArgs args) {
            if (Regex.IsMatch(args.LineText, OpenBrace) && Regex.IsMatch(args.LineText, CloseBrace)) {
                args.Shift = -args.TabLength;
                return;
            }
            
            if (Regex.IsMatch(args.LineText, OpenTag) && Regex.IsMatch(args.LineText, CloseTag)) {
                return;
            }
        
            if (Regex.IsMatch(args.LineText, OpenBrace) || Regex.IsMatch(args.LineText, OpenTag)) {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            
            if (Regex.IsMatch(args.LineText, CloseBrace) || Regex.IsMatch(args.LineText, CloseTag)) {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
        }
        
        //getting some brackets
        public static Bracket GetBrackets(string lang) {
            var b = new Bracket();
            switch (lang) {
                case ".cs":
                case ".java":
                case ".js":
                    b.Left1 = '(';
                    b.Right1 = ')';
                    goto case ".json";
                case ".css":
                case ".json":
                    b.Left2 = '{';
                    b.Right2 = '}';
                    break;
                case ".htm":
                case ".html":
                    b.Left1 = '<';
                    b.Right1 = '>';
                    break;
            }
            return b;
        }
    }
    
    //this is probably the worst way to do this
    public class Bracket {
        public char Left1;
        public char Right1;
        public char Left2;
        public char Right2;
        
        public Bracket() {
            Left1 = '\x0';
            Right1 = '\x0';
            Left2 = '\x0';
            Right2 = '\x0';
        }
        
        public Bracket(char left1, char right1, char left2, char right2) {
            Left1 = left1;
            Right1 = right1;
            Left2 = left2;
            Right2 = right2;
        }
    }
}