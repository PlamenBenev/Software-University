using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animals
    {
        public Cat(string name, string favourite) : base(name, favourite)
        {
            Name = name;
            FavouriteFood = favourite;
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
        }
    }
}
