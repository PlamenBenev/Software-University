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

            string[] token = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < token.Length; i++)
            {
                bool check = false;
                if (token[i].Length > 3 && token[i].Length < 16)
                {
                    foreach (var item in token[i])
                    {
                        if (char.IsLetterOrDigit(item) || item == '-' || item == '_')
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                }
                if (check)
                    Console.WriteLine(token[i]);
            }
        }
    }
}