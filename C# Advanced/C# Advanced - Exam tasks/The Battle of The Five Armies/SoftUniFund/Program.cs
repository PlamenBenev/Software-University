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
            int colsize = 0;

            char[][] board = new char[size][];
            int[] armyPos = new int[2];
            bool theyMadeIt = false;

            for (int row = 0; row < size; row++)
            {
                string input1 = Console.ReadLine();
                board[row] = new char[input1.Length];
                colsize = input1.Length;
                for (int col = 0; col < input1.Length; col++)
                {
                    board[row][col] = input1[col];
                    if (board[row][col] == 'A')
                    {
                        armyPos[0] = row;
                        armyPos[1] = col;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int orcsRow = int.Parse(input[1]);
                int orcsCol = int.Parse(input[2]);
                int armyRow = armyPos[0];
                int armyCol = armyPos[1];

                board[orcsRow][orcsCol] = 'O';
                board[armyRow][armyCol] = '-';

                if (input[0] == "left")
                {
                    armyCol--;
                }
                else if (input[0] == "right")
                {
                    armyCol++;
                }
                else if (input[0] == "up")
                {
                    armyRow--;
                }
                else if (input[0] == "down")
                {
                    armyRow++;
                }

                if (!IsItInside(armyRow,armyCol,size,colsize))
                {
                    armyRow = armyPos[0];
                    armyCol = armyPos[1];
                    board[armyRow][armyCol] = 'A';
                    armor--;
                    continue;
                }

                armor--;

                if (board[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                }
                else if (board[armyRow][armyCol] == 'M')
                {
                    board[armyRow][armyCol] = '-';
                    theyMadeIt = true;
                    break;
                }
                if (armor <= 0)
                {
                    armyPos[0] = armyRow;
                    armyPos[1] = armyCol;
                    board[armyRow][armyCol] = 'X';
                    break;
                }
                armyPos[0] = armyRow;
                armyPos[1] = armyCol;
                board[armyRow][armyCol] = 'A';
            }
            if (theyMadeIt)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {armyPos[0]};{armyPos[1]}.");
            }
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < colsize; c++)
                {
                    Console.Write(board[r][c]);
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