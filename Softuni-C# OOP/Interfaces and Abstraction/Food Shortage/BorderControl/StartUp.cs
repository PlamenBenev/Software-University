using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> all = new List<IId>();
            List<IBirthdays> birthdays = new List<IBirthdays>();
            List<IBuyer> buyers = new List<IBuyer>();

            int num = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < num; i++)
            {
                if (input.Length == 3)
                {
                    buyers.Add(new Rabel(input[0], int.Parse(input[1]), input[2]));
                }
                else if (input.Length == 4)
                {
                    buyers.Add(new Citizens(input[0], int.Parse(input[1]), input[2], input[3]));
                }
                input = Console.ReadLine().Split(' ');
            }

            while (input[0] != "End")
            {
                foreach (var item in buyers)
                {
                    if (item.Name == input[0])
                    {
                        item.BuyFood();
                    }
                }

                input = Console.ReadLine().Split(' ');
            }
            int food = buyers.Sum(x => x.Food);
            Console.WriteLine(food);
        }
    }
}
