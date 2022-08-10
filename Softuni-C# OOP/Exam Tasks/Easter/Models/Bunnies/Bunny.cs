using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string _name;
        private int _energy;
        private ICollection<IDye> dyes = new List<IDye>();

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;

        }
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public int Energy
        {
            get { return _energy; }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _energy = value;
            }
        }

        public ICollection<IDye> Dyes => dyes;

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
            if (this.Energy < 0)
                this.Energy = 0;
        }
    }
}
