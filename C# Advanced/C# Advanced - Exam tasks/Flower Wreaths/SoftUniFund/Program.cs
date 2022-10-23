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
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int wreath = 0;
            int storing = 0;

            Stack<int> lillies = new Stack<int>();
            Queue<int> roses = new Queue<int>();

            foreach (var item in input1)
            {
                lillies.Push(item);
            }
            foreach (var item in input2)
            {
                roses.Enqueue(item);
            }

            while (roses.Count > 0 && lillies.Count > 0)
            {
                if (lillies.Peek() + roses.Peek() == 15)
                {
                    wreath++;
                    lillies.Pop();
                    roses.Dequeue();
                }
                else if (lillies.Peek() + roses.Peek() > 15)
                {
                    int newlili = lillies.Pop() - 2;
                    lillies.Push(newlili);
                }
                else if (lillies.Peek() + roses.Peek() < 15)
                {
                    storing += lillies.Pop() + roses.Dequeue();
                }
            }
            wreath += storing / 15;

            if (wreath < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreath} wreaths more!");
            }
            else
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
        }
    }
}