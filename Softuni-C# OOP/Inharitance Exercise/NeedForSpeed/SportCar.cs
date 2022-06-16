using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int hp, double fuel)
            : base(hp, fuel)
        {
        }
        private double DefaultFuelConsumption = 10;

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
