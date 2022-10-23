using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VetClinic
{
    public class Clinic
    {
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public int Capacity { get; set; }

        public Clinic(int capacity)
        {
            Capacity = capacity;
        }
        public void Add(Pet pet)
        {
            if (Pets.Count < Capacity)
            {
                Pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            foreach (var item in Pets)
            {
                if (item.Name == name)
                {
                    Pets.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = null;
            foreach (var item in Pets)
            {
                if (item.Name == name && item.Owner == owner)
                {
                    pet = item;
                }
            }
            return pet;
        }
        public Pet GetOldestPet()
        {
            int oldest = 0;
            Pet pet = null;
            foreach (var item in Pets)
            {
                if (oldest < item.Age)
                {
                    oldest = item.Age;
                    pet = item;
                }
            }
            return pet;
        }
        public int Count
        { get { return Pets.Count; } }

        public string GetStatistics()
        {
            string returner = $"The clinic has the following patients:{Environment.NewLine}";

            foreach (var item in Pets)
            {
                returner += $"Pet {item.Name} with owner: {item.Owner}{Environment.NewLine}";
            }
            return returner;
        }
    }
}
