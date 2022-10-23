using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> dict =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split(' ');

                if (dict.ContainsKey(token[0]))
                {
                    if (dict[token[0]].ContainsKey(token[1]))
                    {
                        dict[token[0]][token[1]].Add(token[2]);
                    }
                    else
                    {
                        dict[token[0]].Add(token[1], new List<string>() { token[2]});
                    }
                }
                else
                {
                    dict[token[0]] = new Dictionary<string, List<string>>();
                    dict[token[0]].Add(token[1], new List<string>() { token[2] });
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var country in item.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}