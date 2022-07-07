using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public override string Name { get ; set ; }
        public override double WingSize { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override Food Food
        {
            get { return food; }
            set
            {
                food = value;
                Weight += Food.Quantity * 0.25;
                FoodEaten += Food.Quantity;
            }
        }

        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
        public Owl(string name, double wingSize, double weight)
            : base(name, wingSize,  weight)
        {

        }
    }
}
