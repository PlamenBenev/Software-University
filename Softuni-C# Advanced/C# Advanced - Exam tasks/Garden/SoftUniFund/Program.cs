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
            int[] input1 = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowSize = input1[0];
            int colSize = input1[1];

            int[,] board = new int[input1[0],input1[1]];

            for (int row = 0; row < input1[0]; row++)
            {
                for (int col = 0; col < input1[1]; col++)
                {
                    board[row, col] = 0;
                }
            }

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Bloom")
            {
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                if (IsItInside(row,col,input1[0],input1[1]))
                {
                    for (int rows = 0; rows < rowSize; rows++)
                    {
                        board[rows, col]++;
                    }
                    for (int cols = 0; cols < colSize; cols++)
                    {
                        if (cols == col)
                        {
                            continue;
                        }
                        board[row, cols]++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            for (int r = 0; r < rowSize; r++)
            {
                for (int c = 0; c < colSize; c++)
                {
                    Console.Write(board[r,c] + " ");
                }
                Console.WriteLine();
            }
        }
        public static bool IsItInside(int row, int col, int rowSize, int colSize)
        {
            if (row >= 0 && row < rowSize &&
                col >= 0 && col < colSize)
            {
                return true;
            }
            return false;
        }
    }
}