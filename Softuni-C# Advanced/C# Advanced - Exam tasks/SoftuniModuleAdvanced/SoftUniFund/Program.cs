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

            Queue<int> guests = new Queue<int>();
            Stack<int> plates = new Stack<int>();

            int wastedFood = 0;

            foreach (var item in input1)
            {
                guests.Enqueue(item);
            }
            foreach (var item in input2)
            {
                plates.Push(item);
            }

            while (guests.Count > 0 && plates.Count > 0)
            {
                if (plates.Peek() - guests.Peek() > 0)
                {
                    wastedFood += plates.Pop() - guests.Dequeue();
                }
                else
                {
                    int newValue = guests.Dequeue() - plates.Pop();
                    if (newValue > 0)
                    {
                        Queue<int> newQue = new Queue<int>();
                        newQue.Enqueue(newValue);
                        foreach (var item in guests)
                        {
                            newQue.Enqueue(item);
                        }
                        guests = newQue;
                    }
                }
            }
            if (guests.Count > 0)
            {
                Console.WriteLine("Guests: " + String.Join(' ', guests));
            }
            if (plates.Count > 0)
            {
                Console.WriteLine("Plates: " + String.Join(' ', plates));
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}