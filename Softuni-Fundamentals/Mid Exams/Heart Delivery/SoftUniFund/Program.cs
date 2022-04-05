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
            List<int> kvartala = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToList();
            List<int> initial = kvartala.FindAll(x => x <= 0);
            string input = Console.ReadLine();
            int currentIndex = 0;
            int failed = 0;

            while (input != "Love!")
            {
                string[] words = input.Split(' ');
                int index = int.Parse(words[1]);
                currentIndex += index;

                if (currentIndex >= kvartala.Count)
                {
                    currentIndex = 0;
                }
                if (kvartala[currentIndex] <= 0)
                {
                    Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                }
                else
                {
                    kvartala[currentIndex] -= 2;
                    if (kvartala[currentIndex] <= 0)
                    {
                        Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                    }
                    else
                        failed++;
                }
                input = Console.ReadLine();
            }
            kvartala = kvartala.FindAll(x => x > 0);
            failed = kvartala.Count - initial.Count;
            Console.WriteLine($"Cupid's last position was {currentIndex}.");
            Console.WriteLine($"Cupid has failed {failed} places.");
        }

    }
}