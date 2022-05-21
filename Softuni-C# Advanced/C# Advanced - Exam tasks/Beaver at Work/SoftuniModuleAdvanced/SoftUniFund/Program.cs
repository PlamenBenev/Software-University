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
            int[] baverPos = new int[2];
            int[] lastPos = new int[2];
            Stack<char> woods = new Stack<char>();
            int itsWood = 0;

            for (int row = 0; row < size; row++)
            {
                string[] inp = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string outp = "";
                foreach (var item in inp)
                {
                    outp += item;
                }
                char[] input = outp.ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                    if (board[row, col] == 'B')
                    {
                        baverPos[0] = row;
                        baverPos[1] = col;
                        lastPos[0] = row;
                        lastPos[1] = col;
                    }
                    if (char.IsLower(board[row, col]))
                    {
                        itsWood++;
                    }
                }
            }

            string move = Console.ReadLine();

            while (move != "end")
            {
                int row = baverPos[0];
                int col = baverPos[1];
                board[row, col] = '-';

                if (move == "left")
                {
                    lastPos[0] = row;
                    lastPos[1] = col;
                    col--;
                }
                else if (move == "right")
                {
                    lastPos[0] = row;
                    lastPos[1] = col;
                    col++;
                }
                else if (move == "up")
                {
                    lastPos[0] = row;
                    lastPos[1] = col;
                    row--;
                }
                else if (move == "down")
                {
                    lastPos[0] = row;
                    lastPos[1] = col;
                    row++;
                }
                else
                {
                    continue;
                }

                if (!IsItInside(row, col, size))
                {
                    baverPos[0] = lastPos[0];
                    baverPos[1] = lastPos[1];
                    board[lastPos[0], lastPos[1]] = 'B';
                    if (woods.Count > 0)
                    {
                        woods.Pop();
                    }
                    move = Console.ReadLine();
                    continue;
                }

                if (board[row, col] == 'F')
                {
                    board[row, col] = '-';
                    if (col + 1 == lastPos[1])
                    {
                        // going left
                        if (col == 0)
                        {
                            col = size - 1;
                        }
                        else
                            col = 0;
                    }
                    else if (col - 1 == lastPos[1])
                    {
                        // going right
                        if (col == size - 1)
                        {
                            col = 0;
                        }
                        else
                            col = size - 1;
                    }
                    else if (row + 1 == lastPos[0])
                    {
                        // going up
                        if (row == 0)
                        {
                            row = size - 1;
                        }
                        else
                            row = 0;
                    }
                    else if (row - 1 == lastPos[0])
                    {
                        // going down
                        if (row == size - 1)
                        {
                            row = 0;
                        }
                        else
                            row = size - 1;
                    }
                }
                if (char.IsLower(board[row, col]))
                {
                    woods.Push(board[row, col]);
                    itsWood--;
                }

                board[row, col] = 'B';
                baverPos[0] = row;
                baverPos[1] = col;
                if (itsWood == 0)
                {
                    break;
                }
                move = Console.ReadLine();
            }
            var listwoods = woods.Reverse();
            if (itsWood == 0)
            {
                Console.WriteLine($"The Beaver successfully collect 2 wood branches: {string.Join(", ", listwoods)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {itsWood} branches left.");
            }

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write(board[r, c] + " ");
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