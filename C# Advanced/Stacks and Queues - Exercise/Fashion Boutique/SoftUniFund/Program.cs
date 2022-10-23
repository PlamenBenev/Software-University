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
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            int sum = 0;
            int rack = 0;

            foreach (var item in stack)
            {
                sum += item;
                if (sum == capacity)
                {
                    rack++;
                    sum = 0;
                }
                else if (sum > capacity)
                {
                    sum = 0;
                    sum += item;
                    rack++;
                }
            }
                if (sum > 0)
                {
                    rack++;
                }
            Console.WriteLine(rack);
        }
    }
}