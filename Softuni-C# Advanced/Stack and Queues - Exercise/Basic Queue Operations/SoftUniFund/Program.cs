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

            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> stack = new Queue<int>();

            for (int i = 0; i < nums[0]; i++)
            {
                stack.Enqueue(input[i]);
            }
            for (int i = 0; i < nums[1]; i++)
            {
                stack.Dequeue();
            }
            if (stack.Contains(nums[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
                Console.WriteLine(stack.Min());

        }

    }
}