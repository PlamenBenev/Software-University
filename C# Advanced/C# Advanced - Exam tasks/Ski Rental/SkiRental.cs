using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> Data { get; set; } = new List<Ski>();

        public string Name { get; set; }
        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (Capacity > Data.Count)
            {
                Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            foreach (var item in Data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    Data.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            Ski ski = null;
            int newest = 0;
            foreach (var item in Data)
            {
                if (item.Year > newest)
                {
                    ski = item;
                    newest = item.Year;
                }
            }
            return ski;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = null;
            foreach (var item in Data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    ski = item;
                }
            }
            return ski;
        }
        public int Count
        {
            get { return Data.Count; }
        }
        public string GetStatistics()
        {
            string returner = $"The skis stored in {Name}:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, Data)}";

            return returner;
        }
    }
}
