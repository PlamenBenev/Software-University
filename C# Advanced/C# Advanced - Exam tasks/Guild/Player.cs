using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public Player(string name, string classs)
        {
            Name = name;
            Class = classs;
            Rank = "Trial";
            Description = "n/a";
        }

        public override string ToString()
        {
            string returner = $"Player {Name}: {Class}{Environment.NewLine}" +
                $"Rank: {Rank}{Environment.NewLine}" +
                $"Description: {Description}";

            return returner;
        }
    }
}
