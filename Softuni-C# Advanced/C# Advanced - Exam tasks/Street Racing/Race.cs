using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Dictionary<Car, string> Participants { get; set; } =
            new Dictionary<Car, string>();

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxhorsepower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxhorsepower;
        }

        public int Count
        {
            get { return Participants.Count; }
        }

        public void Add(Car car)
        {
            foreach (var item in Participants)
            {
                if (item.Value == car.LicensePlate)
                {
                    return;
                }
            }
            if (Capacity > Participants.Count && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car, car.LicensePlate);
            }
            //return;
        }
        public bool Remove(string licensePlate)
        {
            foreach (var item in Participants)
            {
                if (item.Value == licensePlate)
                {
                    Participants.Remove(item.Key);
                    return true;
                }
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            Car car = null;
            foreach (var item in Participants)
            {
                if (item.Value == licensePlate)
                {
                    car = item.Key;
                }
            }
            return car;
        }
        public Car GetMostPowerfulCar()
        {
            Car car = null;
            int maxHp = 0;
            foreach (var item in Participants)
            {
                if (maxHp < item.Key.HorsePower)
                {
                    maxHp = item.Key.HorsePower;
                    car = item.Key;
                }
            }
            return car;
        }
        public string Report()
        {
            string returner = $"Race: {Name} - Type: {Type} (Laps: {Laps}) {Environment.NewLine}" +
                $"{ string.Join(Environment.NewLine, Participants.Keys)}";

            return returner;
        }
    }
}
