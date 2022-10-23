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
            string[,] realBoard = new string[8, 8];
            string[] rowInput = new string[8]
            { "a8 b8 c8 d8 e8 f8 g8 h8" ,
              "a7 b7 c7 d7 e7 f7 g7 h7" ,
              "a6 b6 c6 d6 e6 f6 g6 h6" ,
              "a5 b5 c5 d5 e5 f5 g5 h5" ,
              "a4 b4 c4 d4 e4 f4 g4 h4" ,
              "a3 b3 c3 d3 e3 f3 g3 h3" ,
              "a2 b2 c2 d2 e2 f2 g2 h2" ,
              "a1 b1 c1 d1 e1 f1 g1 h1" };
            for (int numRow = 0; numRow < 8; numRow++)
            {
                string[] input = rowInput[numRow].Split(' ');
                for (int letterCol = 0; letterCol < 8; letterCol++)
                {
                    realBoard[numRow, letterCol] = input[letterCol];
                }
            }

            char[,] board = new char[8, 8];

            int[] wPosition = new int[2];
            int[] bPosition = new int[2];

            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = input[col];
                    if (board[row, col] == 'w')
                    {
                        wPosition[0] = row;
                        wPosition[1] = col;
                    }
                    if (board[row, col] == 'b')
                    {
                        bPosition[0] = row;
                        bPosition[1] = col;
                    }
                }
            }

            bool wWin = false;
            bool bWin = false;

            while (wPosition[0] != 0 && bPosition[0] != 7)
            {
                int wRow = wPosition[0];
                int wCol = wPosition[1];
                int bRow = bPosition[0];
                int bCol = bPosition[1];

                board[wRow, wCol] = '-';
                wRow--;

                if (IsItInside(wRow, wCol - 1) && char.IsLetter(board[wRow, wCol - 1]))
                {
                    wCol--;
                    wWin = true;
                    wPosition[0] = wRow;
                    wPosition[1] = wCol;
                    break;
                }
                else if (IsItInside(wRow, wCol + 1) && char.IsLetter(board[wRow, wCol + 1]))
                {
                    wCol++;
                    wWin = true;
                    wPosition[0] = wRow;
                    wPosition[1] = wCol;
                    break;
                }
                else
                {
                    board[wRow, wCol] = 'w';
                    wPosition[0] = wRow;
                    wPosition[1] = wCol;
                    if (wRow == 0)
                    {
                        break;
                    }
                }

                board[bRow, bCol] = '-';
                bRow++;

                if (IsItInside(bRow, bCol - 1) && char.IsLetter(board[bRow, bCol - 1]))
                {
                    bCol--;
                    bWin = true;
                    bPosition[0] = bRow;
                    bPosition[1] = bCol;
                    break;
                }
                else if (IsItInside(bRow, bCol + 1) && char.IsLetter(board[bRow, bCol + 1]))
                {
                    bCol++;
                    bWin = true;
                    bPosition[0] = bRow;
                    bPosition[1] = bCol;
                    break;
                }
                else
                {
                    board[bRow, bCol] = 'b';
                    bPosition[0] = bRow;
                    bPosition[1] = bCol;
                }
            }
            if (wWin)
            {
                Console.WriteLine($"Game over! White capture on {realBoard[wPosition[0], wPosition[1]]}.");
            }
            else if (bWin)
            {
                Console.WriteLine($"Game over! Black capture on {realBoard[bPosition[0], bPosition[1]]}.");
            }
            else if (wPosition[0] == 0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {realBoard[wPosition[0], wPosition[1]]}.");
            }
            else if (bPosition[0] == 7)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {realBoard[bPosition[0], bPosition[1]]}.");
            }
        }
        public static bool IsItInside(int row, int col)
        {
            if (row >= 0 && row < 8 &&
                col >= 0 && col < 8)
            {
                return true;
            }
            return false;
        }
    }
}