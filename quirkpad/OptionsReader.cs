using System.IO;
using System;
using System.Windows.Forms;

namespace quirkpad {
    public static class OptionsReader {
        private static string OptionsFilePath = Application.StartupPath + "\\quirkpad_settings.txt";
        
        public static string[] GetKeywords() {
            string[] keywords = new string[3];
            int index = 0;
            
            if (GetLine("[keywords]", out index)) {
                keywords[0] = @"\b(" + File.ReadAllLines(OptionsFilePath)[index + 1].Replace(" ", "|") + @")\b";
                keywords[1] = @"\b(" + File.ReadAllLines(OptionsFilePath)[index + 2].Replace(" ", "|") + @")\b";
                keywords[2] = @"\b(" + File.ReadAllLines(OptionsFilePath)[index + 3].Replace(" ", "|") + @")\b";
            } else {
                keywords[0] = @"\b(int|double|float|bool|boolean|char|string|function|new|in|this|throw|String|if|else|while|do|for|switch|case|default|return|try|catch|finally|break|continue|using|import|#include|#define|#def|let|const|var|class|interface)\b";
                keywords[1] = @"\b(void|public|private|protected|sealed|abstract|virtual|get|set)\b";
                keywords[2] = @"\b(true|false|undefined|null|NaN|prototype|super|base|Infinity)\b";
            }
            
            return keywords;
        }
        
        public static string GetFontOption() {
            int index = 0;
            if (GetLine("[font]", out index)) {
                return File.ReadAllLines(OptionsFilePath)[index + 1];
            } else {
                return "Consolas";
            }
        }
        
        public static void SetFontOption(string fontName) {
            int index = 0;
            if (GetLine("[font]", out index)) {
                string[] lines = File.ReadAllLines(OptionsFilePath);
                lines[index + 1] = fontName;
                
                File.WriteAllLines(OptionsFilePath, lines);
            } else {
                string[] newLines = new string[] { "[font]", fontName };
                
                File.AppendAllLines(OptionsFilePath, newLines);
            }
        }
        
        public static float GetFontSize() {
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
        
        public static void SetFontSize(float f) {
            int index = 0;
            if (GetLine("[font size]", out index)) {
                string[] lines = File.ReadAllLines(OptionsFilePath);
                lines[index + 1] = f.ToString();
                
                File.WriteAllLines(OptionsFilePath, lines);
            } else {
                string[] newLines = new string[] { "[font size]", f.ToString() };
                
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
        
        public static string[] ReadKeywords(string path) {
            if (File.Exists(path)) {
                //read the options
                string[] vals = new string[3];
                
                vals[0] = @"\b(" + File.ReadAllLines(path)[0].Replace(" ", "|") + @")\b";
                vals[1] = @"\b(" + File.ReadAllLines(path)[1].Replace(" ", "|") + @")\b";
                vals[2] = @"\b(" + File.ReadAllLines(path)[2].Replace(" ", "|") + @")\b";
                
                return vals;
            } else {
                //default stuff
                string[] ret = new string[] {
                    //default keywords
                    @"\b(int|double|float|bool|boolean|char|string|function|new|in|this|throw|String|if|else|while|do|for|switch|case|default|return|try|catch|finally|break|continue|using|import|#include|#define|#def|let|const|var|class|interface)\b",
                    //default special ones
                    @"\b(void|public|private|protected|sealed|abstract|virtual|get|set)\b",
                    //some special values
                    @"\b(true|false|undefined|null|NaN|prototype|super|base|Infinity)\b",
                };
                
                return ret;
            }
        }
        
        public static string ReadFontOption(string path) {
            if (File.Exists(path)) {
                return File.ReadAllText(path);
            } else {
                return "Consolas";
            }
        }
        
        public static void SaveFontOption(string fontName, string path) {
            File.WriteAllText(path, fontName);
        }
    }
}