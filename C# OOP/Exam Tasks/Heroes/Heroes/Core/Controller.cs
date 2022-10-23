using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core.Contracts
{
    public class Controller : IController
    {
        public Controller()
        {

        }
        private HeroRepository heroes = new HeroRepository();
        private WeaponRepository weapons = new WeaponRepository();
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            bool hname = false;
            bool wname = false;
            bool isWeaponEquipped = false;
            IWeapon weaponToEquip = null;

            foreach (var item in heroes.Models)
            {
                if (item.Name == heroName)
                {
                    hname = true;
                    if (item.Weapon != null)
                    {
                        isWeaponEquipped = true;
                    }
                }
            }
            foreach (var item in weapons.Models)
            {
                if (item.Name == weaponName)
                {
                    wname = true;
                    weaponToEquip = item;
                }
            }

            if (!hname)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (!wname)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (isWeaponEquipped)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            foreach (var item in heroes.Models)
            {
                if (item.Name == heroName)
                    item.AddWeapon(weaponToEquip);
            }
            weapons.Remove(weaponToEquip);
            return $"Hero {heroName} can participate in battle using a {weaponToEquip.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            foreach (var item in heroes.Models)
            {
                if (item.Name == name)
                {
                    throw new InvalidOperationException($"The hero {name} already exists.");
                }
            }
            if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            if (type == "Barbarian")
            {
                heroes.Add(new Barbarian(name, health, armour));
                return $"Successfully added Barbarian { name } to the collection.";
            }
            heroes.Add(new Knight(name, health, armour));
            return $"Successfully added Sir { name } to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            foreach (var item in weapons.Models)
            {
                if (item.Name == name)
                {
                    throw new InvalidOperationException($"The weapon { name } already exists.");
                }
            }
            if (type != "Claymore" && type != "Mace")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            if (type == "Claymore")
            {
                weapons.Add(new Claymore(name, durability));
            }
            else
            {
                weapons.Add(new Mace(name, durability));
            }
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            string returner = "";
            var orderedHeroes = heroes.Models.OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health).ThenBy(x => x.Name);
            foreach (var item in orderedHeroes)
            {
                returner += $"{item.GetType().Name}: {item.Name}{Environment.NewLine}";
                returner += $"--Health: {item.Health}{Environment.NewLine}";
                returner += $"--Armour: {item.Armour}{Environment.NewLine}";
                if (item.Weapon != null)
                {
                    returner += $"--Weapon: {item.Weapon.Name}{Environment.NewLine}";
                }
                else
                    returner += $"Unarmed{Environment.NewLine}";
            }
            return returner;
        }

        public string StartBattle()
        {
            Map map = new Map();

            return map.Fight((ICollection<IHero>)heroes.Models);
        }
    }
}
