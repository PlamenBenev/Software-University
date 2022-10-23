using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    internal class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races = new List<IRace>();
        public IReadOnlyCollection<IRace> Models =>races.AsReadOnly();

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            IRace race = null;
            foreach (var item in races)
            {
                if (item.RaceName == "name")
                {
                    race = item;
                    break;
                }
            }
            return race;
        }

        public bool Remove(IRace model)
        {
            foreach (var item in races)
            {
                if (item == model)
                {
                    races.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
