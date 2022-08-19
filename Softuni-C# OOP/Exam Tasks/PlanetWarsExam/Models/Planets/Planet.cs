using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string _name;
        private double _budget;
        private double _militaryPower;
        private UnitRepository unitRepo = new UnitRepository();
        private WeaponRepository weaponRepo = new WeaponRepository();
        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
          //  MilitaryPower = Calc();
        }
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public double Budget
        {
            get { return _budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                _budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return Calc(); }
            private set
            {
                _militaryPower = value;
            }
        }
        public double Calc()
        {
            double total = unitRepo.Models.Sum(x => x.EnduranceLevel) +
                 weaponRepo.Models.Sum(x => x.DestructionLevel);

            foreach (var item in unitRepo.Models)
            {
                if (item.GetType().Name == "AnonymousImpactUnit")
                {
                    total += total * 0.3;
                }
            }
            foreach (var item in weaponRepo.Models)
            {
                if (item.GetType().Name == "NuclearWeapon")
                {
                    total += total * 0.45;
                }
            }

            return Math.Round(total, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army =>
            unitRepo.Models;

        public IReadOnlyCollection<IWeapon> Weapons =>
            weaponRepo.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            unitRepo.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weaponRepo.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            string militaryNames = "No units";
            string weaponsNames = "No weapons";
            if (unitRepo.Models.Count > 0)
            {
                List<string> militaryUnits = new List<string>();
                foreach (var item in unitRepo.Models)
                {
                    militaryUnits.Add(item.GetType().Name);
                }
                militaryNames = string.Join(", ", militaryUnits);
            }
            if (weaponRepo.Models.Count > 0)
            {
                List<string> weaponsList = new List<string>();
                foreach (var item in weaponRepo.Models)
                {
                    weaponsList.Add(item.GetType().Name);
                }
                weaponsNames = string.Join(", ", weaponsList);
            }

            return $"Planet: {this.Name}{Environment.NewLine}" +
                $"--Budget: {this.Budget} billion QUID{Environment.NewLine}" +
                $"--Forces: {militaryNames}{Environment.NewLine}" +
                $"--Combat equipment: {weaponsNames}{Environment.NewLine}" +
                $"--Military Power: {MilitaryPower}";
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException("Budget too low!");
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in unitRepo.Models)
            {
                item.IncreaseEndurance();
            }
        }
    }
}
