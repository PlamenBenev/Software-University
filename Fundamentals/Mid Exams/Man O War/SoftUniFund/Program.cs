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
            List<int> pirate = Console.ReadLine()
                .Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> warship = Console.ReadLine()
               .Split('>', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int maxHP = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Retire")
            {
                string[] token = input.Split(' ');

                if (token[0] == "Fire")
                {
                    int index1 = int.Parse(token[1]);
                    int dmg = int.Parse(token[2]);
                    if (index1 >= 0 && index1 < warship.Count)
                    {
                        warship[index1] -= dmg;
                        if (warship[index1] < 1)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (token[0] == "Defend")
                {
                    int start = int.Parse(token[1]);
                    int end = int.Parse(token[2]);
                    int dmg = int.Parse(token[3]);
                    if (start >= 0 && start < pirate.Count && end >= 0 && end < pirate.Count)
                    {
                        for (int i = start; i <= end; i++)
                        {
                            pirate[i] -= dmg;
                            if (pirate[i] < 1)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (token[0] == "Repair")
                {
                    int index0 = int.Parse(token[1]);
                    int hp = int.Parse(token[2]);
                    if (index0 >= 0 && index0 < pirate.Count && pirate[index0] < maxHP)
                    {
                        pirate[index0] += hp;
                        if (pirate[index0] > maxHP)
                        {
                            pirate[index0] = maxHP;
                        }
                    }
                }
                else if (token[0] == "Status")
                {
                    int count = 0;
                    for (int i = 0; i < pirate.Count; i++)
                    {
                        if (pirate[i] < maxHP * 0.2)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }

                input = Console.ReadLine();
            }
            int pShips = pirate.Sum();
            int wShips = warship.Sum();
            Console.WriteLine($"Pirate ship status: {pShips}");
            Console.WriteLine($"Warship status: {wShips}");
        }
    }
}