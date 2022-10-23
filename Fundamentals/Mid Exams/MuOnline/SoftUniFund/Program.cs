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
            List<string> rooms = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int health = 100;
            int bitcoins = 0;
            int counter = 0;

            for (int i = 0; i < rooms.Count; i++)
            {
                List<string> token = rooms[i].Split(' ').ToList();

                if (token[0] == "potion")
                {
                    if (health + int.Parse(token[1]) >= 100)
                    {
                        int healed = 100 - health;
                        health = 100;
                        Console.WriteLine($"You healed for {healed} hp.");
                    }
                    else
                    {
                        health += int.Parse(token[1]);
                        Console.WriteLine($"You healed for {token[1]} hp.");
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                    counter++;
                }
                else if (token[0] == "chest")
                {
                    bitcoins += int.Parse(token[1]);
                    Console.WriteLine($"You found {token[1]} bitcoins.");
                    counter++;
                }
                else
                {
                    health -= int.Parse(token[1]);
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {token[0]}.");
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {token[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                }
            }
            if (counter == rooms.Count)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}