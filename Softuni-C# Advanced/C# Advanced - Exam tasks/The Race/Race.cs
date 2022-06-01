using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public List<Racer> Racer { get; set; } = new List<Racer>();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public void Add(Racer racer)
        {
            if (Capacity > Racer.Count)
            {
                Racer.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            foreach (var item in Racer)
            {
                if (item.Name == name)
                {
                    Racer.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            Racer racerr = null;
            int oldest = 0;
            foreach (var item in Racer)
            {
                if (item.Age > oldest)
                {
                    racerr = item;
                    oldest = item.Age;
                }
            }
            return racerr;
        }
        public Racer GetRacer(string name)
        {
            Racer racerr = null;
            foreach (var item in Racer)
            {
                if (item.Name == name)
                {
                    racerr = item;
                }
            }
            return racerr;
        }
        public Racer GetFastestRacer()
        {
            Racer racerr = null;
            int fastest = 0;
            foreach (var item in Racer)
            {
                if (item.Car.Speed > fastest)
                {
                    racerr = item;
                    fastest = item.Age;
                }
            }
            return racerr;
        }
        public int Count
        {
            get { return Racer.Count; }
        }
        public string Report()
        {
            string returner = $"Racers participating at { Name}{Environment.NewLine}:" +
                $"{string.Join(Environment.NewLine, Racer)}";

            return returner;
        }
    }
}
