using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<BaseHero> raid = new List<BaseHero>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    BaseHero druid = new Druid(name);
                    raid.Add(druid);
                }
                else if (type == "Paladin")
                {
                    BaseHero paladin = new Paladin(name);
                    raid.Add(paladin);
                }
                else if (type == "Rogue")
                {
                    BaseHero rogue = new Rogue(name);
                    raid.Add(rogue);
                }
                else if (type == "Warrior")
                {
                    BaseHero warrior = new Warrior(name);
                    raid.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }
            int boss = int.Parse(Console.ReadLine());
            int heroes = raid.Sum(x => x.Power);

            foreach (var item in raid)
            {
                Console.WriteLine(item.Castability());
            }

            if (boss <= heroes)
            {
                Console.WriteLine("Victory!");
            }
            else
                Console.WriteLine("Defeat...");
        }
    }
}
