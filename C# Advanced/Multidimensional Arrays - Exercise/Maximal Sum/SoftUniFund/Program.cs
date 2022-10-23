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

            int[,] values = new int[num[0], num[1]];
            int sum = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                for (int k = 0; k < values.GetLength(1); k++)
                {
                    values[i, k] = int.Parse(token[k]);
                }
            }
            int[,] topNums = new int[3, 3];
            for (int rows = 0; rows < values.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < values.GetLength(1) - 2; cols++)
                {
                    if (values[rows, cols] + values[rows, cols + 1] + values[rows, cols + 2] +
                        values[rows + 1, cols] + values[rows + 1, cols + 1] + values[rows + 1, cols + 2] +
                        values[rows + 2, cols] + values[rows + 2, cols + 1] + values[rows + 2, cols + 2] > sum)
                    {

                        sum = values[rows, cols] + values[rows, cols + 1] + values[rows, cols + 2] +
                        values[rows + 1, cols] + values[rows + 1, cols + 1] + values[rows + 1, cols + 2] +
                        values[rows + 2, cols] + values[rows + 2, cols + 1] + values[rows + 2, cols + 2];

                        topNums[0, 0] = values[rows, cols];
                        topNums[0, 1] = values[rows, cols + 1];
                        topNums[0, 2] = values[rows, cols + 2];
                        topNums[1, 0] = values[rows + 1, cols];
                        topNums[1, 1] = values[rows + 1, cols + 1];
                        topNums[1, 2] = values[rows + 1, cols + 2];
                        topNums[2, 0] = values[rows + 2, cols];
                        topNums[2, 1] = values[rows + 2, cols + 1];
                        topNums[2, 2] = values[rows + 2, cols + 2];
                    }
                }
            }
            Console.WriteLine("Sum = " + sum);
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write(topNums[i,k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}