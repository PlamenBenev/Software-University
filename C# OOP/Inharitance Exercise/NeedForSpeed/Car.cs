using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int hp, double fuel)
            : base(hp, fuel)
        {

        }
        private double DefaultCarFuelConsumption = 3;
        public override double FuelConsumption => DefaultCarFuelConsumption;
    }
}
