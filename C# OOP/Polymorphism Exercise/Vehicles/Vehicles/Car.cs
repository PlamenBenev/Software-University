using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {

        public Car(double fuel, double consumption) : base(fuel, consumption)
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
            FuelQuantity += num;
        }
    }
}
