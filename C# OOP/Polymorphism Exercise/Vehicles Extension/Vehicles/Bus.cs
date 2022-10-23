using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double tankQuantity,double consumption, double tankCapacity)
            : base(tankQuantity, consumption, tankCapacity)
        {
              
        }
        public override void Drive(double distance)
        {
            if (distance * (Consumption + 1.4) <= FuelQuantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= distance * (Consumption + 1.4);
            }
            else
                Console.WriteLine("Bus needs refueling");
        }
        //public double DriveEmpty
        //{
        //    get { return empty; }
        //    set
        //    {
        //        empty = value;
        //        if (value * Consumption <= FuelQuantity)
        //        {
        //            FuelQuantity -= value * Consumption;
        //            Console.WriteLine($"Bus travelled {value} km");
        //        }
        //        else
        //            Console.WriteLine("Bus needs refueling");
        //    }
        //}
        public void DriveEmpty(double distance)
        {
            if (distance * Consumption <= FuelQuantity)
            {
                FuelQuantity -= distance * Consumption ;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
                Console.WriteLine("Bus needs refueling");
        }
        public override void Refueling(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
                return;
            }
            if (fuel <= TankCapacity)
            {
                FuelQuantity += fuel;
            }
            else
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
    }
}
