using System;
using System.Globalization;
using System.Collections.Generic;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string name = "";
                string age = "";
                int nameStartindex = 0;
                int nameEndindex = 0;
                int ageStartindex = 0;
                int ageEndindex = 0;
                for (int k = 0; k < input.Length; k++)
                {
                    if (input[k] == '@')
                    {
                        nameStartindex = k;
                    }
                    else if (input[k] == '|')
                    {
                        nameEndindex = k;
                    }
                    else if (input[k] == '#')
                    {
                        ageStartindex = k;
                    }
                    else if (input[k] == '*')
                    {
                        ageEndindex = k;
                    }
                }

                for (int n = nameStartindex + 1; n < nameEndindex; n++)
                {
                    name += input[n];
                }
                for (int a = ageStartindex + 1; a < ageEndindex; a++)
                {
                    age += input[a];
                }
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}