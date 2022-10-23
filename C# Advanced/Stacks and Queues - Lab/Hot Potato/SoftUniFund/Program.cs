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
            string[] input = Console.ReadLine().Split(' ');

            var queue = new Queue<string>();
            foreach (var item in input)
            {
                queue.Enqueue(item);
            }
            int num = int.Parse(Console.ReadLine());

            int i = 1;
            while (queue.Count > 1)
            {
                if (i % num == 0)
                {
                    Console.WriteLine("Removed " + queue.Peek());
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(queue.Peek());
                    queue.Dequeue();
                }
                i++;
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}