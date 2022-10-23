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
            Dictionary<string, int> dic = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                int value = int.Parse(Console.ReadLine());

                if (!dic.ContainsKey(input))
                {
                    dic.Add(input, value);
                }
                else
                    dic[input] += value;

                input = Console.ReadLine();
            }
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}