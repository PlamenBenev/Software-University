using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons = new List<IWeapon>();
        public WeaponRepository()
        {

        }
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.Find(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            foreach (var item in weapons)
            {
                if (item.GetType().Name == name)
                {
                    weapons.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
