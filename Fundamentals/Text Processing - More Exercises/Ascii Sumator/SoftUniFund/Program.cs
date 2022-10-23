using System;
using System.Globalization;
using System.Collections.Generic;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string alabala = Console.ReadLine();

            List<char> symbols = new List<char>();
            List<int> sum = new List<int>();
            for (int i = start + 1; i < end; i++)
            {
                symbols.Add((char)i);
            }
            foreach (var item in alabala)
            {
                if (symbols.Contains(item))
                {
                    sum.Add(item);
                }
            }
            int total = sum.Sum();
            Console.WriteLine(total);
        }
    }
}