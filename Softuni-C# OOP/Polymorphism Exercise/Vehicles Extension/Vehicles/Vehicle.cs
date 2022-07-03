using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public double TankCapacity
        {
            get { return tankCapacity; }
            private set{ tankCapacity = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            { 
                if (value > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                this.fuelQuantity = value;
            }
        }

        public double Consumption
        {
            get { return this.fuelConsumption; }
             set { this.fuelConsumption = value; }
        }

        public Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.Consumption = fuelConsumption;
        }

        public abstract void Drive(double distance);
        public abstract void Refueling(double fuel);
    }
}
