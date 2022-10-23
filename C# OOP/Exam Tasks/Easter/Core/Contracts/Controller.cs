using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core.Contracts
{
    public class Controller : IController
    {
        private BunnyRepository bunnyRepo = new BunnyRepository();
        private EggRepository eggRepo = new EggRepository();
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                bunnyRepo.Add(new HappyBunny(bunnyName));
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunnyRepo.Add(new SleepyBunny(bunnyName));
            }
            else
                throw new InvalidOperationException("Invalid bunny type.");

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);
            IBunny bunny = bunnyRepo.Models.First(x => x.Name == bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            bunny.AddDye(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);
            eggRepo.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List <IBunny> bunnyList = new List<IBunny>();
            IEgg egg = eggRepo.Models.First(x => x.Name == eggName);
            foreach (var item in bunnyRepo.Models)
            {
                if (item.Energy >= 50)
                {
                    bunnyList.Add(item);
                }
            }
            if (bunnyList.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            Workshop workshop = new Workshop();
            var newList = bunnyList.OrderByDescending(x => x.Energy);
            foreach (var item in newList)
            {
                workshop.Color(egg, item);
                if (item.Energy == 0)
                {
                    bunnyRepo.Remove(item);
                }
            }
            string isItDone = "not done";
            if (egg.IsDone() == true)
            {
                isItDone = "done";
            }
            return $"Egg {eggName} is {isItDone}.";
        }

        public string Report()
        {
            int colored = 0;
            foreach (var item in eggRepo.Models)
            {
                if (item.IsDone())
                    colored++;
            }
            string returner = $"{colored} eggs are done!{Environment.NewLine}" +
                $"Bunnies info:{Environment.NewLine}";

            foreach (var item in bunnyRepo.Models)
            {
                int count = 0;
                foreach (var dye in item.Dyes)
                {
                    if (dye.IsFinished() == false)
                    {
                        count++;
                    }
                }
                returner += $"Name: {item.Name}{Environment.NewLine}" +
                    $"Energy: {item.Energy}{Environment.NewLine}" +
                    $"Dyes: {count} not finished{Environment.NewLine}";
            }
            return returner;
        }
    }
}
