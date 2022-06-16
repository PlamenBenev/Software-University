using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMilliliters = 50;
        private const decimal coffeePrice = 3.50m;
        public double Coffeine { get; set; }
        public Coffee(string name, double coffeine)
            : base(name, 0, 0)
        {
            Coffeine = coffeine;
        }
        public override double Milliliters => coffeeMilliliters;
        public override decimal Price => coffeePrice;
    }
}
