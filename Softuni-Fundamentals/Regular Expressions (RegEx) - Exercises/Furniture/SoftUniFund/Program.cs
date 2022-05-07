using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern =
                @"\>{2}([A-Z|a-z]+)\<{2}([0-9]+.[0-9]+|[0-9]+)!([0-9]+)";

            Regex rgx = new Regex(pattern);

            string input = Console.ReadLine();

            List<string> output = new List<string>();

            double price = 0;

            while (input != "Purchase")
            {
                Match match = rgx.Match(input);
                if (match.Success)
                {
                    string str = match.Groups[1].ToString();
                    output.Add(str);
                    price += double.Parse(match.Groups[2].ToString()) * int.Parse(match.Groups[3].ToString());
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {price:f2}");
            /*
               >>Sofa<<312.23!3
               >>TV<<300!5
               >Invalid<<!5
               Purchase
            */
        }

    }
}