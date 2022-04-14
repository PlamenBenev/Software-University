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
            HashSet<string> set = new HashSet<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] token = input.Split(", ");

                if (token[0] == "IN")
                {
                    set.Add(token[1]);
                }
                else if (token[0] == "OUT")
                {
                    set.Remove(token[1]);
                }

                input = Console.ReadLine();
            }
            if (set.Count > 0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}