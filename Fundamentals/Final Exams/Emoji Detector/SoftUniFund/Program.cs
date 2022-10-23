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
            string input = Console.ReadLine();
            int threshold = 1;
            

            string pattern = @"([\:\:]{2}|[\*\*]{2})([A-Z][a-z]{2,})\1";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            List<Match> cool = new List<Match>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    threshold *= int.Parse(input[i].ToString());
                }
            }

            foreach (Match item in matches)
            {
                int sum = 0;
                for (int i = 0; i < item.Groups[2].Value.Length; i++)
                {
                    sum += char.Parse(item.Groups[2].Value[i].ToString());
                }
                if (sum > threshold)
                {
                    cool.Add(item);
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (var item in cool)
            {
                Console.WriteLine(item);
            }
        }
    }
}


