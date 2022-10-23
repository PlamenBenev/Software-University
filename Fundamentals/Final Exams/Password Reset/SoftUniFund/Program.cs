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
            string command = Console.ReadLine();
            string output = "";
            while (command != "Done")
            {
                string[] token = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "TakeOdd")
                {
                    for (int i = 1; i <= input.Length - 1; i += 2)
                    {
                        output += input[i];
                    }
                    Console.WriteLine(output);
                }
                else if (token[0] == "Cut")
                {
                    if (output.Length > 0)
                    {
                        output = output.Remove(int.Parse(token[1]), int.Parse(token[2]));
                        Console.WriteLine(output);
                    }
                    else
                    {
                        input = input.Remove(int.Parse(token[1]), int.Parse(token[2]));
                        Console.WriteLine(input);
                    }
                }
                else if (token[0] == "Substitute")
                {
                    if (output.Length > 0 && output.Contains(token[1]))
                    {
                        output = output.Replace(token[1], token[2]);
                        Console.WriteLine(output);
                    }
                    else if (input.Length > 0 && input.Contains(token[1]))
                    {
                        input = input.Replace(token[1], token[2]);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                command = Console.ReadLine();
            }
            if (output.Length > 0)
            {
                Console.WriteLine($"Your password is: {output}");
            }
            else
            {
                Console.WriteLine($"Your password is: {input}");
            }
        }
    }
}