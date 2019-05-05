using System.IO;
using System;
using System.Windows.Forms;

namespace quirkpad {
    public static class OptionsReader {
        private static readonly string OptionsFilePath = Application.StartupPath + "\\quirkpad_settings.txt";
        public static string HighlightOption = "";
        
        public static string FontFamily {
            get {
                int index = 0;
                if (GetLine("[font]", out index)) {
                    return File.ReadAllLines(OptionsFilePath)[index + 1];
                } else {
                    return "Consolas";
                }
            }
            set {
                int index = 0;
                if (GetLine("[font]", out index)) {
                    string[] lines = File.ReadAllLines(OptionsFilePath);
                    lines[index + 1] = value;
                    
                    File.WriteAllLines(OptionsFilePath, lines);
                } else {
                    string[] newLines = { "[font]", value };
                    
                    File.AppendAllLines(OptionsFilePath, newLines);
                }
            }
        }
        
        public static float FontSize {
            get {
                int index = 0;
                if (GetLine("[font size]", out index)) {
                    float f = 0.00F;
                    if (float.TryParse(File.ReadAllLines(OptionsFilePath)[index + 1], out f)) {
                        return f;
                    } else {
                        return 9.75F;
                    }
                } else {
                    return 9.75F;
                }
            }
            set {
                int index = 0;
                if (GetLine("[font size]", out index)) {
                    string[] lines = File.ReadAllLines(OptionsFilePath);
                    lines[index + 1] = value.ToString();
                    
                    File.WriteAllLines(OptionsFilePath, lines);
                } else {
                    string[] newLines = { "[font size]", value.ToString() };
                    
                    File.AppendAllLines(OptionsFilePath, newLines);
                }
            }
        }
        
        public static string Theme {
            get {
                int index = 0;
                return GetLine("[theme]", out index) ? File.ReadAllLines(OptionsFilePath)[index + 1] : "light";
            }
            
            set {
                int index = 0;
                if (GetLine("[theme]", out index)) {
                    string[] lines = File.ReadAllLines(OptionsFilePath);
                    lines[index + 1] = value;
                    
                    File.WriteAllLines(OptionsFilePath, lines);
                } else {
                    string[] newLines = { "[theme]", value };
                    
                    File.AppendAllLines(OptionsFilePath, newLines);
                }
            }
        }
        
        public static void GetHighlightOption() {
            int index = 0;
            HighlightOption = GetLine("[highlight]", out index) ? File.ReadAllLines(OptionsFilePath)[index + 1] : "all";
        }
        
        public static void SetHighlightOption(string option) {
            HighlightOption = option;
            int index = 0;
            if (GetLine("[highlight]", out index)) {
                string[] lines = File.ReadAllLines(OptionsFilePath);
                lines[index + 1] = HighlightOption;
                
                File.WriteAllLines(OptionsFilePath, lines);
            } else {
                string[] newLines = { "[highlight]", HighlightOption };
                
                File.AppendAllLines(OptionsFilePath, newLines);
            }
        }
        
        //internal method
        static bool GetLine(string match, out int index) {
            int i = 0;
            
            while (i < File.ReadAllLines(OptionsFilePath).Length) {
                if (File.ReadAllLines(OptionsFilePath)[i] == match) {
                    index = i;
                    return true;
                } else {
                    i++;
                }
            }
            
            index = -1;
            return false;
        }
        
        //test method
        public static string GetOptionsFilePath() {
            return OptionsFilePath;
        }
    }
}