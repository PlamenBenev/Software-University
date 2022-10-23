using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumption, double tankCapacity)
            : base(fuel, consumption, tankCapacity)
        {
            Consumption += 1.6;
        }
        public override void Drive(double distance)
        {
            if (distance * Consumption <= FuelQuantity)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= distance * Consumption;
            }
            else
                Console.WriteLine("Truck needs refueling");
        }
        public override void Refueling(double num)
        {
            if (num <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
                return;
            }
            if (num <= TankCapacity)
            {
                FuelQuantity += num * 0.95;
            }
            else
                Console.WriteLine($"Cannot fit {num} fuel in the tank");
        }
    }
}
