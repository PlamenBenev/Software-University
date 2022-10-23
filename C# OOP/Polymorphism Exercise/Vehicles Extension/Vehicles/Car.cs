using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {

        public Car(double fuel, double consumption, double tankCapacity)
            : base(fuel, consumption, tankCapacity)
        {
            Consumption += 0.9;
        }
        public override void Drive(double distance)
        {
            if (distance * Consumption <= FuelQuantity)
            {
                Console.WriteLine($"Car travelled {distance} km");
                FuelQuantity -= distance * Consumption;
            }
            else
                Console.WriteLine("Car needs refueling");
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
                FuelQuantity += num;
            }
            else
                Console.WriteLine($"Cannot fit {num} fuel in the tank");
        }
    }
}
