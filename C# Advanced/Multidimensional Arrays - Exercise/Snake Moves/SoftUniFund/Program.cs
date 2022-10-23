using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            char[,] values = new char[num[0], num[1]];

            string word = Console.ReadLine();
            int wordLength = 0;

            for (int row = 0; row < values.GetLength(0); row += 2)
            {
                for (int col1 = 0; col1 < values.GetLength(1); col1++)
                {
                    if (wordLength >= word.Length)
                    {
                        wordLength = 0;
                    }

                    values[row, col1] = word[wordLength];
                    wordLength++;
                }
                if (row == values.GetLength(0) - 1)
                {
                    break;
                }
                for (int col2 = values.GetLength(1) - 1; col2 >= 0; col2--)
                {
                    if (wordLength >= word.Length)
                    {
                        wordLength = 0;
                    }

                    values[row + 1, col2] = word[wordLength];
                    wordLength++;
                }
            }
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int k = 0; k < values.GetLength(1); k++)
                {
                    Console.Write(values[i, k]);
                }
                Console.WriteLine();
            }
        }
    }
}