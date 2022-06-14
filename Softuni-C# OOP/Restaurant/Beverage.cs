using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public virtual double Milliliters { get; set; }
        public Beverage(string name, decimal price, double mil)
            : base(name, price)
        {
            Milliliters = mil;
        }
    }
}
