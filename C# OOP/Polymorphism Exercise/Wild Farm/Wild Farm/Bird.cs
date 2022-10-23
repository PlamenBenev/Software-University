using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public abstract double WingSize { get; set; }

        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }
        public override string ToString()
        {
            return $"Birds [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
