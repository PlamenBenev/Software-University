using Gym.Models.Athletes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{
    public abstract class Athlete : IAthlete
    {
        private string name;
        private string _motivation;
        private int _stamina;
        private int _numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }
        public string FullName
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }
                name = value;
            }
        }

        public string Motivation
        {
            get { return _motivation; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }
                _motivation = value;
            }
        }

        public int Stamina 
        { get { return _stamina; } protected set { _stamina = value; } }

        public int NumberOfMedals
        {
            get { return _numberOfMedals; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }
                _numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
