using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animals
    {
        public Dog(string name, string fauvorite)
            : base(name, fauvorite)
        {
            Name = name;
            FavouriteFood = fauvorite;
        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "Djav";
        }
    }
}
