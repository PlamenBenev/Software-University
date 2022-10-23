using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> Roaster { get; set; } = new List<Player>();

        public string Name { get; set; }
        public int Capacity { get; set; }

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public void AddPlayer(Player player)
        {
            if (Capacity > Roaster.Count)
            {
                Roaster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            foreach (var item in Roaster)
            {
                if (item.Name == name)
                {
                    Roaster.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            foreach (var item in Roaster)
            {
                if (item.Name == name)
                {
                    if (item.Rank != "Member")
                    {
                        item.Rank = "Member";
                    }
                    break;
                }
            }
        }
        public void DemotePlayer(string name)
        {
            foreach (var item in Roaster)
            {
                if (item.Name == name)
                {
                    if (item.Rank != "Trial")
                    {
                        item.Rank = "Trial";
                    }
                    break;
                }
            }
        }
        public Player[] KickPlayersByClass(string classs)
        {
            List<Player> list = new List<Player>();

            for (int i = 0; i < Roaster.Count; i++)
            {
                if (Roaster[i].Class == classs)
                {
                    list.Add(Roaster[i]);
                    Roaster.RemoveAt(i);
                    i--;
                }
            }

            Player[] kicked = list.ToArray();
            return kicked;
        }
        public int Count
        {
            get { return Roaster.Count; }
        }
        public string Report()
        {
            string returner = $"Players in the guild: {Name}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, Roaster)}";

            return returner;
        }
    }
}
