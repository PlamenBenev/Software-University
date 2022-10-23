using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        public Pokemon(string name,string element,int hp)
        {
            Name = name;
            Element = element;
            Health = hp;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
