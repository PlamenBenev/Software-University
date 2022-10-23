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

            double[][] arrs = new double[num][];            

            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                arrs[i] = new double[token.Length];
                
                for (int j = 0; j < token.Length; j++)
                {
                    arrs[i][j] = int.Parse(token[j]);
                }
            }

            for (int i = 0; i < arrs.Length - 1; i++)
            {
                if (arrs[i].Length == arrs[i + 1].Length)
                {
                    for (int k = 0; k < arrs[i].Length; k++)
                    {
                        arrs[i][k] *= 2;
                        arrs[i + 1][k] *= 2;
                    }
                }
                else
                {
                    for (int k = 0; k < arrs[i].Length; k++)
                    {
                        arrs[i][k] /= 2;
                    }
                    for (int k = 0; k < arrs[i + 1].Length; k++)
                    {
                        arrs[i + 1][k] /= 2;
                    }
                }
            }
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] token = input.Split(' ');
                int row = int.Parse(token[1]);
                int col = int.Parse(token[2]);
                int value = int.Parse(token[3]);
                bool flag = false;
                for (int i = 0; i < arrs.Length; i++)
                {
                    if (row >= arrs.Length || row < 0 || col >= arrs[i].Length || col < 0)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    if (token[0] == "Add")
                    {
                        arrs[row][col] += value;
                    }
                    else if (token[0] == "Subtract")
                    {
                        arrs[row][col] -= value;
                    }
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < arrs.Length; i++)
            {
                foreach (var item in arrs[i])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}