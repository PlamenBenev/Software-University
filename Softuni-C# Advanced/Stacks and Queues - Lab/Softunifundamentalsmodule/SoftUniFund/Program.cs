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

            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                stack.Push(item);
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }

    }
}