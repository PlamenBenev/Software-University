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

            Dictionary<string, List<double>> junk = new Dictionary<string, List<double>>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string inputName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!junk.ContainsKey(inputName))
                {
                    junk.Add(inputName, new List<double>() { grade });
                }
                else
                {
                    junk[inputName].Add(grade);
                }
            }
            foreach (var item in junk)
            {
                double pass = item.Value.Sum() / item.Value.Count;
                if (pass >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.Sum() / item.Value.Count:f2}");
                }
            }
        }
    }
}
