using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumption) : base(fuel, consumption)
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
            FuelQuantity += num * 0.95;
        }
    }
}
