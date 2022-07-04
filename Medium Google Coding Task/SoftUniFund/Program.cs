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
            char[,] newBoard = new char[size, size];
            /* 
              The exemple input
               6
               100000
               010111
               001010
               111111
               101100
               100001
             */
            Dest dest = new Dest();

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                }
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    newBoard[row, col] = '0';
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (IsItBorder(row, col, size) && board[row, col] == '1')
                    {
                        newBoard[row, col] = '1';
                        dest.Recursion(board, row, col);
                    }
                }
            }
            foreach (var item in dest.Islands)
            {
                newBoard[item[0], item[1]] = '1';
            }
            Console.WriteLine();
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(newBoard[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsItBorder(int row, int col, int size)
        {
            if (row == 0 || row == size - 1 ||
                col == 0 || col == size - 1)
            {
                return true;
            }
            return false;
        }
    }
    public class Dest
    {
        public List<int[]> Islands { get; set; } = new List<int[]>();

        public void Recursion(char[,] board, int row, int col)
        {
            if (IsItInside(row, col, board.GetLength(0)))
            {
                if (board[row, col] == '1')
                {
                    bool itsThere = false;
                    foreach (var item in Islands)
                    {
                        if (item[0] == row && item[1] == col)
                        {
                            itsThere = true;
                            break;
                        }
                    }
                    if (!itsThere)
                    {
                        Islands.Add(new int[] { row, col });

                        Recursion(board, row + 1, col);

                        Recursion(board, row - 1, col);

                        Recursion(board, row, col + 1);

                        Recursion(board, row, col - 1);
                    }
                }
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