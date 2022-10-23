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

            Dictionary<string, string> junk = new Dictionary<string, string>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //  string plate = token[2];
                if (token[0] == "register")
                {
                    if (junk.ContainsKey(token[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {token[2]}");
                    }
                    else
                    {
                        junk.Add(token[1], token[2]);
                        Console.WriteLine($"{token[1]} registered {token[2]} successfully");
                    }
                }
                else if (token[0] == "unregister")
                {
                    if (!junk.ContainsKey(token[1]))
                    {
                        Console.WriteLine($"ERROR: user {token[1]} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{token[1]} unregistered successfully");
                        junk.Remove(token[1]);
                    }
                }
            }
            foreach (var item in junk)
            {
                Console.WriteLine(item.Key + " => " + item.Value);
            }
        }
    }
}