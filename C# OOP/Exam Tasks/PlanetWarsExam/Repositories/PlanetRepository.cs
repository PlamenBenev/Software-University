using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planetList = new List<IPlanet>();
        public PlanetRepository()
        {

        }
        public IReadOnlyCollection<IPlanet> Models => planetList.AsReadOnly();

        public void AddItem(IPlanet model)
        {
            planetList.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planetList.Find(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            foreach (var item in planetList)
            {
                if (item.Name == name)
                {
                    planetList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
