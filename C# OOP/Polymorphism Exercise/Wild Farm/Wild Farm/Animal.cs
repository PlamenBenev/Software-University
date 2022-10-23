using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Food food;
        public abstract Food Food { get; set; }
        public abstract string Name { get; set; }
        public abstract double Weight { get; set; }
        public abstract int FoodEaten { get; set; }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
