using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string _name;
        private double _oxygen;
        private bool _canBreath;
        private IBag _bag;
        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public double Oxygen
        {
            get { return _oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                _oxygen = value;
            }
        }

        public bool CanBreath
        { get { return _canBreath; } private set { _canBreath = value; } }

        public IBag Bag
        { get { return _bag; } private set { _bag = value; } }

        public virtual void Breath()
        {
            if (Oxygen - 10 >= 0)
                Oxygen -= 10;
        }
    }
}
