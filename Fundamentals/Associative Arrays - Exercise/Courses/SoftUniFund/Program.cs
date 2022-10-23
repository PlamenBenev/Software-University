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

            Dictionary<string, List<string>> junk = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] token = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                if (!junk.ContainsKey(token[0]))
                {
                    junk.Add(token[0], new List<string>() { token[1] });
                }
                else
                {
                    junk[token[0]].Add(token[1]);
                }

                input = Console.ReadLine();
            }
            foreach (var item in junk)
            {
                Console.WriteLine(item.Key + ": " + item.Value.Count);
                foreach (var student in item.Value)
                {
                    Console.WriteLine("-- " + student);
                }
            }
        }
    }
}