using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string tName,int badges, Pokemon pokeCollection)
        {
            TName = tName;
            Badges = badges;
            PokeCollection = new List<Pokemon>() { pokeCollection};
        }
        public string TName { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> PokeCollection { get; set; }
    }
}
