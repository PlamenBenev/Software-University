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
            string output = "";
            foreach (var item in input)
            {
                if (output.Length > 0)
                {
                    if (output.Last() != item)
                    {
                        output += item;
                    }
                }
                else
                {
                    output += item;
                }
            }
            Console.WriteLine(output);
        }
    }
}