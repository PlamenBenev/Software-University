using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons = new List<IWeapon>();
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void Add(IWeapon model)
        {
           weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            IWeapon weaponr = null;
            foreach (var weapon in weapons)
            {
                if (weapon.Name == name)
                {
                    weaponr = weapon;
                    break;
                }
            }
            return weaponr;
        }

        public bool Remove(IWeapon model)
        {
            foreach (var item in weapons)
            {
                if (item == model)
                {
                    weapons.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
