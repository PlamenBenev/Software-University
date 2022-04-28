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

            Queue<int> tank = new Queue<int>();
            int minIndex = 0;
            int gasClaimed = 0;
            bool itsSetted = false;
            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                int amount = int.Parse(token[0]);
                int distance = int.Parse(token[1]);

                tank.Enqueue(amount + gasClaimed - distance);

                if (tank.Last() >= 0)
                {
                    if (!itsSetted)
                    {
                        minIndex = i;
                        itsSetted = true;
                    }
                    gasClaimed += amount - distance;
                }
                else
                {
                    if (itsSetted && tank.Last() < 0)
                    {
                        itsSetted = false;
                    }
                    gasClaimed = 0;
                }
            }
            Console.WriteLine(minIndex);
        }
    }
}