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
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] process = input.Split(new char[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (process[0] == "Collect")
                {
                    if (!inventory.Contains(process[1]))
                    {
                        inventory.Add(process[1]);
                    }
                }
                else if (process[0] == "Drop")
                {
                    if (inventory.Contains(process[1]))
                    {
                        inventory.Remove(process[1]);
                    }
                }
                else if (process.Length > 2)
                {

                    if (inventory.Contains(process[2]))
                    {
                        int index = inventory.IndexOf(process[2]);
                        inventory.Insert(index + 1, process[3]);
                    }
                }
                else if (process[0] == "Renew")
                {
                    if (inventory.Contains(process[1]))
                    {
                        int index = inventory.IndexOf(process[1]);
                        inventory.RemoveAt(index);
                        inventory.Add(process[1]);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", inventory));
        }
    }
}