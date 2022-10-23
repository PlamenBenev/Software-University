using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@]|[#])([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1";

            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            List<string> output = new List<string>();
            foreach (Match item in matches)
            {
                char[] gr3 = item.Groups[3].Value.ToCharArray();
                gr3 = gr3.Reverse().ToArray();
                string rev = new string(gr3);
                if (item.Groups[2].Value == rev)
                {
                    output.Add(item.Groups[2].ToString() + " <=> " + item.Groups[3].ToString());
                }
            }
            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }
            if (output.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", output));
            }
            else
                Console.WriteLine("No mirror words!");
        }
    }
}



