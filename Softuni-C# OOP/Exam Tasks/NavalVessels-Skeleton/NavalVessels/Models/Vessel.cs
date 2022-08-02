using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armor;
        private double weaponCaliber;
        private double speed;
        private ICollection<string> targets = new List<string>() ;

        public Vessel(string name, double mainWeaponCaliber,
            double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
             set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armor; }
             set
            {
                armor = value;
            }
        }

        public double MainWeaponCaliber
        {
            get { return weaponCaliber; }
            protected set { weaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        public ICollection<string> Targets
        {
            get { return targets; }
            private set
            {
                targets = value;
            }
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness <= 0)
            {
                target.ArmorThickness = 0;
            }
                targets.Add(target.Name);
        }

        public abstract void RepairVessel();
        public override string ToString()
        {
            string returner = $"- {Name}{Environment.NewLine}" +
                $" *Type: {this.GetType().Name}{Environment.NewLine}" +
                $" *Armor thickness: {this.ArmorThickness}{Environment.NewLine}" +
                $" *Main weapon caliber: {this.MainWeaponCaliber}{Environment.NewLine}" +
                $" *Speed: {this.Speed} knots{Environment.NewLine}";

            if (targets.Count > 0)
            {
                returner += $" *Targets: {string.Join(", ", targets)}";
            }
            else
                returner += $" *Targets: None";
            return returner;
        }
    }
}
