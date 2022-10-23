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
            Dictionary<string, Dictionary<string,double>> dict =
                new Dictionary<string, Dictionary<string,double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] token = input.Split(", ");

                if (dict.ContainsKey(token[0]))
                {
                    dict[token[0]].Add(token[1], double.Parse(token[2]));
                }
                else
                {
                    Dictionary<string, double> secondDict = new Dictionary<string, double>();
                    secondDict.Add(token[1], double.Parse(token[2]));
                    dict.Add(token[0], secondDict);
                }
                input = Console.ReadLine();
            }
            var dict2 = dict.OrderBy(kvp => kvp.Key);
            foreach (var item in dict2)
            {
                Console.WriteLine(item.Key + "->");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}