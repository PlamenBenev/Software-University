using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = 100;
        }
        public override string Castability()
        {
            return $"Warrior - {Name} hit for {Power} damage";
        }
    }
}
