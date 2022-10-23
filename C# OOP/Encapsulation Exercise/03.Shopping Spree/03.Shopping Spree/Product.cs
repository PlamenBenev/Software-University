using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;
        public string Name
        {
            get; 
            private set;
        }
        public double Cost
        {
            get;
            private set;
        }
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
