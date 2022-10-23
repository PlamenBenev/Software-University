using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get => DefaultFuelConsumption; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
        public Vehicle(int hp, double fuel)
        {
            Fuel = fuel;
            HorsePower = hp;
        }
    }
}
