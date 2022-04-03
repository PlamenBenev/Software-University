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
            int energy = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int won = 0;

            while (input != "End of battle")
            {
                int num = int.Parse(input);

                if (num <= energy)
                {
                    won++;
                    energy -= num;
                    if (won % 3 == 0)
                    {
                        energy += won;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {won} won battles and {energy} energy");
                    return;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {won}. Energy left: {energy}");
        }

    }
}