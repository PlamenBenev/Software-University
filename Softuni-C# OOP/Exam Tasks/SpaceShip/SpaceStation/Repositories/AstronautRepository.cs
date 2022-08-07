using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> _list = new List<IAstronaut>();
        public IReadOnlyCollection<IAstronaut> Models => _list.AsReadOnly();

        public void Add(IAstronaut model)
        {
            _list.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = null;
            foreach (var item in _list)
            {
                if (item.Name == name)
                {
                    astronaut = item;
                }
            }
            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            foreach (var item in _list)
            {
                if (item ==  model)
                {
                    _list.Remove(model);
                    return true;
                }
            }
            return false;
        }
    }
}
