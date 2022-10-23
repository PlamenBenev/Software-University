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
            int[] kingPos = new int[2];
            List<int> mirrorPos = new List<int>();

            int goldEarned = 0;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                    if (board[row, col] == 'A')
                    {
                        kingPos[0] = row;
                        kingPos[1] = col;
                    }
                    if (board[row, col] == 'M')
                    {
                        mirrorPos.Add(row);
                        mirrorPos.Add(col);
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                int kingRow = kingPos[0];
                int kingCol = kingPos[1];

                int mirrorRow1 = 0;
                int mirrorCol1 = 0;
                int mirrorRow2 = 0;
                int mirrorCol2 = 0;

                if (mirrorPos.Count > 0)
                {
                    mirrorRow1 = mirrorPos[0];
                    mirrorCol1 = mirrorPos[1];
                    mirrorRow2 = mirrorPos[2];
                    mirrorCol2 = mirrorPos[3];
                }

                board[kingRow, kingCol] = '-';

                if (input == "left")
                {
                    kingCol--;
                }
                else if (input == "right")
                {
                    kingCol++;
                }
                else if (input == "up")
                {
                    kingRow--;
                }
                else if (input == "down")
                {
                    kingRow++;
                }

                if (!IsItInside(kingRow, kingCol, size))
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }

                if (board[kingRow, kingCol] == 'M')
                {
                    board[kingRow, kingCol] = '-';
                    if (kingCol == mirrorCol1)
                    {
                        kingCol = mirrorCol2;
                    }
                    else if (kingCol == mirrorCol2)
                    {
                        kingCol = mirrorCol1;
                    }
                    if (kingRow == mirrorRow1)
                    {
                        kingRow = mirrorRow2;
                    }
                    else if (kingRow == mirrorRow2)
                    {
                        kingRow = mirrorRow1;
                    }
                }


                if (char.IsDigit(board[kingRow, kingCol]))
                {
                    goldEarned += int.Parse(board[kingRow, kingCol].ToString());
                    if (goldEarned > 64)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        board[kingRow, kingCol] = 'A';
                        break;
                    }
                }

                kingPos[0] = kingRow;
                kingPos[1] = kingCol;
                board[kingRow, kingCol] = 'A';
            }

            Console.WriteLine($"The king paid {goldEarned} gold coins.");
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    Console.Write(board[i, k]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsItInside(int row, int col, int size)
        {
            if (row >= 0 && col >= 0 &&
                col < size && row < size)
            {
                return true;
            }
            return false;
        }
    }
}