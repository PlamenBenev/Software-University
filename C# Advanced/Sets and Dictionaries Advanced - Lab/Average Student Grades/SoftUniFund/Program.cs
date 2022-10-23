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

            Dictionary<string, List<Decimal>> students = new Dictionary<string, List<Decimal>>();

            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                Decimal grade = Decimal.Parse(token[1]);
                if (students.ContainsKey(token[0]))
                {
                    students[token[0]].Add(grade);
                }
                else
                {
                    students.Add(token[0], new List<Decimal>());
                    students[token[0]].Add(grade);
                }
            }
            foreach (var item in students)
            {
                Decimal avg = item.Value.Average();
                Console.Write($"{item.Key} -> ");
                foreach (var ns in item.Value)
                {
                    Console.Write($"{ns:f2} ");
                }
                Console.WriteLine($"(avg: {avg:f2})");
            }
        }
    }
}