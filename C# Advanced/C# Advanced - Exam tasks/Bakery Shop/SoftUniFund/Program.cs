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
            double[] inputWater = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double[] inputFlaur = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            Queue<double> water = new Queue<double>();
            Stack<double> flour = new Stack<double>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Croissant", 0);
            dict.Add("Muffin", 0);
            dict.Add("Baguette", 0);
            dict.Add("Bagel", 0);

            foreach (int i in inputWater)
            {
                water.Enqueue(i);
            }
            foreach (int i in inputFlaur)
            {
                flour.Push(i);
            }

            while (water.Count > 0 && flour.Count > 0)
            {
                double mixed = water.Peek() + flour.Peek();
                double percent = Math.Ceiling(water.Peek() * 100 / mixed);
                double newValue = 0;

                if (percent == 50)
                {
                    dict["Croissant"]++;
                }
                else if (percent == 40)
                {
                    dict["Muffin"]++;
                }
                else if (percent == 30)
                {
                    dict["Baguette"]++;
                }
                else if (percent == 20)
                {
                    dict["Bagel"]++;
                }
                else
                {
                    newValue = flour.Peek() - water.Peek();
                    dict["Croissant"]++;
                }

                water.Dequeue();
                flour.Pop();

                if (newValue > 0)
                {
                    flour.Push(newValue);
                }
            }
            var dictt = dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var item in dictt)
            {
                if (item.Value > 0)
                    Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}