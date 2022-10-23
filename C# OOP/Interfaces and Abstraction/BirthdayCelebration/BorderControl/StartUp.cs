using System;
using System.Collections.Generic;

namespace BirthdayCelebration
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> all = new List<IId>();
            List<IBirthdays> birthdays = new List<IBirthdays>();

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    all.Add(new Citizens(input[1],int.Parse(input[2]), input[3],input[4]));
                    birthdays.Add(new Citizens(input[1], int.Parse(input[2]), input[3], input[4]));
                }
                else if (input[0] == "Robot")
                {
                    all.Add(new Robots(input[1],input[2]));
                }
                else if (input[0] == "Pet")
                {
                    birthdays.Add(new Pet(input[1], input[2]));
                }
                input = Console.ReadLine().Split(' ');
            }
            input = Console.ReadLine().Split(' ');
            foreach (var item in birthdays)
            {
                if (item.Birthdays.EndsWith(input[0]))
                {
                    Console.WriteLine(item.Birthdays);
                }
            }
        }
    }
}
