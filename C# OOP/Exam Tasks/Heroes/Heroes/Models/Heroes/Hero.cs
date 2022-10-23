using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int hp;
        private int armor;
        private bool isItAlive = true;
        private IWeapon weapon;
        public string Name
        {
            get { return name; }
            private set
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
            private set
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
            private set
            {
                armor = value;
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }
        }

        public bool IsAlive
        {
            get { return isItAlive; }
            private set
            {
                isItAlive = value;
                if (Health <= 0)
                {
                    isItAlive = false;
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
                    this.hp -= transfering;
                    this.Armour = 0;
                    if (this.hp < 0)
                    {
                        Health = 0;
                        this.isItAlive = false;
                    }
                }
                else
                    this.Armour -= points;
            }
            else
            {
                this.hp -= points;
                if (this.hp < 0)
                {
                    Health = 0;
                    this.isItAlive = false;
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
