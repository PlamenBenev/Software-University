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
            string[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<string> foods = new Queue<string>();
            Stack<int> dayCal = new Stack<int>();

            bool itsEnough = false;
            int meals = 0;
            // int forTheNextDay = 0;

            foreach (var item in input1)
            {
                foods.Enqueue(item);
            }
            foreach (var item in input2)
            {
                int parsing = int.Parse(item);
                dayCal.Push(parsing);
            }

            while (foods.Count > 0)
            {
                if (foods.Peek() == "salad")
                {
                    int newValue = dayCal.Pop() - (350);
                    dayCal.Push(newValue);
                }
                else if (foods.Peek() == "soup")
                {
                    int newValue = dayCal.Pop() - (490);
                    dayCal.Push(newValue);
                }
                else if (foods.Peek() == "pasta")
                {
                    int newValue = dayCal.Pop() - (680);
                    dayCal.Push(newValue);
                }
                else if (foods.Peek() == "steak")
                {
                    int newValue = dayCal.Pop() - (790);
                    dayCal.Push(newValue);
                }
                if (dayCal.Peek() <= 0)
                {
                    int forTheNextDay = Math.Abs(dayCal.Pop());
                    if (dayCal.Count > 0)
                    {
                        int newValue = dayCal.Pop() - forTheNextDay;
                        dayCal.Push(newValue);
                    }
                }

                meals++;
                foods.Dequeue();

                if (dayCal.Count == 0)
                {
                    itsEnough = true;
                    break;
                }
            }
            if (itsEnough)
            {
                Console.WriteLine($"John ate enough, he had {meals} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ", foods)}.");
            }
            else
            {
                Console.WriteLine($"John had {meals} meals.");
                Console.WriteLine($"For the next few days, he can eat {String.Join(", ", dayCal)} calories.");
            }
        }
    }
}