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

            Stack<int> hats = new Stack<int>();
            Queue<int> scarfs = new Queue<int>();
            List<int> prices = new List<int>();

            foreach (var item in input1)
            {
                hats.Push(item);
            }
            foreach (var item in input2)
            {
                scarfs.Enqueue(item);
            }

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                if (hats.Peek() == scarfs.Peek())
                {
                    int increment = hats.Pop() + 1;
                    hats.Push(increment);
                    scarfs.Dequeue();
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() > scarfs.Peek())
                {
                    int set = hats.Pop() + scarfs.Dequeue();
                    prices.Add(set);
                }
            }

            int highest = 0;

            foreach (var item in prices)
            {
                if (highest < item)
                    highest = item;
            }
            Console.WriteLine($"The most expensive set is: {highest}");
            Console.WriteLine(String.Join(" ",prices));
        }
    }
}