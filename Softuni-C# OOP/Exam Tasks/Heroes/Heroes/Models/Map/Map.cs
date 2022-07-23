using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public abstract class Map : IMap
    {
        public string Fight(ICollection<IHero> heroes)
        {
            List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();
            int deathKnights = 0;
            int deathBarbarians = 0;
            foreach (var hero in heroes)
            {
                if (hero.GetType().Name == "Barbarian")
                {
                    barbarians.Add(hero);
                }
                else if (hero.GetType().Name == "Knight")
                {
                    knights.Add(hero);
                }
            }

            foreach (var knight in knights)
            {
                if (knight.IsAlive)
                {
                    foreach (var barbarian in barbarians)
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                        if (barbarian.IsAlive == false)
                        {
                            deathBarbarians++;
                        }
                    }
                }
            }
            foreach (var barbarian in barbarians)
            {
                if (barbarian.IsAlive)
                {
                    foreach (var knight in knights)
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                        if (knight.IsAlive == false)
                        {
                            deathKnights++;
                        }
                    }
                }
            }

            if (barbarians.Count == 0)
            {
                return $"The knights took {deathKnights} casualties but won the battle.";
            }
            return $"The barbarians took {deathBarbarians} casualties but won the battle.";
        }
    }
}
