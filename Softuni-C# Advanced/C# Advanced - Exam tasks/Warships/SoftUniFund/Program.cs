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
            int field = int.Parse(Console.ReadLine());

            string[] moves = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            string[,] board = new string[field, field];
            int firstPlayer = 0;
            int SecondPlayer = 0;
            int totalCountShipsDestroyed = 0;

            for (int row = 0; row < field; row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < field; col++)
                {
                    board[row, col] = input[col];
                    if (input[col] == ">")
                    {
                        SecondPlayer++;
                    }
                    else if (input[col] == "<")
                    {
                        firstPlayer++;
                    }
                }
            }

            foreach (var item in moves)
            {
                string[] target = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(target[0]);
                int col = int.Parse(target[1]);

                if (IsItValid(row, col, field))
                {
                    if (board[row, col] == "#")
                    {
                        if (IsItValid(row - 1, col, field) && board[row - 1, col] != "*")  //left
                        {
                            if (board[row - 1, col] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row - 1, col] = "X";
                        }
                        if (IsItValid(row - 1, col - 1, field) && board[row - 1, col - 1] != "*")  //above left
                        {
                            if (board[row - 1, col - 1] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row - 1, col - 1] = "X";
                        }
                        if (IsItValid(row, col - 1, field) && board[row, col - 1] != "*")  //above
                        {
                            if (board[row, col - 1] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row, col - 1] = "X";
                        }
                        if (IsItValid(row + 1, col - 1, field) && board[row + 1, col - 1] != "*")  //above right
                        {
                            if (board[row + 1, col - 1] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row + 1, col - 1] = "X";
                        }
                        if (IsItValid(row + 1, col, field) && board[row + 1, col] != "*")  //right
                        {
                            if (board[row + 1, col] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row + 1, col] = "X";
                        }
                        if (IsItValid(row + 1, col + 1, field) && board[row + 1, col + 1] != "*")  // lower right
                        {
                            if (board[row + 1, col + 1] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row + 1, col + 1] = "X";
                        }
                        if (IsItValid(row, col + 1, field) && board[row, col + 1] != "*")  // lower 
                        {
                            if (board[row, col + 1] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row, col + 1] = "X";
                        }
                        if (IsItValid(row - 1, col + 1, field) && board[row - 1, col + 1] != "*")  // lower left
                        {
                            if (board[row - 1, col + 1] == ">")
                            {
                                SecondPlayer--;
                            }
                            else
                                firstPlayer--;

                            totalCountShipsDestroyed++;
                            board[row - 1, col + 1] = "X";
                        }
                    }
                    else if (board[row, col] == ">")
                    {
                        totalCountShipsDestroyed++;
                        SecondPlayer--;
                        board[row, col] = "X";
                    }
                    else if (board[row, col] == "<")
                    {
                        totalCountShipsDestroyed++;
                        firstPlayer--;
                        board[row, col] = "X";
                    }
                }
                if (firstPlayer == 0 || SecondPlayer == 0)
                {
                    break;
                }
            }
            if (SecondPlayer == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (firstPlayer == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else
                Console.WriteLine($"It's a draw! Player One has {firstPlayer} ships left. Player Two has {SecondPlayer} ships left.");
        }
        public static bool IsItValid(int row, int col, int field)
        {
            if (row >= 0 && row < field && col >= 0 && col < field)
            {
                return true;
            }
            else
                return false;
        }
    }
}