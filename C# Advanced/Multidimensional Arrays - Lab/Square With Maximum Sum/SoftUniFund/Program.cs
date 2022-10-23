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
            int[] num = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = num[0];
            int cols = num[1];

            int[,] cells = new int[rows, cols];
            // fill the cells
            for (int r = 0; r < rows; r++)
            {
                int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int k = 0; k < cols; k++)
                {
                    cells[r, k] = input[k];
                }
            }
            int sum = 0;
            int[,] topCells = new int[2, 2];
            for (int r = 0; r < cells.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < cells.GetLength(1) - 1; c++)
                {
                    if (cells[r, c] + cells[r + 1,c] + cells[r , c + 1] + cells[r + 1, c + 1] > sum)
                    {
                        sum = cells[r, c] + cells[r + 1, c] + cells[r, c + 1] + cells[r + 1, c + 1];
                        topCells[0, 0] = cells[r, c];
                        topCells[0, 1] = cells[r, c + 1];
                        topCells[1, 0] = cells[r + 1, c];
                        topCells[1, 1] = cells[r + 1, c + 1];
                    }
                }
            }
            Console.WriteLine(topCells[0,0] + " " + topCells[0, 1]);
            Console.WriteLine(topCells[1, 0] + " " + topCells[1, 1]);
            Console.WriteLine(sum);
        }
    }
}