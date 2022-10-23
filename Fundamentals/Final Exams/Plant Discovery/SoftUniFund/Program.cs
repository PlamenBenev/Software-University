using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string input = "";
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < num; i++)
            {
                input = Console.ReadLine();
                string[] token = input.Split("<->");
                Plant plant = new Plant(token[0], int.Parse(token[1]), 0);
                bool haveit = false;
                foreach (var item in plants)
                {
                    if (item.Name == token[0])
                    {
                        item.Rarety = int.Parse(token[1]);
                        haveit = true;
                    }
                }
                if (!haveit)
                {
                    plants.Add(plant);
                }
            }

            input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] token = input.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                bool valid = false;
                if (token[0] == "Rate")
                {
                    foreach (var item in plants)
                    {
                        if (item.Name == token[1])
                        {
                            item.Rating += double.Parse(token[2]);
                            item.Counter++;
                            valid = true;
                        }
                    }
                }
                else if (token[0] == "Update")
                {
                    foreach (var item in plants)
                    {
                        if (item.Name == token[1])
                        {
                            item.Rarety = int.Parse(token[2]);
                            valid = true;
                        }
                    }
                }
                else if (token[0] == "Reset")
                {
                    foreach (var item in plants)
                    {
                        if (item.Name == token[1])
                        {
                            item.Rating = 0;
                            item.Counter = 0;
                            valid = true;
                        }
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("error");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants)
            {
                double avRating = 0;
                if (item.Rating > 0 && item.Counter > 0)
                {
                    avRating = item.Rating / item.Counter;
                }
                else
                {
                    avRating = item.Rating;
                }
                Console.WriteLine($"- {item.Name}; Rarity: {item.Rarety}; Rating: {avRating:f2}");
            }
        }
    }
}

class Plant
{
    public Plant(string name, int rarety, double rating)
    {
        Name = name;
        Rarety = rarety;
        Rating = rating;
        Counter = 0;
    }
    public string Name { get; set; }
    public int Rarety { get; set; }
    public double Rating { get; set; }
    public int Counter { get; set; }
}