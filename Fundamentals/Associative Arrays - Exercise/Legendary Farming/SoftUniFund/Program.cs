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
            Dictionary<string, int> dic = new Dictionary<string, int>()
            {
                {"shards", 0 },
                {"motes", 0 },
                {"fragments", 0 }
            };
            Dictionary<string, int> junk = new Dictionary<string, int>();
            string input1 = Console.ReadLine();
            bool breaker = false;
            while (breaker == false)
            {
                string[] input = input1.ToLower().Split(' ');

                for (int i = 0; i < input.Length; i += 2)
                {
                    int value = int.Parse(input[i]);

                    if (input[i + 1] == "shards" || input[i + 1] == "fragments" || input[i + 1] == "motes")
                    {
                        dic[input[i + 1]] += value;
                    }
                    else
                    {
                        if (!junk.ContainsKey(input[i + 1]))
                        {
                            junk.Add(input[i + 1], value);
                        }
                        else
                            junk[input[i + 1]] += value;
                    }
                    if (dic.ContainsKey(input[i + 1]) && dic[input[i + 1]] >= 250)
                    {
                        if (input[i + 1] == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");

                        }
                        else if (input[i + 1] == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");

                        }
                        else if (input[i + 1] == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");

                        }
                        dic[input[i + 1]] -= 250;
                        breaker = true;
                    }
                    if (breaker == true)
                    {
                        break;
                    }
                }
                input1 = Console.ReadLine();
            }

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            foreach (var item in junk)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}