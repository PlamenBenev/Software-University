using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < num; i++)
            {
                string[] inputWardrobe = Console.ReadLine().Split(" -> ");
                string[] token = inputWardrobe[1].Split(',');

                if (!wardrobe.ContainsKey(inputWardrobe[0]))
                {
                    wardrobe.Add(inputWardrobe[0], new Dictionary<string, int>());
                    for (int k = 0; k < token.Length; k++)
                    {
                        if (wardrobe[inputWardrobe[0]].ContainsKey(token[k]))
                        {
                            wardrobe[inputWardrobe[0]][token[k]]++;
                        }
                        else
                        {
                            wardrobe[inputWardrobe[0]].Add(token[k], 1);
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < token.Length; k++)
                    {
                        if (wardrobe[inputWardrobe[0]].ContainsKey(token[k]))
                        {
                            wardrobe[inputWardrobe[0]][token[k]]++;
                        }
                        else
                        {
                            wardrobe[inputWardrobe[0]].Add(token[k], 1);
                        }
                    }
                }
            }

            string[] input = Console.ReadLine().Split(' ');

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (color.Key == input[0] && cloth.Key == input[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}