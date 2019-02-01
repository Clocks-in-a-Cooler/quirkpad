﻿using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Linq;

namespace quirkpad {
    
    /// <summary>
    /// Hightlights languages that FCTB doesn't support
    /// </summary>
    public static class Highlighter {
        
        /// <summary>
        /// method for highlighting
        /// </summary>
        /// <param name="r"> the range to highlight </param>
        /// <param name="ext"> the file extension, which identifies the language</param>
        public static void Highlight(Range r, string ext) {
            switch (ext.ToLower()) {
                //identify each language based on the file extension
                case ".css":
                    H_CSS(r);
                    break;
                case ".html":
                case ".htm":
                    H_HTML(r);
                    break;
                case ".java":
                    H_JAVA(r);
                    break;
                case ".js":
                    H_JS(r);
                    break;
                case ".json":
                    H_JSON(r);
                    break;
            }
        }
        
        //languages are arranged in alphabetical order
        
        /// <summary>
        /// highlights the given range in css
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_CSS(Range r) {
            r.ClearStyle(Styles.AllStyles); //easily clear everything
            
            //highlight links first
            r.SetStyle(Styles.LinkStyle, @"\bhttps?:\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?\b");
            
            //then highlight comments
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline |  RegexOptions.RightToLeft);
            
            //then strings
            r.SetStyle(Styles.DarkCyan, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            
            //then colour codes
            r.SetStyle(Styles.Crimson, @"#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})");
            
            //then numbers
            r.SetStyle(Styles.Green, @"\b\d+[\.]?\d*?(px|em|pt)?\b");
            r.SetStyle(Styles.Green, @"\b\d+\.?\d*?%?"); //percents
            
            //names of certain tag names
            r.SetStyle(Styles.Orange, @"\b(html|body|div|p|span|form|button)\b");
            
            //names of html classes
            r.SetStyle(Styles.Blue, @"\.\w+?\b");
            
            //names of html ids
            r.SetStyle(Styles.Pink, @"\#\w+?\b");
            
            //psuedoclasses
            foreach(Range ra in r.GetRanges(@":\b(\w*-?)+?\b")) {
                ra.SetStyle(Styles.Brown, @"\b(\w*-?)+\b");
            }
            
            foreach(Range ra in r.GetRanges(@"\[\b(\w*-?)+?\b\]")) {
                ra.SetStyle(Styles.Brown, @"\b(\w*-?)+?\b");
            }
            
            //hairy part: properties and their values
            foreach(Range ra in r.GetRanges(@"\b(\w*-?)+?\b:")) {
                ra.SetStyle(Styles.DarkYellow, @"\b(\w*-?)+?\b");
            }
            
            //match HTML colours, such as "white" and "mediumslateblue"
            r.SetStyle(Styles.Crimson, @"\b(AliceBlue|AntiqueWhite|Aqua|Aquamarine|Azure|Beige|Bisque|Black|BlanchedAlmond|Blue|BlueViolet|Brown|BurlyWood|CadetBlue|Chartreuse|Chocolate|Coral|CornflowerBlue|Cornsilk|Crimson|Cyan|DarkBlue|DarkCyan|DarkGoldenRod|DarkGray|DarkGrey|DarkGreen|DarkKhaki|DarkMagenta|DarkOliveGreen|DarkOrange|DarkOrchid|DarkRed|DarkSalmon|DarkSeaGreen|DarkSlateBlue|DarkSlateGray|DarkSlateGrey|DarkTurquoise|DarkViolet|DeepPink|DeepSkyBlue|DimGray|DimGrey|DodgerBlue|FireBrick|FloralWhite|ForestGreen|Fuchsia|Gainsboro|GhostWhite|Gold|GoldenRod|Gray|Grey|Green|GreenYellow|HoneyDew|HotPink|IndianRed|Indigo|Ivory|Khaki|Lavender|LavenderBlush|LawnGreen|LemonChiffon|LightBlue|LightCoral|LightCyan|LightGoldenRodYellow|MixLightGray|LightGrey|LightGreen|LightPink|LightSalmon|LightSeaGreen|LightSkyBlue|LightSlateGray|LightSlateGrey|LightSteelBlue|LightYellow|Lime|LimeGreen|Linen|Magenta|Maroon|MediumAquaMarine|MediumBlue|MediumOrchid|MediumPurple|MediumSeaGreen|MediumSlateBlue|MediumSpringGreen|MediumTurquoise|MediumVioletRed|MidnightBlue|MintCream|MistyRose|Moccasin|NavajoWhite|Navy|OldLace|Olive|OliveDrab|Orange|OrangeRed|Orchid|PaleGoldenRod|PaleGreen|PaleTurquoise|PaleVioletRed|PapayaWhip|PeachPuff|Peru|Pink|Plum|PowderBlue|Purple|RebeccaPurple|Red|RosyBrown|RoyalBlue|SaddleBrown|Salmon|SandyBrown|SeaGreen|SeaShell|Sienna|Silver|SkyBlue|SlateBlue|SlateGray|SlateGrey|Snow|SpringGreen|SteelBlue|Tan|Teal|Thistle|Tomato|Turquoise|Violet|Wheat|White|WhiteSmoke|Yellow|YellowGreen)\b", RegexOptions.IgnoreCase);
            
            //match values of those propeties
            r.SetStyle(Styles.Purple, @"\b(\w*-?)+?\b");
        }
        
        /// <summary>
        /// highlights the given range in HTML.
        /// this method also gets all of the CSS (<c>&lt;style&gt;</c>) and JS (<c>&lt;script&gt;</c>) and highlights them accordingly.
        /// </summary>
        /// <param name="r">the range to be highlighted</param>
        static void H_HTML(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //get all the css
            Range[] cssRanges = r.GetRanges(@"<style [^>]*>(.*?)</style>", RegexOptions.Multiline).ToArray();
            foreach (Range ra in cssRanges) {
                H_CSS(ra); //highlight each range
            }
            
            //gets all of the javascript
            Range[] jsRanges  = r.GetRanges(@"<script [^>]*>(.*?)</script>", RegexOptions.Multiline).ToArray();
            foreach (Range ra in jsRanges) {
                H_JS(ra); //hightlight each range
            }
        }
        
        /// <summary>
        /// highlights the given range according to Java syntax
        /// </summary>
        /// <param name="r"></param>
        public static void H_JAVA(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //highlight comments
            r.SetStyle(Styles.Gray, @"//.*$", RegexOptions.Multiline);
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline |  RegexOptions.RightToLeft);
            
            //strings
            r.SetStyle(Styles.Orange, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            
            //keywords
            r.SetStyle(Styles.DarkYellow, @"\b(abstract|assert|break|case|catch|class|const|continue|default|do|else|exports|extends|final|finally|for|goto|if|implements|interface|native|new|package|private|protected|public|requires|return|static|strictfp|super|switch|synchronized|this|throw|throws|transient|try|var|volatile|while)\b");
            
            //types
            r.SetStyle(Styles.Green, @"\b(boolean|byte|char|double|enum|float|int|long|module|short|void)\b");
//            foreach (Range found in r.GetRanges(@"\b[A-Z]\w*?\b")) { //matches anything beginning with a capital letter, good chance it's a class or type
//                r.SetStyle(Styles.Green, @"\b" + found.Text + @"\b");
//            }

            r.SetStyle(Styles.Green, @"\b[A-Z]\w*?\b");
            
            //special words
            r.SetStyle(Styles.Brown, @"\b(package|import)\b");
            
            //numbers
            r.SetStyle(Styles.Red, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            
            //special values
            r.SetStyle(Styles.Purple, @"\b(true|false|undefined|null)\b");
            
            //the rest in dark yellow
            r.SetStyle(Styles.DarkCyan, @"\w");
        }
        
        /// <summary>
        /// highlights the given range according to Javascript syntax
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_JS(Range r) {
            r.ClearStyle(Styles.AllStyles);
            
            //highlight comments
            r.SetStyle(Styles.Gray, @"//.*$", RegexOptions.Multiline);
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline |  RegexOptions.RightToLeft);
        
            //string highlighting
            r.SetStyle(Styles.Purple, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //number highlighting
            r.SetStyle(Styles.Green, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //keywords
            r.SetStyle(Styles.Orange, @"\b(break|case|catch|const|continue|default|delete|do|else|finally|for|function|if|import|in|instanceof|new|return|switch|this|throw|try|typeof|var|while|with|yield
)\b");
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
    }
}