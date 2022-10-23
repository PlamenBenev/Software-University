using System;
using System.Collections.Generic;

namespace BorderControl
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> all = new List<IId>();

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "End")
            {
                if (input.Length == 3)
                {
                    all.Add(new Citizens(input[0],int.Parse(input[1]), input[2]));
                }
                else if (input.Length == 2)
                {
                    all.Add(new Robots(input[0],input[1]));
                }
                input = Console.ReadLine().Split(' ');
            }
            input = Console.ReadLine().Split(' ');
            foreach (var item in all)
            {
                if (item.Id.EndsWith(input[0]))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
