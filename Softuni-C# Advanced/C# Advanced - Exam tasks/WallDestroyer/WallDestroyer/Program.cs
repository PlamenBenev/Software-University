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

            char[,] board = new char[size, size];
            int[] vankosPos = new int[2];
            int hittedRods = 0;
            int countOfHoles = 1;
            bool electred = false;

            for (int row = 0; row < size; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = rowInput[col];
                    if (board[row, col] == 'V')
                    {
                        vankosPos[0] = row;
                        vankosPos[1] = col;
                    }
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                int row = vankosPos[0];
                int col = vankosPos[1];

                board[row, col] = '*';

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
                    board[vankosPos[0], vankosPos[1]] = 'V';
                    input = Console.ReadLine();
                    continue;
                }
                if (board[row, col] == 'C')
                {
                    board[row, col] = 'E';
                    countOfHoles++;
                    electred = true;
                    break;
                }
                if (board[row, col] == 'R')
                {
                    hittedRods++;
                    board[vankosPos[0], vankosPos[1]] = 'V';
                    Console.WriteLine("Vanko hit a rod!");
                    input = Console.ReadLine();
                    continue;
                }
                if (board[row, col] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
                    countOfHoles--;
                }

                countOfHoles++;
                vankosPos[0] = row;
                vankosPos[1] = col;
                board[row, col] = 'V';
                input = Console.ReadLine();
            }
            if (electred)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }
            else
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {hittedRods} rod(s).");

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write(board[r, c]);
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