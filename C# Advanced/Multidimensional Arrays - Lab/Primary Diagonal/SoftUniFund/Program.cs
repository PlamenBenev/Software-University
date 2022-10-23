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
            int num = int.Parse(Console.ReadLine());

            int rows = num;
            int cols = num;

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
                int sum = 0;
            for (int r = 0; r < vs.GetLength(1); r++)
            {
                for (int c = r; c < vs.GetLength(0); c++)
                {
                    sum += vs[c,r];
                    break;
                }
            }
                Console.WriteLine(sum);
        }
    }
}