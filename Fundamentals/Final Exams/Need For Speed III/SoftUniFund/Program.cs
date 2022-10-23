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
            List<CarStat> cars = new List<CarStat>();

            for (int i = 0; i < num; i++)
            {
                input = Console.ReadLine();
                string[] token = input.Split('|');
                CarStat car = new CarStat(token[0], int.Parse(token[1]), int.Parse(token[2]));
                cars.Add(car);
            }
            input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] token = input.Split(" : ");
                if (token[0] == "Drive")
                {
                    foreach (var item in cars)
                    {
                        if (item.Model == token[1])
                        {
                            if (item.Fuel >= int.Parse(token[3]))
                            {
                                item.Fuel -= int.Parse(token[3]);
                                item.Mil += int.Parse(token[2]);
                                Console.WriteLine($"{token[1]} driven for {int.Parse(token[2])} kilometers. {int.Parse(token[3])} liters of fuel consumed.");
                            }
                            else
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                            }
                            if (item.Mil >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {token[1]}!");
                                cars.Remove(item);
                                break;
                            }
                        }
                    }
                }
                else if (token[0] == "Refuel")
                {
                    foreach (var item in cars)
                    {
                        if (token[1] == item.Model)
                        {
                            int calc = 0;
                            if (item.Fuel + int.Parse(token[2]) > 75)
                            {
                                calc = 75 - item.Fuel;
                                item.Fuel = 75;
                            }
                            else
                            {
                                calc = int.Parse(token[2]);
                                item.Fuel += int.Parse(token[2]);
                            }
                            Console.WriteLine($"{item.Model} refueled with {calc} liters");
                        }
                    }
                }
                else if (token[0] == "Revert")
                {
                    foreach (var item in cars)
                    {
                        if (token[1] == item.Model)
                        {
                            item.Mil -= int.Parse(token[2]);
                            if (item.Mil < 10000)
                            {
                                item.Mil = 10000;
                            }
                            else
                                Console.WriteLine($"{item.Model} mileage decreased by {int.Parse(token[2])} kilometers");
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} -> Mileage: {item.Mil} kms, Fuel in the tank: {item.Fuel} lt.");
            }
        }
    }
}
class CarStat
{
    public CarStat(string model, int mil, int fuel)
    {
        Model = model;
        Mil = mil;
        Fuel = fuel;
    }
    public string Model { get; set; }
    public int Mil { get; set; }
    public int Fuel { get; set; }
}


