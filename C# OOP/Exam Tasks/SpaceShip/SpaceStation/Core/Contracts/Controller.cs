using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core.Contracts
{
    public class Controller : IController
    {
        private AstronautRepository astroRepo = new AstronautRepository();
        private PlanetRepository planetRepo = new PlanetRepository();
        public Controller()
        {

        }
        public string AddAstronaut(string type, string astronautName)
        {
            Astronaut astro = null;
            if (type == "Biologist")
            {
                astro = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astro = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astro = new Meteorologist(astronautName);
            }
            if (astro == null)
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astroRepo.Add(astro);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName)
            {
                Items = items
            };
            planetRepo.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            Mission mission = new Mission();
            IPlanet planet = null;
            foreach (var item in planetRepo.Models)
            {
                if (item.Name == planetName)
                {
                    planet = item;
                }
            }
            ICollection<IAstronaut> astronauts = new List<IAstronaut>();
            foreach (var item in astroRepo.Models)
            {
                if (item.Oxygen > 60)
                {
                    astronauts.Add(item);
                }
            }

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            int beforeMission = astronauts.Count;
            mission.Explore(planet, astronauts);
            int afterMission = 0;
            foreach (var item in astronauts)
            {
                if (item.Oxygen > 0)
                    afterMission++;
            }
            return $"Planet: {planetName} was explored! Exploration finished with {beforeMission - afterMission} dead astronauts!";
        }

        public string Report()
        {
            int explored = 0;
            foreach (var item in planetRepo.Models)
            {
                if (item.Items.Count == astroRepo.Models.Sum(x => x.Bag.Items.Count))
                {
                    explored++;
                }
            }
            string returner = $"{explored} planets were explored!{Environment.NewLine}" +
                $"Astronauts info:{Environment.NewLine}";
            foreach (var item in astroRepo.Models)
            {
                string bagOfItems = "none";
                if (item.Bag.Items.Count > 0)
                {
                    bagOfItems = $"{string.Join(", ", item.Bag.Items)}";
                }
                returner += $"Name: {item.Name}{Environment.NewLine}" +
                    $"Oxygen: {item.Oxygen}{Environment.NewLine}" +
                    $"Bag items: {bagOfItems}{Environment.NewLine}";
            }
            return returner;
        }

        public string RetireAstronaut(string astronautName)
        {
            Astronaut astronaut = null;
            foreach (var item in astroRepo.Models)
            {
                if (item.Name == astronautName)
                {
                    astronaut = (Astronaut)item;
                }
            }
            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astroRepo.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
