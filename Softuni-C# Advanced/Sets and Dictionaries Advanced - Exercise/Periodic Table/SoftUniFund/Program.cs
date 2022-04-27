using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> chemicals = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split(' ');

                foreach (var item in token)
                {
                    chemicals.Add(item);
                }
            }
            chemicals = chemicals.OrderBy(x => x).ToHashSet();

            foreach (var item in chemicals)
            {
                Console.Write(item + " ");
            }
        }
    }
}