﻿using System;
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

            while (input != "End")
            {
                string[] token = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (!junk.ContainsKey(token[0]))
                {
                    junk.Add(token[0], new List<string>() { token[1] });
                }
                else
                {
                    if (!junk[token[0]].Contains(token[1]))
                    {
                        junk[token[0]].Add(token[1]);
                    }
                }

                input = Console.ReadLine();
            }
            foreach (var item in junk)
            {
                Console.WriteLine(item.Key);
                foreach (var student in item.Value)
                {
                    Console.WriteLine("-- " + student);
                }
            }
        }
    }
}