using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double _cost;
        private int _enduranceLevel;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }
        public double Cost
        {
            get { return _cost; }
            private set
            {
                _cost = value;
            }
        }

        public int EnduranceLevel
        {
            get { return _enduranceLevel; }
            private set
            {
                _enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if (EnduranceLevel > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
        }
    }
}
