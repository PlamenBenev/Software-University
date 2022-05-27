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

            Queue<int> ingredient = new Queue<int>();
            Stack<int> freshness = new Stack<int>();

            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();

            dictionary.Add("Dipping sauce", 0);
            dictionary.Add("Green salad", 0);
            dictionary.Add("Chocolate cake", 0);
            dictionary.Add("Lobster", 0);

            foreach (var item in input1)
            {
                ingredient.Enqueue(item);
            }
            foreach (var item in input2)
            {
                freshness.Push(item);
            }

            while (ingredient.Count > 0 && freshness.Count > 0)
            {
                if (ingredient.Peek() == 0)
                {
                    ingredient.Dequeue();
                    continue;
                }

                int multiplied = ingredient.Peek() * freshness.Pop();

                if (multiplied == 150)
                {
                    dictionary["Dipping sauce"]++;
                }
                else if (multiplied == 250)
                {
                    dictionary["Green salad"]++;
                }
                else if (multiplied == 300)
                {
                    dictionary["Chocolate cake"]++;
                }
                else if (multiplied == 400)
                {
                    dictionary["Lobster"]++;
                }
                else
                {
                    ingredient.Enqueue(ingredient.Peek() + 5);
                }
                    ingredient.Dequeue();
            }

            if (dictionary["Dipping sauce"] > 0 && dictionary["Green salad"] > 0 &&
                dictionary["Chocolate cake"] > 0 && dictionary["Lobster"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredient.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }
            foreach (var item in dictionary)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine("# " + item.Key + " --> " + item.Value);
                }
            }
        }
    }
}