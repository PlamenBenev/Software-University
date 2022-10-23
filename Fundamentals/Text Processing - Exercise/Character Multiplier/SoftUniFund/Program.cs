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
            string[] token = input.Split(' ');
            int sum = 0;
            int num = 0;
            int rest = 0;
            if (token[0].Length < token[1].Length)
            {
                num = token[0].Length;
                rest = token[1].Length - num;
                for (int i = token[1].Length - 1; i > token[1].Length - 1 - rest; i--)
                {
                    sum += token[1][i];
                }
            }
            else
            {
                num = token[1].Length;
                rest = token[0].Length - num;
                for (int i = token[0].Length - 1; i > token[0].Length - 1 - rest; i--)
                {
                    sum += token[0][i];
                }
            }
            for (int i = 0; i < num; i++)
            {
                sum += token[0][i] * token[1][i];
            }
            Console.WriteLine(sum);
        }
    }
}