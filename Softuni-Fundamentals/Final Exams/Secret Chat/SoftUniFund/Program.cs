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

            while (input != "Reveal")
            {
                string[] token = input.Split(":|:");

                if (token[0] == "InsertSpace")
                {
                    word = word.Insert(int.Parse(token[1]), " ");
                    Console.WriteLine(word);
                }
                else if (token[0] == "Reverse")
                {
                    if (word.Contains(token[1]))
                    {
                        List<char> sub = token[1].ToList();
                        sub.Reverse();
                        string ssub = "";
                        word = word.Remove(word.IndexOf(token[1]), token[1].Length);
                        foreach (char c in sub)
                        {
                            ssub += c;
                        }
                        word += ssub;
                        Console.WriteLine(word);
                    }
                    else
                        Console.WriteLine("error");
                }
                else if (token[0] == "ChangeAll")
                {
                    if (word.Contains(token[1]))
                    {
                        word = word.Replace(token[1], token[2]);
                        Console.WriteLine(word);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {word}");
        }
    }
}



