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

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    for (int k = stack.Peek(); k <= i; k++)
                    {
                        Console.Write(input[k]);
                    }
                    stack.Pop();
                    Console.WriteLine();
                }
            }
        }

    }
}