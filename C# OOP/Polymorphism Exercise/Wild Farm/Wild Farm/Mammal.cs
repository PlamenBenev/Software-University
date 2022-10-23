using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        public abstract string LivingRegion { get; set; }
        public Mammal(string name, double weight , string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
    }
}
