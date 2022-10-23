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
            string pattern = @" ([A-Za-z0-9]+\.*\-*_*\w*)\@([A-Za-z]+\-*[A-Za-z]*\.[A-Za-z]+\.*[a-z]+)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                string it = item.Value.Trim();
                Console.WriteLine(it);
            }
        }
    }
}