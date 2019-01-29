using System.Drawing;

namespace quirkpad {
    public class Theme {
        public Brush LinkStyle;
        public Brush CommentStyle;
        public Brush KeywordStyle;
        public Brush StringStyle;
        public Brush SpecialWordStyle;
        public Brush SpecialValueStyle;
        public Brush LetterStyle;
        
        public Color CurrentLineColour;
        public Color ForeColour;
        
        public Color IndentColour;
        public Color LineNumberColour;
        
        public Color BackColour;
        public Color SelectionColour;
        
        public Theme(Brush link, Brush comment, Brush keyword, Brush _string, Brush specialword, Brush specialvalue, Brush letters, 
                    Color currentline, Color fore, Color indent, Color linenumber, Color back, Color selection) {
            //gotta finish this.
            LinkStyle = link;
            CommentStyle = comment;
            KeywordStyle = keyword;
            StringStyle = _string;
            SpecialWordStyle = specialword;
            SpecialValueStyle = specialvalue;
            LetterStyle = letters;
            
            CurrentLineColour = currentline;
            ForeColour = fore;
            IndentColour = indent;
            LineNumberColour = linenumber;
            BackColour = back;
            SelectionColour = selection;
        }
    }
}