using FastColoredTextBoxNS;
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
        public static void Hightlight(Range r, string ext) {
            switch (ext.ToLower()) {
                //identify each language based on the file extension
                case (".css"):
                    H_CSS(r);
                    break;
                case (".js"):
                    H_JS(r);
                    break;
                case (".json"):
                    H_JSON(r);
                    break;
            }
        }
        
        /// <summary>
        /// highlights css
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_CSS(Range r) {
            r.ClearStyle(Styles.AllStyles); //easily clear everything
            
            //highlight links first
            r.SetStyle(Styles.LinkStyle, @"\bhttps?:\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?\b");
            
            //then highlight comments
            //r.SetStyle(Styles.Gray, @"//.*$", RegexOptions.Multiline);
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            r.SetStyle(Styles.Gray, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline |  RegexOptions.RightToLeft);
            
            //names of certain tag names
            r.SetStyle(Styles.Orange, @"\b(html|body|div|p|span|form|button)\b");
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
            
        }

        /// <summary>
        /// highlights the range in VB.
        /// </summary>
        /// <param name="r">the range to highlight</param>
        static void H_VB(Range r) {
            
        }
        
        //
        // TODO: come up with some colour themes!
        //
    }
}