using FastColoredTextBoxNS;
using System.Drawing;

namespace quirkpad {
    public class Styles {
        //various styles
        public static TextStyle Brown = new TextStyle(Brushes.Chocolate, null, FontStyle.Regular);
        public static TextStyle Blue = new TextStyle(Brushes.DodgerBlue, null, FontStyle.Regular);
        public static TextStyle Red = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        public static TextStyle Orange = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);
        public static TextStyle Gray = new TextStyle(Brushes.LightSlateGray, null, FontStyle.Regular);
        public static TextStyle Purple = new TextStyle(Brushes.MediumOrchid, null, FontStyle.Regular);
        public static TextStyle Green = new TextStyle(Brushes.LimeGreen, null, FontStyle.Regular);
        public static TextStyle Black = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        public static TextStyle Yellow = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static TextStyle White = new TextStyle(Brushes.White, null, FontStyle.Regular);
        
        public static TextStyle LinkStyle = new TextStyle(Brushes.Red, null, FontStyle.Underline);
        
        public static MarkerStyle SameWords = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.LightSlateGray)));
        
        //more styles
        public TextStyle Links;
        public TextStyle Comment;
        public TextStyle String;
        public TextStyle Number;
        public TextStyle KeyWords;
        public TextStyle SpecialKeyWords;
        public TextStyle SpecialValues;
        public TextStyle Letters;
        
        //mapping some stuff
        public static TextStyle FromColour(string colour) {
            switch (colour) {
                case "red":
                    return Red;
                case "orange":
                    return Orange;
                case "yellow":
                    return Yellow;
                case "green":
                    return Green;
                case "blue":
                    return Blue;
                case "purple":
                    return Purple;
                case "brown":
                    return Brown;
                case "black":
                    return Black;
                case "white":
                    return White;
                case "gray":
                    return Gray;
                default:
                    throw new System.Exception("unrecognized colour -- " + colour);
            }
        }
    }
}