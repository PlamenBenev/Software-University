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
            int[] num = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            foreach (var item in num)
            {
                stack.Push(item);
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] token = input.ToLower().Split(' ');

                if (token[0] == "add")
                {
                    stack.Push(int.Parse(token[1]));
                    stack.Push(int.Parse(token[2]));
                }
                else if (token[0] == "remove")
                {
                    int i = int.Parse(token[1]);
                    
                    if (stack.Count > i)
                    {
                        for (int k = 0; k < i; k++)
                        {
                            stack.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }

    }
}