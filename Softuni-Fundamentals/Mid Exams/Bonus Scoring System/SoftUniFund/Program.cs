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
            int studNum = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());

            double[] attendants = new double[studNum];
            double max = 0;
            double totalBonus = 0;
            List<double> bons = new List<double>();

            for (int i = 0; i < studNum; i++)
            {
                double attend = double.Parse(Console.ReadLine());
                attendants[i] = attend;

                if (attend > max)
                {
                    max = attend;
                }

                totalBonus = attendants[i] / lectures * (5 + bonus);
                bons.Add(totalBonus);
            }

            bons.Sort();
            double maxb = Math.Ceiling(bons[bons.Count - 1]);
            Console.WriteLine($"Max Bonus: {maxb}.");
            Console.WriteLine($"The student has attended {max} lectures.");
        }

    }

}