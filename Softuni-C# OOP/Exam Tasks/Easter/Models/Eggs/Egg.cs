using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string _name;
        private int _energyReq;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public int EnergyRequired
        {
            get { return _energyReq; }
            private set
            {
                if (value <0)
                {
                    value = 0;
                }
                _energyReq = value;
            }
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;
            if (this.EnergyRequired < 0)
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
                return true;
            return false;
        }
    }
}
