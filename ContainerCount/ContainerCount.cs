using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;  
					
public class Program
{
	public static void Main()
	{
		string str = "**|*|****|**";
		string str2 = str;
		
		List<int> startIndices = new List<int>();
		List<int> endIndices = new List<int>();
		
		startIndices.Add(1);
		startIndices.Add(1);
		
		endIndices.Add(11);
		endIndices.Add(5);
		
        String[] separator = {"|"}; // only one, but can assign more
       
        String[] strlist = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		String[] pillarcount = Regex.Split(str, @"\s+");
		
		bool isleftvertical = false;
		int containercount = 0;
		int b = 0;
		foreach(int a in startIndices)
		{
			string str3 = str2.Substring(startIndices[b]-1, endIndices[b] );
			Console.WriteLine(str3);
			containercount = 0;
			isleftvertical = false;
			foreach(char s in str3)
			{
				// check if first character is vertical or asterisk
				// of course a switch here is overkill, that's before I realized how simple it really needed to be
				switch(s)
				{
					case '|':
						if(!isleftvertical)
						{
							isleftvertical = true;
						}
						else
						{
							containercount++;
						}
						break;
				}
			}
			Console.WriteLine(containercount);
			b++;
		}
	}
}