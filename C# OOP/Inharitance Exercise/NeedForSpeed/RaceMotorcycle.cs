using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int hp, double fuel)
            : base(hp, fuel)
        {
        }
        private double DefaultMotorFuelConsumption = 8;
        public override double FuelConsumption => DefaultMotorFuelConsumption;
    }
}
