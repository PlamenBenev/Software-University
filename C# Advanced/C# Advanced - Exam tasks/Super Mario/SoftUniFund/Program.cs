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
            int hp = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[][] board = new char[size][];
            int[] marioPos = new int[2];
            bool youWon = false;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                board[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    board[row][col] = input[col];
                    if (board[row][col] == 'M')
                    {
                        marioPos[0] = row;
                        marioPos[1] = col;
                    }
                }
            }

            while (hp > 0)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = marioPos[0];
                int col = marioPos[1];
                int enemyRow = int.Parse(input[1]);
                int enemyCol = int.Parse(input[2]);

                board[row][col] = '-';

                board[enemyRow][enemyCol] = 'B';

                if (input[0] == "A")
                {
                    col--;
                }
                else if (input[0] == "D")
                {
                    col++;
                }
                else if (input[0] == "W")
                {
                    row--;
                }
                else if (input[0] == "S")
                {
                    row++;
                }
                else
                {
                    continue;
                }

                hp--;

                if (!IsItInside(row, col, size,board[0]))
                {
                    row = marioPos[0];
                    col = marioPos[1];
                    board[row][col] = 'M';
                }

                if (board[row][col] == 'B')
                {
                    hp -= 2;
                }
                if (hp <= 0)
                {
                    board[row][col] = 'X';
                    marioPos[0] = row;
                    marioPos[1] = col;
                    break;
                }
                if (board[row][col] == 'P')
                {
                    youWon = true;
                    board[row][col] = '-';
                    break;
                }

                marioPos[0] = row;
                marioPos[1] = col;
                board[row][col] = 'M';
            }
            if (youWon)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {hp}");
            }
            else
                Console.WriteLine($"Mario died at {marioPos[0]};{marioPos[1]}.");

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    Console.Write(board[r][c]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsItInside(int row, int col, int size, char[] arr)
        {
            if (row >= 0 && row < size &&
                col >= 0 && col < arr.Length)
            {
                return true;
            }
            return false;
        }
    }
}