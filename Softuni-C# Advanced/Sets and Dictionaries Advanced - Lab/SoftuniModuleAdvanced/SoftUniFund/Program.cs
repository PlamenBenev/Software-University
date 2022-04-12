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
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] sorted = nums.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < sorted.Length; i++)
            {
                if (i < 3)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
        }
    }
}