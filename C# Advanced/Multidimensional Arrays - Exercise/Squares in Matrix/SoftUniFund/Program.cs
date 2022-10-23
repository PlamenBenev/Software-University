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
            int matrixes = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                for (int k = 0; k < values.GetLength(1); k++)
                {
                    values[i, k] = token[k];
                }
            }
            for (int rows = 0; rows < values.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < values.GetLength(1) - 1; cols++)
                {
                    if (values[rows, cols] == values[rows + 1, cols] &&
                        values[rows, cols] == values[rows, cols + 1] &&
                        values[rows, cols] == values[rows + 1, cols + 1])
                    {
                        matrixes++;
                    }
                }
            }
            Console.WriteLine(matrixes);
        }
    }
}