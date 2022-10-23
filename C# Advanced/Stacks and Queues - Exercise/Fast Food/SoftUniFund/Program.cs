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

            Queue<int> stack = new Queue<int>();

            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            foreach (var item in input)
            {
                stack.Enqueue(item);
            }
            Console.WriteLine(stack.Max());
            while (num > 0)
            {
                num -= stack.First();
                stack.Dequeue();
                if (stack.Count == 0 || num - stack.First() < 0)
                {
                    break;
                }
            }
            if (stack.Count > 0)
            {
                Console.WriteLine("Orders left: " + String.Join(" ", stack));
            }
            else
                Console.WriteLine("Orders complete");
        }
    }
}