using System.Drawing;

namespace quirkpad {
    public class Preferences {
        public Font font;
        
        public Preferences(Font font) {
            this.font = font;
        }
        
        public Font getFont() {
            return font;
        }
    }
}