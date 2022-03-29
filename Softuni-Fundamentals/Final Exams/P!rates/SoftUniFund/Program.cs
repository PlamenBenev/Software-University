using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Targets> targets = new List<Targets>();
            while (input != "Sail")
            {
                string[] token = input.Split("||");
                Targets target = new Targets(token[0], int.Parse(token[1]), int.Parse(token[2]));
                bool wehaveit = false;
                foreach (var item in targets)
                {
                    if (item.City == token[0])
                    {
                        item.Population += int.Parse(token[1]);
                        item.Gold += int.Parse(token[2]);
                        wehaveit = true;
                    }
                }
                if (!wehaveit)
                {
                    targets.Add(target);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                string[] token = input.Split("=>");

                if (token[0] == "Plunder")
                {
                    foreach (var item in targets)
                    {
                        if (item.City == token[1])
                        {
                            int popul = 0;
                            int gol = 0;
                            if (int.Parse(token[2]) >= item.Population)
                            {
                                popul = item.Population;
                            }
                            else
                                popul = int.Parse(token[2]);

                            if (int.Parse(token[3]) >= item.Gold)
                            {
                                gol = item.Gold;
                            }
                            else
                                gol = int.Parse(token[3]);

                            item.Population -= popul;
                            item.Gold -= gol;
                            Console.WriteLine($"{item.City} plundered! {gol} gold stolen, {popul} citizens killed.");
                            if (item.Population <= 0 || item.Gold <= 0)
                            {
                                Console.WriteLine($"{item.City} has been wiped off the map!");
                                targets.Remove(item);
                                break;
                            }
                        }
                    }
                }
                else if (token[0] == "Prosper")
                {
                    foreach (var item in targets)
                    {
                        if (item.City == token[1])
                        {
                            if (int.Parse(token[2]) > 0)
                            {
                                item.Gold += int.Parse(token[2]);
                                Console.WriteLine($"{token[2]} gold added to the city treasury. {item.City} now has {item.Gold} gold.");
                            }
                            else
                                Console.WriteLine($"Gold added cannot be a negative number!");
                        }
                    }
                }
                input = Console.ReadLine();
            }
            if (targets.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targets.Count} wealthy settlements to go to:");
                foreach (var item in targets)
                {
                    Console.WriteLine($"{item.City} -> Population: {item.Population} citizens, Gold: {item.Gold} kg");
                }
            }
            else
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
        /*
            Tortuga||345000||1250
            Santo Domingo||240000||630
            Havana||410000||1100
            Sail
            Plunder=>Tortuga=>75000=>380
            Prosper=>Santo Domingo=>180
            End
        */

    }
}
class Targets
{
    public Targets(string city, int population, int gold)
    {
        City = city;
        Population = population;
        Gold = gold;
    }
    public string City { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }

}