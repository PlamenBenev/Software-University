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

            int em1 = int.Parse(Console.ReadLine());
            int em2 = int.Parse(Console.ReadLine());
            int em3 = int.Parse(Console.ReadLine());

            int sum = em1 + em2 + em3;

            int students = int.Parse(Console.ReadLine());
            int hour = 0;
            int i = 0;
            while (students > 0)
            {
                i++;
                if (i % 4 != 0)
                {
                    hour++;
                    students -= sum;

                }
                else
                    hour++;
            }
            Console.WriteLine($"Time needed: {hour}h.");
        }

    }
}