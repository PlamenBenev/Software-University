using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double _price;
        private int _destructionLevel;
        public Weapon(int destructionLevel, double price)
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }
        public double Price
        { get { return _price; } private set { _price = value; } }

        public int DestructionLevel
        {
            get { return _destructionLevel; } 
            private set
            { 
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }
                _destructionLevel = value;
            }
        }
    }
}
