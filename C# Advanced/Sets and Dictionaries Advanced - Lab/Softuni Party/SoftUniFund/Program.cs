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
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        vip.Add(input.ToString());
                    }
                    else
                    {
                        regular.Add(input.ToString());
                    }
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                if (char.IsDigit(input[0]))
                {
                    vip.Remove(input.ToString());
                }
                else
                {
                    regular.Remove(input.ToString());
                }
            }
            Console.WriteLine(vip.Count + regular.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}