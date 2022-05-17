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
            int boardSize = int.Parse(Console.ReadLine());

            string[,] board = new string[boardSize,boardSize];
            int black = 0;
            int summer = 0;
            int white = 0;
            int eatenByBoar = 0;

            for (int row = 0; row < boardSize; row++)
            {
                string[] field = Console.ReadLine().Split(' ');
                for (int col = 0; col < boardSize; col++)
                {
                    board[row,col] = field[col];
                }
            }

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "Stop")
            {
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                if (input[0] == "Collect")
                {
                    if (board[row,col] == "B")
                    {
                        black++;
                    }
                    else if (board[row, col] == "S")
                    {
                        summer++;
                    }
                    else if (board[row, col] == "W")
                    {
                        white++;
                    }
                    board[row, col] = "-";
                }
                else if (input[0] == "Wild_Boar")
                {
                    if (input[3] == "right")
                    {
                        for (int c = col; c < boardSize; c += 2)
                        {
                            if (board[row,c] == "B" || board[row, c] == "W" || board[row, c] == "S")
                            {
                                eatenByBoar++;
                            }
                            board[row, c] = "-";
                        }
                    }
                    else if (input[3] == "left")
                    {
                        for (int c = col; c >= 0; c -= 2)
                        {
                            if (board[row, c] == "B" || board[row, c] == "W" || board[row, c] == "S")
                            {
                                eatenByBoar++;
                            }
                            board[row, c] = "-";
                        }
                    }
                    else if (input[3] == "up")
                    {
                        for (int r = row; r >= 0; r -= 2)
                        {
                            if (board[r, col] == "B" || board[r, col] == "W" || board[r, col] == "S")
                            {
                                eatenByBoar++;
                            }
                            board[r, col] = "-";
                        }
                    }
                    else if (input[3] == "down")
                    {
                        for (int r = row; r < boardSize; r += 2)
                        {
                            if (board[r, col] == "B" || board[r, col] == "W" || board[r, col] == "S")
                            {
                                eatenByBoar++;
                            }
                            board[r, col] = "-";
                        }
                    }
                }
                input = Console.ReadLine().Split(' ');
            }

            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenByBoar} truffles.");

            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    Console.Write(board[r,c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}