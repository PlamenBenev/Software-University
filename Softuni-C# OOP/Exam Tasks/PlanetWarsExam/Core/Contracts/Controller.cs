using PlanetWars.Models.Planets;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Weapons;

namespace PlanetWars.Core.Contracts
{
    public class Controller : IController
    {
        private PlanetRepository planetRepo = new PlanetRepository();
        public Controller()
        {

        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = null;
            MilitaryUnit unit = null;
            foreach (var item in planetRepo.Models)
            {
                if (item.Name == planetName)
                {
                    planet = item;
                }
            }
            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            foreach (var item in planet.Army)
            {
                if (item.GetType().Name == unitTypeName)
                {
                    throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
                }
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = null;
            Weapon weapon = null;
            foreach (var item in planetRepo.Models)
            {
                if (item.Name == planetName)
                {
                    planet = item;
                }
            }
            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            foreach (var item in planet.Weapons)
            {
                if (item.GetType().Name == weaponTypeName)
                {
                    throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
                }
            }
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            foreach (var item in planetRepo.Models)
            {
                if (item.Name == name)
                {
                    return $"Planet {name} is already added!";
                }
            }

            planetRepo.AddItem(new Planet(name, budget));
            return $"Successfully added Planet: {name}";
        }

        public string ForcesReport()
        {
            string returner = $"***UNIVERSE PLANET MILITARY REPORT***{Environment.NewLine}";
            List<IPlanet> ordered = planetRepo.Models.OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name).ToList();
            foreach (var item in ordered)
            {
                returner += item.PlanetInfo() + Environment.NewLine;
            }
            return returner;
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            Planet planet1 = null;
            Planet planet2 = null;
            Planet winner = null;
            Planet looser = null;
            foreach (var item in planetRepo.Models)
            {
                if (item.Name == planetOne)
                {
                    planet1 = (Planet)item;
                }
            }
            foreach (var item in planetRepo.Models)
            {
                if (item.Name == planetTwo)
                {
                    planet2 = (Planet)item;
                }
            }
            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                looser = planet2;
            }
            else if (planet1.MilitaryPower < planet2.MilitaryPower)
            {
                winner = planet2;
                looser = planet1;
            }
            else if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                bool one = false;
                bool two = false;
                foreach (var item in planet1.Weapons)
                {
                    if (item.GetType().Name == "NuclearWeapon")
                    {
                        one = true;
                    }
                }
                foreach (var item in planet2.Weapons)
                {
                    if (item.GetType().Name == "NuclearWeapon")
                    {
                        two = true;
                    }
                }
                if (one && !two)
                {
                    winner = planet1;
                    looser = planet2;
                }
                else if (!one && two)
                {
                    winner = planet2;
                    looser = planet1;
                }
                else if ((one && two) || (!one && !two))
                {
                    winner = null;
                }
            }
            if (winner == null)
            {
                planet1.Spend(planet1.Budget/2);
                planet2.Spend(planet2.Budget / 2);
                return "The only winners from the war are the ones who supply the bullets and the bandages!";
            }
            winner.Spend(winner.Budget/2);
            winner.Profit(looser.Budget/2);
            foreach (var item in looser.Army)
            {
                winner.Profit(item.Cost);
            }
            foreach (var item in looser.Weapons)
            {
                winner.Profit(item.Price);
            }
            string looserName = looser.Name;
            planetRepo.RemoveItem(looser.Name);
            return $"{winner.Name} destructed {looserName}!";
        }

        public string SpecializeForces(string planetName)
        {
            Planet planet = null;
            foreach (var item in planetRepo.Models)
            {
                if (item.Name == planetName)
                {
                    planet = (Planet)item;
                }
            }
            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            planet.Spend(1.25);
            foreach (var item in planet.Army)
            {
                item.IncreaseEndurance();
            }
            return $"{planetName} has upgraded its forces!";
        }
    }
}
