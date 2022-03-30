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
            string pattern =
                 @"([|]|[#])([A-Za-z ]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,4}|10000)\1";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            int cal = 0;
            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                cal += int.Parse(item.Groups[4].ToString());
            }
            int days = cal / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups[2]}, Best before: {item.Groups[3]}, Nutrition: {item.Groups[4]}");
            }

        }
    }
}