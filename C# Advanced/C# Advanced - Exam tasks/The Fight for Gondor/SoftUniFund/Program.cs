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
            int waves = int.Parse(Console.ReadLine());

            int[] platesStart = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Array.Reverse(platesStart);
            Stack<int> plates = new Stack<int>();
            Stack<int> orcs = new Stack<int>();

            foreach (var item in platesStart)
            {
                plates.Push(item);
            }

            for (int i = 0; i < waves; i++)
            {
                int[] orcAttacks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                if (i % 3 == 0 && i != 0 && orcAttacks.Length == 1)
                {
                    plates.Push(orcAttacks[0]);
                    continue;
                }
                if (plates.Count > 0)
                {

                    foreach (var item in orcAttacks)
                    {
                        orcs.Push(item);
                    }

                    while (true)
                    {
                        if (plates.Count > 0)
                        {
                            if (orcs.Peek() > plates.Peek())
                            {
                                int newOrcValue = orcs.Peek() - plates.Pop();
                                orcs.Pop();
                                orcs.Push(newOrcValue);
                            }
                            else if (orcs.Peek() == plates.Peek())
                            {
                                orcs.Pop();
                                plates.Pop();
                            }
                            else if (orcs.Peek() < plates.Peek())
                            {
                                int newPlatesValue = plates.Peek() - orcs.Pop();
                                plates.Pop();
                                plates.Push(newPlatesValue);
                            }
                            if (orcs.Count == 0 || plates.Count == 0)
                            {
                                break;
                            }
                        }
                        else
                            break;
                    }
                    if ((i + 1) % 3 == 0)
                    {
                        waves++;
                    }
                }
            }
            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else if (orcs.Count > 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}