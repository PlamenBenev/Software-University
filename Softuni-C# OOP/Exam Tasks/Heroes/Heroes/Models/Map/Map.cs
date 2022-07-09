using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public abstract class Map
    {
        public string Fight(ICollection<IHero> heroes)
        {
            List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();

            foreach (var hero in heroes)
            {
                if (hero.bar)
            }
        }
    }
}
