using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

					
public class Program
{
	static string[] logs = {"88 99 200", "88 99 300", "99 32 100", "12 12 15"};
	static int threshold = 2;
	static IDictionary<int, string> numberSets = new Dictionary<int, string>();
	static String newString = String.Empty;
	
	public static void Main()
	{
		// duplicates count only when outside of a 3-number string
		// therefore, remove interstring duplicates
		for(int i=0; i<logs.Length; i++)
		{
			logs[i] = String.Join(" ", logs[i].Split(' ').Distinct());
		}
		
		String str2 = String.Empty;
		foreach(String str in logs)
		{
			str2 += str;
			if(Char.IsDigit(str[str.Length -1])) // ensure there is always a space between numbers
				str2 += " ";
			newString += str2;
		}
		
		var result = Regex.Split(str2, @"\W+")
			.AsEnumerable()
			.GroupBy(w => w)
			.Select(g => new {key = g.Key, count = g.Count()});
		
		List<String> list = new List<String>();
		
		foreach(var a in result)
		{
			if(a.count >= threshold)
				list.Add(a.key);
		}
		
		list.Sort((x, y) =>
		{
			int ix, iy;
			return int.TryParse(x, out ix) && int.TryParse(y, out iy) ? ix.CompareTo(iy) : string.Compare(x, y);
		});
		
		String[] b = list.ToArray();
		
		foreach(String a in b)
		{
			Console.WriteLine(a);
		}
		
		// return b;

	}
}