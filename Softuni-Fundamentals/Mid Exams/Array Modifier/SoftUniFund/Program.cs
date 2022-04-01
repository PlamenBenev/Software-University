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

            List<int> kvartala = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] token = input.Split(' ');
                int index2 = 0;
                int index1 = 0;
                if (token.Length > 1)
                {
                    index2 = int.Parse(token[2]);
                    index1 = int.Parse(token[1]);
                }

                if (token[0] == "swap")
                {
                    int num1 = kvartala[index1];
                    int num2 = kvartala[index2];
                    kvartala.Insert(index1, num2);
                    kvartala.RemoveAt(index1 + 1);
                    kvartala.Insert(index2, num1);
                    kvartala.RemoveAt(index2 + 1);
                }
                else if (token[0] == "multiply")
                {
                    kvartala[index1] = kvartala[index1] * kvartala[index2];
                }
                else if (token[0] == "decrease")
                {
                    for (int i = 0; i < kvartala.Count; i++)
                    {
                        kvartala[i] -= 1;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", kvartala));
        }

    }
}