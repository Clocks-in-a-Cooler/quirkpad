/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/11/23
 * Time: PM 8:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FastColoredTextBoxNS;

namespace quirkpad
{
    /// <summary>
    /// Description of Language.
    /// </summary>
    public class Language {
        public string keywords;
        public string specialValues;
        public string specialWords;
        
        public static TextStyle commentStyle = Styles.Gray;
        public static TextStyle stringStyle = Styles.Purple;
        public static TextStyle numberStyle = Styles.Green;
        public static TextStyle keywordStyle = Styles.Orange;
        public static TextStyle specialWordsStyle = Styles.Brown;
        public static TextStyle specialValuesStyle = Styles.Red;
        public static TextStyle lettersStyle = Styles.Blue;
        
        public Language(string[] keywords, string[] specialValues, string[] specialWords) {
            this.keywords = @"\b(" + String.Join("|", keywords) + @")\b";
            this.specialValues = @"\b(" + String.Join("|", specialValues) + @")\b";
            this.specialWords = @"\b(" + String.Join("|", specialWords) + @")\b";
        }
        
        public void Highlight(TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(commentStyle, stringStyle, numberStyle, keywordStyle, specialWordsStyle, specialValuesStyle, lettersStyle);
            
            //highlight comments
            //e.ChangedRange.SetStyle();
            
            //string highlighting
            e.ChangedRange.SetStyle(stringStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            
            //hightlight numbers
            e.ChangedRange.SetStyle(numberStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
        }
    }
}
