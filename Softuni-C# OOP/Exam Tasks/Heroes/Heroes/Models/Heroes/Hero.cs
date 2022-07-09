using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero
    {
        string name;
        int hp;
        int armor;
        bool isItAlive = false;
        IWeapon weapon;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
            }
        }
        public int Health
        {
            get { return hp; }
            set
            {
                hp = value;
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
            }
        }
        public int Armour
        {
            get { return armor; }
            set
            {
                armor = value;
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
            }
        }
        public bool IsItAlive
        {
            get { return isItAlive; }
            set
            {
                isItAlive = value;
                if (this.Health > 0)
                {
                    isItAlive = true;
                }
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            set
            {
                weapon = value;
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
            }
        }
        public void AddWeapon(IWeapon weapon)
        {
            if (this.Weapon == null)
                this.Weapon = weapon;
        }
        public void TakeDamage(int points)
        {
            int transfering = 0;
            if (this.Armour > 0)
            {
                if (this.Armour - points <= 0)
                {
                    transfering = points - this.Armour;
                    this.Health -= transfering;
                    if (this.Health < 0)
                    {
                        this.IsItAlive = false;
                    }
                }
                else
                    this.Armour -= points;
            }
            else
            {
                this.Health -= points;
                if (this.Health < 0)
                {
                    this.IsItAlive = false;
                }
            }
        }
        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
    }
}
