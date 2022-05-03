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
            string test = "";
            for (int i = 0; i < input.Length; i++)
            {
                test += ((char)(input[i] + 3));
            }
            test = test.ToString();
            Console.WriteLine(test);
        }
    }
}