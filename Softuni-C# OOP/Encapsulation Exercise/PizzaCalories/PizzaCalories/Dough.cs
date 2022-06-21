using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string bakingTechnique;
        private string flourType;
        private double flourGrams;
        private double bakingGrams;
        private double weight;

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() == "white")
                {
                    flourGrams = 1.5;
                }
                else if (value.ToLower() == "wholegrain")
                {
                    flourGrams = 1.0;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() == "crispy")
                {
                    bakingGrams = 0.9;
                }
                else if (value.ToLower() == "chewy")
                {
                    bakingGrams = 1.1;
                }
                else if (value.ToLower() == "homemade")
                {
                    bakingGrams = 1.0;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public double CaloriesPerGram
        {
            get
            {
                return (2 * Weight) * flourGrams * bakingGrams;
            }
        }
    }
}
