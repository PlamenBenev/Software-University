using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }
        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override string LivingRegion { get;set; }
        public override string Name { get; set; }
        public override double Weight { get; set; } 
        public override int FoodEaten { get; set; }
        public override Food Food
        {
            get { return food; }
            set
            {
                food = value;
                Weight += Food.Quantity * 0.10;
                FoodEaten += Food.Quantity;
            }
        }
    }
}
