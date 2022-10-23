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
            string input = Console.ReadLine();

            string[] token = input.Split('\\', StringSplitOptions.RemoveEmptyEntries);

            string[] splitter = token[token.Length - 1].Split('.');
            Console.WriteLine($"File name: {splitter[0]}");
            Console.WriteLine($"File extension: {splitter[1]}");
        }
    }
}