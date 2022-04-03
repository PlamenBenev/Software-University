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
            List<int> kvartala = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] token = input.Split(' ');
                int index1 = int.Parse(token[1]);
                int index2 = int.Parse(token[2]);

                if (token[0] == "Shoot")
                {

                    if (index1 >= 0 && index1 < kvartala.Count)
                    {
                        kvartala[index1] -= index2;
                        if (kvartala[index1] <= 0)
                        {
                            kvartala.Remove(kvartala[index1]);
                        }
                    }
                }
                else if (token[0] == "Add")
                {
                    if (index1 >= 0 && index1 < kvartala.Count)
                    {
                        kvartala.Insert(index1, index2);
                    }
                    else
                        Console.WriteLine("Invalid placement!");
                }
                else if (token[0] == "Strike")
                {
                    int start = index1 - index2;
                    int end = index1 + index2;
                    if (start < 0 || end >= kvartala.Count)
                    {
                        Console.WriteLine("Strike missed!");

                    }
                    else
                        for (int i = start; i <= end; i++)
                        {
                            kvartala.RemoveAt(start);
                        }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join('|', kvartala));
        }

    }
}