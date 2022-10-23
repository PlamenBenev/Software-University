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
            int num = int.Parse(Console.ReadLine());

            string[][] jag = new string[num][];
            int collected = 0;
            int opponent = 0;

            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                jag[i] = new string[token.Length];
                for (int c = 0; c < token.Length; c++)
                {
                    jag[i][c] = token[c];
                }
            }
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Gong")
            {
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                if (input[0] == "Find")
                {
                    if (IsItValid(row, col, jag))
                    {
                        if (jag[row][col] == "T")
                        {
                            collected++;
                            jag[row][col] = "-";
                        }
                    }
                }
                else if (input[0] == "Opponent")
                {
                    if (IsItValid(row, col, jag))
                    {
                        int[] opponentPos = new int[2];
                        opponentPos[0] = row;
                        opponentPos[1] = col;

                        if (jag[row][col] == "T")
                        {
                            opponent++;
                            jag[row][col] = "-";
                        }

                        for (int steps = 0; steps < 3; steps++)
                        {
                            if (input[3] == "left")
                            {
                                if (IsItValid(row, col - 1, jag))
                                {
                                    col--;
                                }
                            }
                            else if (input[3] == "right")
                            {
                                if (IsItValid(row, col + 1, jag))
                                {
                                    col++;
                                }
                            }
                            else if (input[3] == "up")
                            {
                                if (IsItValid(row - 1, col, jag))
                                {
                                    row--;
                                }
                            }
                            else if (input[3] == "down")
                            {
                                if (IsItValid(row + 1, col, jag))
                                {
                                    row++;
                                }
                            }

                            opponentPos[0] = row;
                            opponentPos[1] = col;

                            if (jag[row][col] == "T")
                            {
                                opponent++;
                                jag[row][col] = "-";
                            }
                        }

                    }

                }
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            for (int r = 0; r < num; r++)
            {

                    Console.WriteLine(String.Join(' ', jag[r]));

            }
            Console.WriteLine($"Collected tokens: {collected}");
            Console.WriteLine($"Opponent's tokens: {opponent}");
        }
        public static bool IsItValid(int row, int col, string[][] array)
        {
            if (row >= 0 && row < array.Length &&
                col >= 0 && col < array[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}