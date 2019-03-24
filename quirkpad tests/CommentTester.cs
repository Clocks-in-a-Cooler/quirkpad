using System;
using System.Text.RegularExpressions;

public class CommentTester {
	public static Regex ForwardSlashComment = new Regex(@"(?(https?:)(?<link>https?://[\w\./]*)|(?<comment>(\/\/\/?).*$))", RegexOptions.Multiline);
	
	public static void MatchComment(string text) {
		Match fc = ForwardSlashComment.Match(text);
		
		if (fc.Groups["comment"].Value == "") {
			Console.WriteLine("no match for FORWARD SLASH COMMENT.");
		} else {
			Console.WriteLine("FORWARD SLASH COMMENT: " + fc.Groups["comment"].Value);
		}
		
		if (fc.Groups["link"].Value == "") {
			Console.WriteLine("no match for LINK.");
		} else {
			Console.WriteLine("LINK: " + fc.Groups["link"].Value);
		}
	}
	
	public static void Main(string[] args) {
		while (true) {
			Console.Write("input test line >");
			string t = Console.ReadLine();
			if (t == "exit") break;
			MatchComment(t);
			Console.WriteLine("");
		}
	}
}