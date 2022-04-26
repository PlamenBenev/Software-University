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

            while (input != "Finish")
            {
                string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "Replace")
                {
                    word = word.Replace(token[1], token[2]);
                    Console.WriteLine(word);
                }
                else if (token[0] == "Cut")
                {
                    int start = int.Parse(token[1]);
                    int end = int.Parse(token[2]);
                    if (start >= 0 && start < word.Length - 1 && end > 0 && end < word.Length)
                    {
                        int s = end - start;
                        word = word.Remove(start, s + 1);
                        Console.WriteLine(word);
                    }
                    else
                        Console.WriteLine("Invalid indices!");
                }
                else if (token[0] == "Make")
                {
                    if (token[1] == "Upper")
                    {
                        word = word.ToUpper();
                    }
                    else if (token[1] == "Lower")
                    {
                        word = word.ToLower();
                    }
                    Console.WriteLine(word);
                }
                else if (token[0] == "Check")
                {
                    if (word.Contains(token[1]))
                    {
                        Console.WriteLine($"Message contains {token[1]}");
                    }
                    else
                        Console.WriteLine($"Message doesn't contain {token[1]}");
                }
                else if (token[0] == "Sum")
                {
                    int start = int.Parse(token[1]);
                    int end = int.Parse(token[2]);
                    int sum = 0;
                    if (start >= 0 && start < word.Length - 1 && end > 0 && end < word.Length)
                    {
                        for (int i = start; i <= end; i++)
                        {
                            sum += char.Parse(word[i].ToString());
                        }
                        Console.WriteLine(sum);
                    }
                    else
                        Console.WriteLine("Invalid indices!");
                }
                input = Console.ReadLine();
            }
        }
    }
}