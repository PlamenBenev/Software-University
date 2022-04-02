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
            string input1 = Console.ReadLine();
            string pattern = $"{input1}";
            Regex regex = new Regex(pattern);
            string input2 = Console.ReadLine();

            MatchCollection matches = regex.Matches(input2);

            for (int i = 0; i < matches.Count; i++)
            {
                int indexer = input2.IndexOf(input1);
                input2 = input2.Remove(indexer, input1.Length);
                for (int k = 0; k < input1.Length; k++)
                {
                    input2 = input2.Insert(indexer, "*");
                }
            }

            Console.WriteLine(input2);
        }
    }
}