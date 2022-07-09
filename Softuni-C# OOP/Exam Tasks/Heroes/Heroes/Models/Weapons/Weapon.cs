using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon
    {
        string name;
        int durability;
        public string Name
        {
            get { return name; }
            set
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
            set
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
