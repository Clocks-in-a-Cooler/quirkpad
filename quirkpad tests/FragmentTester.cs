using System;
using System.Text.RegularExpressions;

public class FragmentTester {
	//for HTML and CSS: attributes, properties and escape characters.
	public static Regex Attribute = new Regex(@"(\-?\w+)+");
	public static Regex Property = new Regex(@"(?<property>(\-?\w+?)+?)\s*:");
	public static Regex EscapeCharacter = new Regex(@"&.*?;");
	
	public static void MatchFragment(string text) {
		Match a = Attribute.Match(text);
		if (a.Value == "") {
			Console.WriteLine("no match for ATTRIBUTE.");
		} else {
			Console.WriteLine("ATTRIBUTE match: " + a.Value);
		}
		
		Match p = Property.Match(text);
		if (p.Groups["property"].Value == "") {
			Console.WriteLine("no match for PROPERTY.");
		} else {
			Console.WriteLine("PROPERTY match: " + p.Groups["property"].Value);
		}
		
		Match e = EscapeCharacter.Match(text);
		if (e.Value == "") {
			Console.WriteLine("no match for ESCAPE CHARACTER");
		} else {
			Console.WriteLine("ESCAPE CHARACTER match: " + e.Value);
		}
	}
	
	public static void Main(string[] args) {
		while (true) {
			Console.Write("input test string > ");
			string t = Console.ReadLine();
			if (t == "exit") break;
			MatchFragment(t);
			Console.WriteLine("");
		}
	}
}