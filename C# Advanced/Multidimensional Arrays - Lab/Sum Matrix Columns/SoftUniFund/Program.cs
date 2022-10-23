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
            int[] rowscols = Console.ReadLine()
                 .Split(", ")
                 .Select(int.Parse)
                 .ToArray();

            int rows = rowscols[0];
            int cols = rowscols[1];

            int[,] vs = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                int[] row = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
                for (int k = 0; k < cols; k++)
                {
                    vs[r, k] = row[k];
                }
            }
            for (int r = 0; r < vs.GetLength(1); r++)
            {
                int sum = 0;
                for (int i = 0; i < vs.GetLength(0); i++)
                {
                    sum += vs[i,r];
                }
                Console.WriteLine(sum);
            }
        }
    }
}