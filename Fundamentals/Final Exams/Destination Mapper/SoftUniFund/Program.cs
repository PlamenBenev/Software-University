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
            string patter = @"([=]|[\/])([A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(patter);

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            int sum = 0;
            List<string> list = new List<string>();

            foreach (Match item in matches)
            {
                list.Add(item.Groups[2].ToString());
                sum += item.Groups[2].ToString().Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", list)}");
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}