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
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int input = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>();
            Queue<int> threads = new Queue<int>();

            foreach (var item in input1)
            {
                tasks.Push(item);
            }
            foreach (var item in input2)
            {
                threads.Enqueue(item);
            }

            while (tasks.Peek() != input)
            {
                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {input}");
            Console.WriteLine(string.Join(' ',threads));
        }

    }
}