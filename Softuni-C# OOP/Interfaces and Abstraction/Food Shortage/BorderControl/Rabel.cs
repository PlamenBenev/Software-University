using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public class Rabel : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }

        public Rabel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public void BuyFood()
        {
            Food += 5;
        }
    }
}
