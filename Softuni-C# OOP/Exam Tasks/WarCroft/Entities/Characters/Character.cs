using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string _name;
        private double _baseHealth;
        private double _health;
        private double _baseArmor;
        private double _armor;
        private double _abilityPoints;
        private Bag bag;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;

        }
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                _name = value;
            }
        }
        public double BaseHealth
        {
            get { return _baseHealth; }
            private set
            {
                _baseHealth = value;
                Health = value;
            }
        }
        public double Health
        {
            get { return _health; }
            set
            {
                if (value > BaseHealth)
                {
                    value = BaseHealth;
                }
                if (value < 0)
                {
                    _health = 0;
                }
                _health = value;
            }
        }
        public double BaseArmor
        {
            get { return _baseArmor; }
            private set
            {
                _baseArmor = value;
                Armor = value;
            }
        }
        public double Armor
        {
            get { return _armor; }
            private set
            {
                if (value > BaseArmor)
                {
                    value = BaseArmor;
                }
                if (value < 0)
                {
                    _armor = 0;
                }
                _armor = value;
            }
        }
        public bool IsAlive { get; set; } = true;
        public double AbilityPoints
        {
            get { return _abilityPoints; }
            private set { _abilityPoints = value; }
        }
        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            if (IsAlive == true)
            {
                double calc = Armor - hitPoints;
                if (Armor > 0)
                {
                    if (calc < 0)
                    {
                        Armor = 0;
                        Health += calc;
                    }
                    else
                        Armor -= hitPoints;
                }
                else
                {
                    Health -= hitPoints;
                }

                if (Health <= 0)
                {
                    Health = 0;
                    IsAlive = false;
                }
            }
        }
        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}