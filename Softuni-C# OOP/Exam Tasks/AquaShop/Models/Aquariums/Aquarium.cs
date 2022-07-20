using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
       private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;
        public string Name
        {
            get { return name; }
             private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Capacity { get; }
        public int Comfort => this.Decorations.Sum(x => x.Comfort);
        public ICollection<IDecoration> Decorations => decorations;
        public ICollection<IFish> Fish => fish;

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }
        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            var aquType = this.GetType().Name;

            var fishType = fish.GetType().Name;

            if (aquType == "FreshwaterAquarium" && fishType == "SaltwaterFish" || aquType == "SaltwaterAquarium" && fishType == "FreshwaterFish")
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.Fish.Add(fish);

        }
        public void Feed()
        {
            foreach (var item in Fish)
            {
                item.Eat();
            }
        }
        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({GetType().Name}):");

            sb.AppendLine($"Fish: {(Fish.Any() ? string.Join(", ", GetFishNames()) : "none")}");

            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
        private List<string> GetFishNames()
        {
            List<string> list = new List<string>();

            foreach (var fish in Fish)
            {
                list.Add(fish.Name);
            }

            return list;
        }
        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }

        public Aquarium(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}
