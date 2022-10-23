using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public override string Name { get; set; }
        public override double WingSize { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override Food Food
        {
            get { return food; }
            set
            {
                food = value;
                Weight += Food.Quantity * 0.35;
                FoodEaten += Food.Quantity;
            }
        }

        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

    }
}
