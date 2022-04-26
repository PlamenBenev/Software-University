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
            int num = int.Parse(Console.ReadLine());
            string pattern = @"(\S*)\>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})\<(\S+)";
            string input = Console.ReadLine();
            Regex rgx = new Regex(pattern);


            for (int i = 0; i < num; i++)
            {
                Match match = rgx.Match(input);
                if (match.Success && match.Groups[1].Value == match.Groups[6].Value)
                {
                    Console.WriteLine($"Password: {match.Groups[2].Value}{match.Groups[3].Value}{match.Groups[4].Value}{match.Groups[5].Value}");
                }
                else
                    Console.WriteLine("Try another password!");
                input = Console.ReadLine();
            }

        }
    }
}