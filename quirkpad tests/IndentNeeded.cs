using System;
using System.Text.RegularExpressions;

public class IndentTester {
	
    //for testing regular expressions. these will be used for Quirkpad's indenting.
    public static string OpenBrace = @"^.*[^""'(\/\/)]*\{[^\}]*$";
    public static string CloseBrace = @"^[^\{""'(\/\/)]*\}.*$";
	
	public static string OpenTag = @"\<[^\/]+\>";
	public static string CloseTag = @"\<\/.+\>";
	
    public static void IndentNeeded(string text) {
        if (Regex.IsMatch(text, OpenBrace) && Regex.IsMatch(text, CloseBrace)) {
            Console.WriteLine("decrease indent for current line only.");
            return;
        }
    
        if (Regex.IsMatch(text, OpenBrace) || Regex.IsMatch(text, OpenTag)) {
            Console.WriteLine("increase indent for the next line.");
			return;
        }
        
        if (Regex.IsMatch(text, CloseBrace) || Regex.IsMatch(text, CloseTag)) {
            Console.WriteLine("decrease indent for this line and the next line.");
			return;
        }
		
		Console.WriteLine("no indent needed.");
    }
    
    public static void Main(string[] args) {        
        while (true) {
            Console.Write("input test line > ");
            string t = Console.ReadLine();
            if (t == "exit") break;
			IndentNeeded(t);
            Console.WriteLine("");
        }
    }
}