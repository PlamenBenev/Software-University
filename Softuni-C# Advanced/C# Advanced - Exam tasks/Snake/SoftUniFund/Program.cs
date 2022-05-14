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
            int foodEeaten = 0;

            string[,] board = new string[boardSize, boardSize];
            int[] snakePosition = new int[2];
            List<int> burrowPosition = new List<int>();

            for (int row = 0; row < boardSize; row++)
            {
                char[] token = Console.ReadLine().ToArray();

                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = token[col].ToString();
                    if (board[row, col] == "S")
                    {
                        snakePosition[0] = row;
                        snakePosition[1] = col;
                    }
                    if (board[row, col] == "B")
                    {
                        burrowPosition.Add(row);
                        burrowPosition.Add(col);
                    }
                }
            }

            while (foodEeaten < 10)
            {
                string input = Console.ReadLine();
                if (input == "up" && IsItInside(snakePosition[0] - 1, snakePosition[1], boardSize))
                {
                    if (board[snakePosition[0] - 1, snakePosition[1]] == "*")
                    {
                        foodEeaten++;
                    }
                    board[snakePosition[0], snakePosition[1]] = ".";
                    board[snakePosition[0] - 1, snakePosition[1]] = "S";
                    snakePosition[0] = snakePosition[0] - 1;

                }
                else if (input == "down" && IsItInside(snakePosition[0] + 1, snakePosition[1], boardSize))
                {
                    if (board[snakePosition[0] + 1, snakePosition[1]] == "*")
                    {
                        foodEeaten++;
                    }
                    board[snakePosition[0], snakePosition[1]] = ".";
                    board[snakePosition[0] + 1, snakePosition[1]] = "S";
                    snakePosition[0] = snakePosition[0] + 1;
                }
                else if (input == "left" && IsItInside(snakePosition[0], snakePosition[1] - 1, boardSize))
                {
                    if (board[snakePosition[0], snakePosition[1] - 1] == "*")
                    {
                        foodEeaten++;
                    }
                    board[snakePosition[0], snakePosition[1]] = ".";
                    board[snakePosition[0], snakePosition[1] - 1] = "S";
                    snakePosition[1] = snakePosition[1] - 1;
                }
                else if (input == "right" && IsItInside(snakePosition[0], snakePosition[1] + 1, boardSize))
                {
                    if (board[snakePosition[0], snakePosition[1] + 1] == "*")
                    {
                        foodEeaten++;
                    }
                    board[snakePosition[0], snakePosition[1]] = ".";
                    board[snakePosition[0], snakePosition[1] + 1] = "S";
                    snakePosition[1] = snakePosition[1] + 1;
                }
                else
                {
                    board[snakePosition[0], snakePosition[1]] = ".";
                    break;
                }
                if (burrowPosition.Count > 0)
                {
                    if (snakePosition[0] == burrowPosition[0] && snakePosition[1] == burrowPosition[1])
                    {
                        board[snakePosition[0], snakePosition[1]] = ".";
                        snakePosition[0] = burrowPosition[2];
                        snakePosition[1] = burrowPosition[3];
                        board[snakePosition[0], snakePosition[1]] = "S";
                    }
                    else if (snakePosition[0] == burrowPosition[2] && snakePosition[1] == burrowPosition[3])
                    {
                        board[snakePosition[0], snakePosition[1]] = ".";
                        snakePosition[0] = burrowPosition[0];
                        snakePosition[1] = burrowPosition[1];
                        board[snakePosition[0], snakePosition[1]] = "S";
                    }
                }
            }
            if (foodEeaten >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodEeaten}");
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Console.Write(board[row,col]);
                }
                Console.WriteLine();
            }
        }
        static bool IsItInside(int row, int col, int size)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Game over!");
                return false;
            }
        }
    }

}