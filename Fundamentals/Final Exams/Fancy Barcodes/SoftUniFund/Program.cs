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

            string pattern = @"\@\#+([A-Z][a-z|A-Z|0-9]+[A-Z])\@\#+";
            Regex rgx = new Regex(pattern);

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                MatchCollection col = rgx.Matches(input);
                Match check = rgx.Match(input);
                if (check.Success && check.Groups[1].Length > 5)
                {
                    string str = "";
                    foreach (Match item in col)
                    {
                        string wtf = item.Groups[1].ToString();
                        for (int k = 0; k < wtf.Length; k++)
                        {
                            if (char.IsDigit(wtf[k]))
                            {
                                str += wtf[k];
                            }
                        }

                    }
                    if (str.Length > 0)
                    {
                        Console.WriteLine($"Product group: {str}");
                    }
                    else
                        Console.WriteLine($"Product group: 00");
                }
                else
                    Console.WriteLine("Invalid barcode");

            }
        }
    }
}