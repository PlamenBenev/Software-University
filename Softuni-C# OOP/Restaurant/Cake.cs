using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double newGrams = 250;
        private const double newCalories = 1000;
        private const decimal newPrice = 5m;
        public Cake(string name)
            : base(name, 0, 0, 0)
        {

        }
        public override double Grams => newGrams;
        public override double Calories => newCalories;
        public override decimal Price => newPrice;
    }
}
