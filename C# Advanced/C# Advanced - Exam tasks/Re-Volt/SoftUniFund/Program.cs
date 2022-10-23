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
            int num = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];
            int[] playerPos = new int[2];
            
            bool finished = false;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                    if (board[row, col] == 'f')
                    {
                        playerPos[0] = row;
                        playerPos[1] = col;
                    }
                }
            }

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                int row = playerPos[0];
                int col = playerPos[1];

                board[row, col] = '-';

                if (input == "left")
                {
                    col--;
                    if (!IsItInside(row, col, size))
                    {
                        col = size - 1;
                    }
                    if (board[row, col] == 'B')
                    {
                        col--;
                        if (!IsItInside(row, col, size))
                        {
                            col = size - 1;
                        }
                    }
                    else if (board[row, col] == 'T')
                    {
                        col++;
                    }
                }
                else if (input == "right")
                {
                    col++;
                    if (!IsItInside(row, col, size))
                    {
                        col = 0;
                    }
                    if (board[row, col] == 'B')
                    {
                        col++;
                        if (!IsItInside(row, col, size))
                        {
                            col = 0;
                        }
                    }
                    else if (board[row, col] == 'T')
                    {
                        col--;
                    }
                }
                else if (input == "up")
                {
                    row--;
                    if (!IsItInside(row, col, size))
                    {
                        row = size - 1;
                    }
                    if (board[row, col] == 'B')
                    {
                        row--;
                        if (!IsItInside(row, col, size))
                        {
                            row = size - 1;
                        }
                    }
                    else if (board[row, col] == 'T')
                    {
                        row++;
                    }
                }
                else if (input == "down")
                {
                    row++;
                    if (!IsItInside(row, col, size))
                    {
                        row = 0;
                    }
                    if (board[row, col] == 'B')
                    {
                        row++;
                        if (!IsItInside(row, col, size))
                        {
                            row = 0;
                        }
                    }
                    else if (board[row, col] == 'T')
                    {
                        row--;
                    }
                }

                if (board[row, col] == 'F')
                {
                    playerPos[0] = row;
                    playerPos[1] = col;
                    board[row, col] = 'f';
                    finished = true;
                    break;
                }

                playerPos[0] = row;
                playerPos[1] = col;
                board[row, col] = 'f';
            }
            if (!finished)
            {
                Console.WriteLine("Player lost!");
            }
            else
                Console.WriteLine("Player won!");

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