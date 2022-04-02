using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] token = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "Add Stop")
                {
                    if (int.Parse(token[1]) < word.Length && int.Parse(token[1]) >= 0)
                    {
                        word = word.Insert(int.Parse(token[1]), token[2]);
                    }
                }
                else if (token[0] == "Remove Stop")
                {
                    int start = int.Parse(token[1]);
                    int end = int.Parse(token[2]) - start;

                    if (start >= 0 && end < word.Length - 1 && end >= 0 && start < word.Length)
                    {
                        word = word.Remove(start, end + 1);
                    }
                }
                else if (token[0] == "Switch")
                {
                    if (word.Contains(token[1]))
                    {
                        word = word.Replace(token[1], token[2]);
                    }
                }
                Console.WriteLine(word);
                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {word}");
        }
    }
}