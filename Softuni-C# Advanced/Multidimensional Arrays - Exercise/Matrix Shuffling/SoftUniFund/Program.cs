using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string[,] values = new string[num[0], num[1]];
            int sum = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                for (int k = 0; k < values.GetLength(1); k++)
                {
                    values[i, k] = (token[k]);
                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] token = input.Split(' ');

                if (token.Length != 5 || token[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                int row1 = int.Parse(token[1]);
                int col1 = int.Parse(token[2]);
                int row2 = int.Parse(token[3]);
                int col2 = int.Parse(token[4]);


                if (row1 < values.GetLength(0) && row2 < values.GetLength(0) &&
                    col1 < values.GetLength(1) && col2 < values.GetLength(1) &&
                    row1 >= 0 && row2 >= 0 && col1 >= 0 && col2 >= 0)
                {
                    string replaced = values[row1, col1];
                    values[row1, col1] = values[row2, col2];
                    values[row2, col2] = replaced;

                    for (int i = 0; i < values.GetLength(0); i++)
                    {
                        for (int k = 0; k < values.GetLength(1); k++)
                        {
                            Console.Write(values[i,k] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Invalid input!");

                input = Console.ReadLine();
            }
        }
    }
}