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
            int num = int.Parse(Console.ReadLine());

            int[,] values = new int[num, num];

            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                for (int k = 0; k < token.Length; k++)
                {
                    values[i, k] = int.Parse(token[k]);
                }
            }
            int sum1 = 0;
            int sum2 = 0;
            for (int col = 0; col < num; col++)
            {
                for (int row = col; row < num; row++)
                {
                    sum1 += values[col,row];
                    break;
                }
                for (int backwords = num - col - 1; backwords >= 0; backwords--)
                {
                    sum2 += values[col, backwords];
                    break;
                }
            }
            Console.WriteLine(Math.Abs(sum1 - sum2));
        }
    }
}