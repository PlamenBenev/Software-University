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
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Queue<string> stack = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Enqueue(input[i]);
            }

            while (stack.Count > 0)
            {
                string[] token = Console.ReadLine().Split(' ');

                if (token[0] == "Play")
                {
                    if (stack.Count > 0)
                    {
                        stack.Dequeue();
                    }
                }
                else if (token[0] == "Add")
                {
                    string song = "";
                    for (int i = 1; i < token.Length; i++)
                    {
                        song += token[i] + " ";
                    }
                    song = song.Trim();
                    if (stack.Contains(song))
                    {
                        Console.WriteLine(song + " is already contained!");
                    }
                    else
                        stack.Enqueue(song);
                }
                else if (token[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", stack));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}