using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
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
            while (barbarians.Count > 0 && knights.Count > 0)
            {
                foreach (var barbarian in barbarians)
                {
                    for (int i = 0; i < knights.Count; i++)
                    {
                        if (barbarian.IsAlive && barbarian.Weapon != null)
                        {
                            knights[i].TakeDamage(barbarian.Weapon.DoDamage());
                            if (knights[i].IsAlive == false)
                            {
                                deathKnights++;
                                knights.Remove(knights[i]);
                                i--;
                            }
                        }
                    }
                }
                foreach (var knight in knights)
                {
                    for (int i = 0; i < barbarians.Count; i++)
                    {
                        if (knight.IsAlive && knight.Weapon != null)
                        {
                            barbarians[i].TakeDamage(knight.Weapon.DoDamage());
                            if (barbarians[i].IsAlive == false)
                            {
                                deathBarbarians++;
                                barbarians.Remove(barbarians[i]);
                                i--;
                            }
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
