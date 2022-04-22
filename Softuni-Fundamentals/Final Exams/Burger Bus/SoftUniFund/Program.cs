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
            int city = int.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 1; i <= city; i++)
            {
                string name = Console.ReadLine();
                double income = double.Parse(Console.ReadLine());
                double expanses = double.Parse(Console.ReadLine());

                if (i % 3 == 0 && i % 5 != 0)
                {
                    expanses += expanses * 0.5;
                }
                else if (i % 5 == 0)
                {
                    income -= income * 0.1;
                }
                double earned = income - expanses;
                Console.WriteLine($"In {name} Burger Bus earned {earned:f2} leva.");
                total += earned;
            }
            Console.WriteLine($"Burger Bus total profit: {total:f2} leva.");
        }

    }
}