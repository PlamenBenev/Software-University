using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double toppingGrams;
        private double weight;

        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                if (value.ToLower() == "meat")
                {
                    toppingGrams = 1.2;
                }
                else if (value.ToLower() == "veggies")
                {
                    toppingGrams = 0.8;
                }
                else if (value.ToLower() == "cheese")
                {
                    toppingGrams = 1.1;
                }
                else if (value.ToLower() == "sauce")
                {
                    toppingGrams = 0.9;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                return 2 * weight * toppingGrams;
            }
        }
        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
    }
}
