using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string _username;
        private string _racingBehavior;
        private int _drivingXp;
        private ICar _car;
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }
        public string Username
        {
            get { return _username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                _username = value;
            }
        }

        public string RacingBehavior
        {
            get { return _racingBehavior; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }
                _racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get { return _drivingXp; }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                _drivingXp = value;
            }
        }

        public ICar Car
        {
            get { return _car; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                _car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable > this.Car.FuelConsumptionPerRace)
            {
                return true;
            }
            return false;
        }

        public virtual void Race()
        {
            this.Car.Drive();

        }
    }
}
