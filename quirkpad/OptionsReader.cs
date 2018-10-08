using System.IO;
using System;

namespace quirkpad {
public static class OptionsReader {
    
    public static string[] ReadOptions(string path) {
        if (File.Exists(path)) {
            //read the options
            string[] vals = new string[3];
            
            vals[0] = @"\b(" + File.ReadAllLines(path)[0].Replace(" ", "|") + @")\b";
            vals[1] = @"\b(" + File.ReadAllLines(path)[1].Replace(" ", "|") + @")\b";
            vals[2] = @"\b(" + File.ReadAllLines(path)[2].Replace(" ", "|") + @")\b";
            
            return vals;
        } else {
            //default stuff
            return new string[] {
                //default keywords
                @"\b(int|double|float|bool|boolean|char|string|function|new|in|this|throw|String|if|else|while|do|for|switch|case|default|return|try|catch|finally|break|continue|using|import|#include|#define|#def|let|const|var|class|interface)\b",
                //default special ones
                @"\b(void|public|private|protected|sealed|abstract|virtual|get|set)\b",
                //some special values
                @"\b(true|false|undefined|null|NaN|prototype|super|base|Infinity)\b"
            };
        }
    }
}
}