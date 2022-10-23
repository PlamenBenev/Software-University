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

            int rows = num;
            int cols = num;

            char[,] cells = new char[rows, cols];
            // fill the cells
            for (int r = 0; r < rows; r++)
            {
                string input = Console.ReadLine();

                for (int k = 0; k < cols; k++)
                {
                    cells[r, k] = input[k];
                }

            }
            string input2 = Console.ReadLine();
            bool isItThere = false;
            for (int r = 0; r < num; r++)
            {
                for (int c = 0; c < num; c++)
                {
                    string itemToString = cells[r, c].ToString();
                    if (input2 == itemToString)
                    {
                        Console.WriteLine($"({r}, {c})");
                        isItThere = true;
                        break;
                    }
                }
                if (isItThere)
                {
                    break;
                }
            }
            if (!isItThere)
            {
                Console.WriteLine(input2 + " does not occur in the matrix");
            }
        }
    }
}