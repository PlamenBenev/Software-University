using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string _name;
        private ICollection<string> _items = new List<string>();
        public Planet(string name)
        {
            Name = name;
        }
        public ICollection<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                _name = value;
            }
        }
    }
}
