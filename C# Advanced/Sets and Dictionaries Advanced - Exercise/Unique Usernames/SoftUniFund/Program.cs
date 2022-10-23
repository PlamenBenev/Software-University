using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();

                set.Add(input);
            }
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}