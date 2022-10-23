using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string _make;
        private string _model;
        private string _vin;
        private int hp;
        private double _fuelAvalible;
        private double _fuelConsumtpionPerRace;
        public Car(string make, string model, string Vin, 
            int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = Vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public string Make
        {
            get { return _make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))

                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }
                _make = value;
            }
        }

        public string Model
        {
            get { return _model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                _model = value;
            }
        }

        public string VIN
        {
            get { return _vin; }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                _vin = value;
            }
        }

        public int HorsePower
        {
            get { return hp; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                hp = value;
            }
        }

        public double FuelAvailable
        {
            get { return _fuelAvalible; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _fuelAvalible = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get { return _fuelConsumtpionPerRace; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                _fuelConsumtpionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}
