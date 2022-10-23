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

            int[][] arr = new int[num][];
            for (int r = 0; r < num; r++)
            {
                int[] col = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                arr[r] = col;
            }
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] token =input.Split(' ');
                int row = int.Parse(token[1]);
                int col = int.Parse(token[2]);
                int number = int.Parse(token[3]);

                if (row < num && row >= 0 && col < num && col >= 0)
                {
                    if (token[0] == "Add")
                    {
                        arr[row][col] += number;
                    }
                    else if (token[0] == "Subtract")
                    {
                        arr[row][col] -= number;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(String.Join(' ', arr[i]));
            }
        }
    }
}