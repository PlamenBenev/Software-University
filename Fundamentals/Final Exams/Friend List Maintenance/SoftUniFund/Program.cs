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
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();
            List<string> blacklisted = new List<string>();
            List<string> losted = new List<string>();

            while (input != "Report")
            {
                string[] token = input.Split(' ');

                if (token[0] == "Blacklist")
                {
                    if (inventory.Contains(token[1]))
                    {
                        int index = inventory.IndexOf(token[1]);
                        inventory[index] = "Blacklisted";
                        Console.WriteLine($"{token[1]} was blacklisted.");
                        blacklisted.Add(token[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{token[1]} was not found.");
                    }
                }
                else if (token[0] == "Error")
                {
                    int index1 = int.Parse(token[1]);
                    if (index1 >= 0 && index1 < inventory.Count && inventory[index1] != "Blacklisted" && inventory[index1] != "Lost")
                    {
                        losted.Add(inventory[index1]);
                        Console.WriteLine($"{inventory[index1]} was lost due to an error.");
                        inventory[index1] = "Lost";
                    }
                }
                else if (token[0] == "Change")
                {
                    int index1 = int.Parse(token[1]);
                    if (index1 >= 0 && index1 < inventory.Count)
                    {
                        Console.WriteLine($"{inventory[index1]} changed his username to {token[2]}.");
                        inventory[index1] = token[2];
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blacklisted.Count}");
            Console.WriteLine($"Lost names: {losted.Count}");
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i] != "Blacklisted" || inventory[i] != "Lost")
                {
                    Console.Write(inventory[i] + " ");
                }
            }
        }

    }
}