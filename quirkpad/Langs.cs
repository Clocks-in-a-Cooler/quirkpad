//languages file -- just data

namespace quirkpad {
    public class Langs {
        static string[] JSKeywords = { "abstract", "await", "boolean", "break", "byte", "case", "catch", "char", "class", "const", "continue", "default", "delete", "do", "double", "else", "enum", "export", "extends", "final", "finally", "float", "for", "function", "goto", "if", "implements", "import", "in", "instanceof", "int", "interface", "let", "long", "native", "new", "package", "private", "protected", "public", "return", "short", "static", "super", "switch", "synchronized", "this", "throw", "throws", "transient", "try", "typeof", "var", "volatile", "while", "with", "yield" };
        static string[] JSSpecialWords = { "arguments", "debugger", "console", "prototype", "get", "set" };
        static string[] JSSpecialValues = { "Infinity", "NaN", "true", "false", "null", "undefined", "void" };
        public static Language Javascript = new Language(JSKeywords, JSSpecialValues, JSSpecialWords);
        
        
    }
}