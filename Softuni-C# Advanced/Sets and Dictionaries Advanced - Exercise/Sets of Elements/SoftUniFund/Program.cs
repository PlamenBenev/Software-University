using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < nums[0]; i++)
            {
                int input = int.Parse(Console.ReadLine());

                set1.Add(input);
            }
            for (int i = 0; i < nums[1]; i++)
            {
                int input = int.Parse(Console.ReadLine());

                set2.Add(input);
            }
            foreach (var item in set1)
            {
                if (set2.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}