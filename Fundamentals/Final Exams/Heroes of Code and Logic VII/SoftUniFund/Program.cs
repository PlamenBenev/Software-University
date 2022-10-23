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
            int num = int.Parse(Console.ReadLine());
            string input = "";
            List<Heroes> heroes = new List<Heroes>();
            for (int i = 0; i < num; i++)
            {
                input = Console.ReadLine();
                string[] token = input.Split(' ');
                Heroes hero = new Heroes(token[0], int.Parse(token[1]), int.Parse(token[2]));

                heroes.Add(hero);
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                string[] token = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "CastSpell")
                {
                    foreach (var item in heroes)
                    {
                        if (item.Name == token[1])
                        {
                            if (item.Mp >= int.Parse(token[2]))
                            {
                                item.Mp -= int.Parse(token[2]);
                                Console.WriteLine($"{item.Name} has successfully cast {token[3]} and now has {item.Mp} MP!");
                            }
                            else
                                Console.WriteLine($"{item.Name} does not have enough MP to cast {token[3]}!");
                        }
                    }
                }
                else if (token[0] == "TakeDamage")
                {
                    foreach (var item in heroes)
                    {
                        if (item.Name == token[1])
                        {
                            if (item.Hp >= int.Parse(token[2]))
                            {
                                item.Hp -= int.Parse(token[2]);
                                Console.WriteLine($"{item.Name} was hit for {token[2]} HP by {token[3]} and now has {item.Hp} HP left!");
                            }
                            else
                            {
                                Console.WriteLine($"{item.Name} has been killed by {token[3]}!");
                                heroes.Remove(item);
                                break;
                            }
                        }
                    }
                }
                else if (token[0] == "Recharge")
                {
                    foreach (var item in heroes)
                    {
                        if (item.Name == token[1])
                        {
                            int rest = int.Parse(token[2]);
                            if (item.Mp + rest > 200)
                            {
                                rest = 200 - item.Mp;
                                item.Mp = 200;
                            }
                            item.Mp += int.Parse(token[2]);
                            Console.WriteLine($"{item.Name} recharged for {rest} MP!");
                        }
                    }
                }
                else if (token[0] == "Heal")
                {
                    foreach (var item in heroes)
                    {
                        if (item.Name == token[1])
                        {
                            int healedfor = int.Parse(token[2]);
                            if (item.Hp + healedfor > 100)
                            {
                                healedfor = 100 - item.Hp;
                                item.Hp = 100;
                            }
                            item.Hp += int.Parse(token[2]);
                            Console.WriteLine($"{item.Name} healed for {healedfor} HP!");
                        }
                    }
                }
                input = Console.ReadLine();
            }

            heroes = heroes.OrderByDescending(x => x.Hp).ToList();

            foreach (var item in heroes)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine($"  HP: {item.Hp}");
                Console.WriteLine($"  MP: {item.Mp}");
            }
        }
    }
}
class Heroes
{
    public Heroes(string name, int hp, int mp)
    {
        Name = name;
        Hp = hp;
        Mp = mp;
    }
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
}