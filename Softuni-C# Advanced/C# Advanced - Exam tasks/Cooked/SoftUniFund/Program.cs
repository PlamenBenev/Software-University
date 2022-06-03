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

            Queue<int> liquids = new Queue<int>();
            Stack<int> ingredients = new Stack<int>();
            SortedDictionary<string, int> cooked = new SortedDictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Fruit Pie", 0 },
                {"Pastry", 0 }
            };

            foreach (var item in input1)
            {
                liquids.Enqueue(item);
            }
            foreach (var item in input2)
            {
                ingredients.Push(item);
            }

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sumed = liquids.Dequeue() + ingredients.Peek();
                if (sumed == 25)
                {
                    cooked["Bread"]++;
                    ingredients.Pop();
                }
                else if (sumed == 50)
                {
                    cooked["Cake"]++;
                    ingredients.Pop();
                }
                else if (sumed == 75)
                {
                    cooked["Pastry"]++;
                    ingredients.Pop();
                }
                else if (sumed == 100)
                {
                    cooked["Fruit Pie"]++;
                    ingredients.Pop();
                }
                else
                {
                    int newValue = ingredients.Pop() + 3;
                    ingredients.Push(newValue);
                }
            }
            if (cooked.Any(x => x.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var item in cooked)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

    }
}