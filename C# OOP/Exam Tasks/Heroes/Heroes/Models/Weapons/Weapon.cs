using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
            }
        }
        public int Durability
        {
            get { return durability; }
            protected set
            {
                durability = value;
                if (value < 0)
                {

                    throw new ArgumentException("Durability cannot be below 0.");
                }
            }
        }
        public abstract int DoDamage();
        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
    }
}
