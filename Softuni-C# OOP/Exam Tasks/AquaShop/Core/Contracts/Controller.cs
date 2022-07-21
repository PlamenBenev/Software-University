using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository decRep = new DecorationRepository();
        private List<IAquarium> aquarium = new List<IAquarium>();
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquar = null;
            if (aquariumType != "SaltwaterAquarium" &&
                aquariumType != "FreshwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            if (aquariumType == "SaltwaterAquarium")
            {
                aquar = new SaltwaterAquarium(aquariumName);
            }
            else if (aquariumType == "FreshwaterAquarium")
            {
                aquar = new FreshwaterAquarium(aquariumName);
            }
            aquarium.Add(aquar);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" &&
                decorationType != "Plant")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            if (decorationType == "Ornament")
            {
                decRep.Add(new Ornament());
            }
            else
            {
                decRep.Add(new Plant());
            }
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" &&
                fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            foreach (var item in aquarium)
            {
                if (item.Name == aquariumName)
                {
                    string type = item.GetType().Name;
                    if (fishType == "FreshwaterFish" && type == "FreshwaterAquarium")
                    {
                        item.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                    }
                    else if (fishType == "SaltwaterFish" && type == "SaltwaterAquarium")
                    {
                        item.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                    }
                    else
                    {
                        return "Water not suitable.";
                    }
                }
            }
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal price = 0;
            foreach (var item in aquarium)
            {
                if (item.Name == aquariumName)
                {
                    foreach (var fish in item.Fish)
                    {
                        price += fish.Price;
                    }
                    foreach (var decor in item.Decorations)
                    {
                        price += decor.Price;
                    }
                }
            }
            return $"The value of Aquarium {aquariumName} is {price:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            int fedCount = 0;
            foreach (var item in aquarium)
            {
                if (item.Name == aquariumName)
                {
                    item.Feed();
                    fedCount = item.Fish.Count;
                }
            }
            return $"Fish fed: {fedCount}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            string type = null;

            foreach (var item in decRep.Models)
            {
                if (item.GetType().Name == decorationType)
                {
                    type = item.GetType().Name;
                }
            }
            if (type == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            Decoration decorationToAdd = null;
            foreach (var item in decRep.Models)
            {
                if (item.GetType().Name == decorationType)
                {
                    decorationToAdd = (Decoration)item;
                    decRep.Remove(item);
                    break;
                }
            }
            foreach (var name in aquarium)
            {
                if (name.Name == aquariumName)
                {
                    name.AddDecoration(decorationToAdd);
                }
            }
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            string info = null;

            foreach (var item in aquarium)
            {
                info += item.GetInfo() + Environment.NewLine;
            }
            return info;
        }
    }
}
