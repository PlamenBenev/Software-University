using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; } = new List<Fish>();
        public string Material { get; set; }
        public int Capacity { get; set; }
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }
        public int Count
        {
            get { return Fish.Count; }
        }
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 ||
                fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            foreach (var item in Fish)
            {
                if (item.Weight == weight)
                {
                    Fish.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            Fish fish = null;
            foreach (var item in Fish)
            {
                if (item.FishType == fishType)
                {
                   fish = item;
                }
            }
            return fish;
        }
        public Fish GetBiggestFish()
        {
            Fish fish = null;
            double longest = 0;
            foreach (var item in Fish)
            {
                if (item.Length > longest)
                {
                    longest = item.Length;
                    fish = item;
                }
            }
            return fish;
        }
        public string Report()
        {
            List<Fish> orderList = Fish.OrderByDescending(x => x.Length).ToList();

            return $"Into the {Material}:{Environment.NewLine}{String.Join(Environment.NewLine, orderList)}";


        }
    }
}
