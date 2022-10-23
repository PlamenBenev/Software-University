using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> unitList = new List<IMilitaryUnit>();
        public UnitRepository()
        {

        }
        public IReadOnlyCollection<IMilitaryUnit> Models => unitList.AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
            unitList.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return unitList.Find(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            foreach (var item in unitList)
            {
                if (item.GetType().Name == name)
                {
                    unitList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
