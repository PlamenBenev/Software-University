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
            List<string> inventory = Console.ReadLine()
             .Split('|', StringSplitOptions.RemoveEmptyEntries)
             .ToList();

            string input = Console.ReadLine();
            List<string> stolen = new List<string>();

            while (input != "Yohoho!")
            {
                string[] token = input.Split(' ');

                if (token[0] == "Loot")
                {
                    for (int i = 1; i < token.Length; i++)
                    {
                        if (!inventory.Contains(token[i]))
                        {
                            inventory.Insert(0, token[i]);

                        }
                    }
                }
                else if (token[0] == "Drop")
                {
                    int index1 = int.Parse(token[1]);
                    if (index1 >= 0 && index1 < inventory.Count)
                    {
                        string currItem = inventory[index1];
                        inventory.RemoveAt(index1);
                        inventory.Add(currItem);
                    }
                }
                else if (token[0] == "Steal")
                {
                    int index1 = int.Parse(token[1]);
                    if (index1 >= inventory.Count)
                    {
                        stolen.AddRange(inventory);
                        inventory.Clear();
                    }
                    else if (index1 >= 0 && index1 < inventory.Count)
                    {
                        for (int i = inventory.Count - index1; i < inventory.Count; i++)
                        {
                            stolen.Add(inventory[i]);
                        }

                        inventory.RemoveRange(inventory.Count - index1, index1);
                    }
                    Console.WriteLine(String.Join(", ", stolen));

                }

                input = Console.ReadLine();
            }

            if (inventory.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < inventory.Count; i++)
                {
                    for (int k = 0; k < inventory[i].Length; k++)
                    {
                        count++;
                    }
                }
                double aprox = count / (double)inventory.Count;
                Console.WriteLine($"Average treasure gain: {aprox:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}