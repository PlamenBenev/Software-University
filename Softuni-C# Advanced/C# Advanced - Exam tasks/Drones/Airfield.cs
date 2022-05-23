using System;
using System.Collections.Generic;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; } = new List<Drone>();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public Airfield(string name, int cap, double ls)
        {
            Name = name;
            Capacity = cap;
            LandingStrip = ls;
        }
        public int Count
        {
            get { return Drones.Count; }
        }
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) ||
                drone.Range <= 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            foreach (var item in Drones)
            {
                if (item.Name == name)
                {
                    Drones.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;
            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Brand == brand)
                {
                    count++;
                    Drones.RemoveAt(i);
                    i--;
                }
            }
            return count;
        }
        public Drone FlyDrone(string name)
        {
            Drone drone = null;
            foreach (var item in Drones)
            {
                if (item.Name == name)
                {
                    item.Available = false;
                    drone = item;
                }
            }
            return drone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();

            foreach (var item in Drones)
            {
                if (item.Range >= range)
                {
                    item.Available = false;
                    drones.Add(item);
                }
            }
            return drones;
        }
        public string Report()
        {
            List<Drone> drones = new List<Drone>();
            foreach (var item in Drones)
            {
                if (item.Available == true)
                {
                    drones.Add(item);
                }
            }
            return $"Drones available at {this.Name}:{Environment.NewLine}" +
                   $"{ string.Join(Environment.NewLine, drones)}";
        }
    }
}
