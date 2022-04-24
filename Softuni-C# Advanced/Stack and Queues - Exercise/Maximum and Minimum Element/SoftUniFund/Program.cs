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
            int num = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            if (num > 0 && num < 106)
            {
                for (int i = 0; i < num; i++)
                {
                    string[] token = Console.ReadLine().Split(' ');

                    if (token[0] == "1")
                    {
                        if (int.Parse(token[1]) < 110)
                        {
                            stack.Push(int.Parse(token[1]));
                        }
                    }
                    else if (token[0] == "2")
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                    }
                    else if (token[0] == "3")
                    {
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Max());
                    }
                    else if (token[0] == "4")
                    {
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Min());
                    }
                }
                if (stack.Count > 0)
                {
                    Console.WriteLine(String.Join(", ", stack));
                }
            }

        }
    }
}