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
            int days = int.Parse(Console.ReadLine());
            int dailyP = int.Parse(Console.ReadLine());
            double expectedP = double.Parse(Console.ReadLine());
            double gained = 0;

            for (int i = 1; i <= days; i++)
            {

                gained += dailyP;
                if (i % 3 == 0)
                {
                    gained += dailyP * 0.5;
                }
                if (i % 5 == 0)
                {
                    gained -= gained * 0.3;
                }

            }
            if (gained >= expectedP)
            {
                Console.WriteLine($"Ahoy! {gained:f2} plunder gained.");
            }
            else
            {
                double percentage = (gained / expectedP) * 100;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }

    }
}