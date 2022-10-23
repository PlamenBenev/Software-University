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
                 .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();
            inventory[0] = " " + inventory[0];

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(',');

                if (input[0] == "Add")
                {
                    if (!inventory.Contains(input[1]))
                    {
                        inventory.Add(input[1]);
                        Console.WriteLine("Card successfully added");
                    }
                    else
                    {
                        Console.WriteLine("Card is already in the deck");
                    }
                }
                else if (input[0] == "Remove")
                {
                    if (inventory.Contains(input[1]))
                    {
                        inventory.Remove(input[1]);
                        Console.WriteLine("Card successfully removed");

                    }
                    else
                        Console.WriteLine("Card not found");
                }
                else if (input[0] == "Remove At")
                {
                    int index = int.Parse(input[1]);
                    if (index >= 0 && index < inventory.Count)
                    {
                        inventory.RemoveAt(index);
                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (input[0] == "Insert")
                {
                    int index = int.Parse(input[1]);
                    if (!inventory.Contains(input[2]) && index >= 0 && index < inventory.Count)
                    {
                        inventory.Insert(index, input[2]);
                        Console.WriteLine("Card successfully added");
                    }
                    else if (index < 0 || index >= inventory.Count)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else if (index >= 0 && index < inventory.Count && inventory.Contains(input[2]))
                    {
                        Console.WriteLine("Card is already added");
                    }
                }
            }
            Console.WriteLine(String.Join(',', inventory));
        }

    }
}