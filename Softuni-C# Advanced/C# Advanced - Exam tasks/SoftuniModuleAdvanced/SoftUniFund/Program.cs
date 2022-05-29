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
            int[] input1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] input2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> first = new Queue<int>();
            Stack<int> second = new Stack<int>();

            int claimed = 0;

            foreach (var item in input1)
            {
                first.Enqueue(item);
            }
            foreach (var item in input2)
            {
                second.Push(item);
            }

            while (first.Count > 0 && second.Count > 0)
            {
                int sum = first.Peek() + second.Peek();
                if (sum % 2 == 0)
                {
                    claimed += sum;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    first.Enqueue(second.Pop());
                }
            }
            if (first.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (second.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimed > 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimed}");
            }
            else
                Console.WriteLine($"Your loot was poor... Value: {claimed}");
        }
    }
}