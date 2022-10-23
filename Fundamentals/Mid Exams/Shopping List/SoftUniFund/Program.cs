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
             .Split('!', StringSplitOptions.RemoveEmptyEntries)
             .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] token = input.Split(' ');

                if (token[0] == "Urgent")
                {
                    if (!inventory.Contains(token[1]))
                        inventory.Insert(0, token[1]);
                }
                else if (token[0] == "Unnecessary")
                {
                    if (inventory.Contains(token[1]))
                        inventory.Remove(token[1]);
                }
                else if (token[0] == "Correct")
                {
                    if (inventory.Contains(token[1]))
                    {
                        int index = inventory.IndexOf(token[1]);
                        inventory.Remove(token[1]);
                        inventory.Insert(index, token[2]);
                    }
                }
                else if (token[0] == "Rearrange")
                {
                    if (inventory.Contains(token[1]))
                    {
                        inventory.Remove(token[1]);
                        inventory.Add(token[1]);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", inventory));
        }
    }
}