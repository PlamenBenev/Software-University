using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (dict.ContainsKey(symbol))
                {
                    dict[symbol]++;
                }
                else
                {
                    dict.Add(symbol, 1);
                }
            }
            dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}