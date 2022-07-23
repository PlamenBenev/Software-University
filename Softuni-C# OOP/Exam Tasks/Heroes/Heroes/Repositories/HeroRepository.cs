using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes = new List<IHero>();
        public IReadOnlyCollection<IHero> Models => heroes.AsReadOnly();

        public void Add(IHero model)
        {
            heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            IHero hero = null;
            foreach (var item in heroes)
            {
                if (item.Name == name)
                {
                    hero = item;
                    break;
                }
            }
            return hero;
        }

        public bool Remove(IHero model)
        {
            foreach (var item in heroes)
            {
                if (item == model)
                {
                    heroes.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
