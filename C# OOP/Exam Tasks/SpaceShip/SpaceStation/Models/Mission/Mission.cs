using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> itemsToRemove = new List<string>();
            foreach (var item in astronauts)
            {
                foreach (var items in planet.Items)
                {
                    if (item.Oxygen > 0 && !itemsToRemove.Contains(items))
                    {
                        item.Bag.Items.Add(items);
                        //planet.Items.Remove(items);
                        itemsToRemove.Add(items);
                        item.Breath();
                    }
                }
            }
        }
    }
}
