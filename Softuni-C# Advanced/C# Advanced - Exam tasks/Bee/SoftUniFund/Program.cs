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
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size,size];
            int[] beePos = new int[2];
            int flowers = 0;

            for (int row = 0; row < size; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = rowInput[col];
                    if (board[row, col] == 'B')
                    {
                        beePos[0] = row;
                        beePos[1] = col;
                    }
                }
            }
            string input = Console.ReadLine();

            while (input != "End")
            {
                int row = beePos[0];
                int col = beePos[1];
                board[row, col] = '.';

                if (input == "left")
                {
                    col--;
                }
                else if (input == "right")
                {
                    col++;
                }
                else if (input == "up")
                {
                    row--;
                }
                else if (input == "down")
                {
                    row++;
                }

                if (!IsItInside(row,col,size))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (board[row,col] == 'O')
                {
                    board[row, col] = '.';
                    if (input == "left")
                    {
                        col--;
                    }
                    else if (input == "right")
                    {
                        col++;
                    }
                    else if (input == "up")
                    {
                        row--;
                    }
                    else if (input == "down")
                    {
                        row++;
                    }
                    if (!IsItInside(row, col, size))
                    {
                        break;
                    }
                }
                if (board[row,col] == 'f')
                {
                    flowers++;
                }
                beePos[0] = row;
                beePos[1] = col;
                board[row, col] = 'B';

                input = Console.ReadLine();
            }
            if (flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write(board[r,c]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsItInside(int row, int col, int size)
        {
            if (row >= 0 && row < size &&
                col >= 0 && col < size)
            {
                return true;
            }
            return false;
        }
    }
}