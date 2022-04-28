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

            Dictionary<int,int> dict = new Dictionary<int,int>();

            for (int i = 0; i < num; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (dict.ContainsKey(input))
                {
                    dict[input]++;
                }
                else
                {
                    dict.Add(input, 1);
                }
            }
            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}