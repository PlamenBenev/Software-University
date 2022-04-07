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
            string input = Console.ReadLine();

            var queue = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    foreach (var item in queue)
                    {
                        Console.WriteLine(item);
                    }
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
                    Console.WriteLine(queue.Count + " people remaining.");
        }
    }
}