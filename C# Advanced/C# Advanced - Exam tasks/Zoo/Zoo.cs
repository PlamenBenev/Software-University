using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public string Name { get; set; }
        public int Capacity { get; set; }

        List<Animal> animals = new List<Animal>();
        public Zoo(string name, int cap)
        {
            Name = name;
            Capacity = cap;
            Animals = animals;
        }
        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Capacity <= animals.Count)
            {
                return "The zoo is full.";
            }
            else
            {
                animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }
        public int RemoveAnimals(string species)
        {
            int removed = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Species == species)
                {
                    animals.RemoveAt(i);
                    removed++;
                    i--;
                }
            }
            return removed;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> listByDiet = new List<Animal>();
            foreach (var item in animals)
            {
                if (item.Diet == diet)
                {
                    listByDiet.Add(item);
                }
            }
            return listByDiet;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            return animals.First(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Length >= minimumLength && animals[i].Length <= maximumLength)
                {
                    count++;
                }
            }
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
