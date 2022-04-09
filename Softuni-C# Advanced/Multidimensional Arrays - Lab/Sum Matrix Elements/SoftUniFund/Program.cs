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
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
                for (int k = 0; k < cols; k++)
                {
                    vs[i, k] = row[k];
                    sum += vs[i, k];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}