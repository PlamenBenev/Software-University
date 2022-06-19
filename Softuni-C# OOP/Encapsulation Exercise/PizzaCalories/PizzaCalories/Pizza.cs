using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        public string Name { get; set; }

        public Dough Dough { get; set; }

        public Pizza(string name, Dough dough)
        {
            Dough = dough;
            Name = name;
        }
    }
}
