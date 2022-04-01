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

            List<double> kvartala = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();

            int count = kvartala.Count;
            double sum = kvartala.Sum();
            double aprox = sum / count;

            List<double> arr = kvartala.FindAll(x => x > aprox);
            arr.Sort();
            arr.Reverse();
            if (arr.Count > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            else if (arr.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
                Console.WriteLine(String.Join(' ', arr));
        }

    }
}