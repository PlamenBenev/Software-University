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
            int[] myPos = new int[2];
            List<int> pillarPos1 = new List<int>();
            int[] pillarPos2 = new int[2];

            int dollars = 0;
            bool imOut = false;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row,col] = input[col];
                    if (board[row,col] == 'S')
                    {
                        myPos[0] = row;
                        myPos[1] = col;
                    }
                    if (board[row, col] == 'O')
                    {
                        if (pillarPos1.Count == 0)
                        {
                            pillarPos1.Add(row);
                            pillarPos1.Add(col);
                        }
                        else
                        {
                            pillarPos2[0] = row;
                            pillarPos2[1] = col;
                        }
                    }
                }
            }

            while (dollars < 50)
            {
                string input = Console.ReadLine();
                int row = myPos[0];
                int col = myPos[1];

                board[row, col] = '-';

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
                    imOut = true;
                    break;
                }
                if (char.IsDigit(board[row,col]))
                {
                    dollars += int.Parse(board[row, col].ToString());
                }
                else if (board[row,col] == 'O')
                {
                    board[row,col] = '-';
                    if (row == pillarPos1[0] && col == pillarPos1[1])
                    {
                        row = pillarPos2[0];
                        col = pillarPos2[1];
                    }
                    else if (row == pillarPos2[0] && col == pillarPos2[1])
                    {
                        row = pillarPos1[0];
                        col = pillarPos1[1];
                    }
                }
                myPos[0] = row;
                myPos[1] = col;
                board[row, col] = 'S';
            }
            if (imOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            if (dollars >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {dollars}");
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