using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> _planets = new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models => _planets.AsReadOnly();

        public void Add(IPlanet model)
        {
            _planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = null;
            foreach (IPlanet item in _planets)
            {
                if (item.Name == name)
                {
                    planet = item;
                }
            }
            return planet;
        }

        public bool Remove(IPlanet model)
        {
            foreach (var item in _planets)
            {
                if (item == model)
                {
                    _planets.Remove(model);
                    return true;
                }
            }
            return false;
        }
    }
}
