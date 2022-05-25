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
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int cols = 0;
            string input1 = Console.ReadLine();
            cols = input1.Length;

            char[,] board = new char[size, cols];
            int[] armyPos = new int[2];
            bool theyMadeIt = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input1[col];
                    if (board[row, col] == 'A')
                    {
                        armyPos[0] = row;
                        armyPos[1] = col;
                    }
                }
                if (row + 1 == size)
                {
                    break;
                }
                input1 = Console.ReadLine();
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int orcsRow = int.Parse(input[1]);
                int orcsCol = int.Parse(input[2]);
                int armyRow = armyPos[0];
                int armyCol = armyPos[1];

                board[orcsRow, orcsCol] = 'O';
                board[armyRow, armyCol] = '-';

                if (input[0] == "left" && IsItInside(armyRow, armyCol - 1, size, board.GetLength(1)))
                {
                    armyCol--;
                }
                else if (input[0] == "right" && IsItInside(armyRow, armyCol + 1, size, board.GetLength(1)))
                {
                    armyCol++;
                }
                else if (input[0] == "up" && IsItInside(armyRow - 1, armyCol, size, board.GetLength(1)))
                {
                    armyRow--;
                }
                else if (input[0] == "down" && IsItInside(armyRow + 1, armyCol, size,board.GetLength(1)))
                {
                    armyRow++;
                }
                else
                {
                    armor--;
                    continue;
                }

                armor--;

                if (armyRow == orcsRow && armyCol == orcsCol)
                {
                    armor -= 2;
                }
                if (board[armyRow, armyCol] == 'M')
                {
                    board[armyRow, armyCol] = '-';
                    theyMadeIt = true;
                    break;
                }
                if (armor <= 0)
                {
                    armyPos[0] = armyRow;
                    armyPos[1] = armyCol;
                    board[armyRow, armyCol] = 'X';
                    break;
                }
                armyPos[0] = armyRow;
                armyPos[1] = armyCol;
                board[armyRow, armyCol] = 'A';
            }
            if (theyMadeIt)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {armyPos[0]};{armyPos[1]}.");
            }
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    Console.Write(board[r, c]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsItInside(int row, int col, int size, int colSize)
        {
            if (row >= 0 && row < size &&
                col >= 0 && col < colSize)
            {
                return true;
            }
            return false;
        }
    }
}