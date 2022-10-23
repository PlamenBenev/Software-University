using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public int NumberOfTopics
        {
            get => Topping.Count;
            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
            }
        }
        public double TotalCalories
        {
            get
            {
                double total = Dough.CaloriesPerGram;

                foreach (var topic in Topping)
                {
                    total += topic.CaloriesPerGram;
                }

                return total;
            }
        }

        public Dough Dough { get; set; }
        public List<Topping> Topping { get; set; } = new List<Topping>();
        public Pizza(string name, Dough dough)
        {
            Dough = dough;
            Name = name;
        }
        public void Add(Topping topping)
        {
            Topping.Add(topping);
            NumberOfTopics++;
        }
    }
}
