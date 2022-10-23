using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;


        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set { this.fuelQuantity = value; }
        }

        public double Consumption
        {
            get { return this.fuelConsumption; }
            protected set { this.fuelConsumption = value; }
        }

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.Consumption = fuelConsumption;
        }

        public abstract void Drive(double distance);
        public abstract void Refueling(double fuel);
    }
}
