using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Trainer> trainers = new List<Trainer>();

            while (input[0] != "Tournament")
            {
                Pokemon pokemon = new Pokemon(input[1], input[2], int.Parse(input[3]));
                Trainer trainer = new Trainer(input[0], 0, pokemon);

                bool itContains = false;
                foreach (var item in trainers)
                {
                    if (item.TName == input[0])
                    {
                        item.PokeCollection.Add(pokemon);
                        itContains = true;
                        break;
                    }
                }
                if (!itContains)
                {
                    trainers.Add(trainer);
                }


                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool itsFine = false;

                    foreach (var pokemon in trainer.PokeCollection)
                    {
                        if (pokemon.Element == input[0])
                        {
                            trainer.Badges++;
                            itsFine = true;
                            break;
                        }
                    }
                    if (!itsFine)
                    {
                        for (int poki = 0; poki < trainer.PokeCollection.Count; poki++)
                        {
                            trainer.PokeCollection[poki].Health -= 10;

                            if (trainer.PokeCollection[poki].Health <= 0)
                            {
                                trainer.PokeCollection.RemoveAt(poki);
                                poki--;
                            }
                        }
                    }
                }
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            trainers = trainers.OrderByDescending(x => x.Badges).ToList();

            foreach (var item in trainers)
            {
                Console.WriteLine($"{item.TName} {item.Badges} {item.PokeCollection.Count}");
            }
        }
    }
}
