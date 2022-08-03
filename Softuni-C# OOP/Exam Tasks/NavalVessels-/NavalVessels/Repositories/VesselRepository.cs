using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vessels = new List<IVessel>();
        public IReadOnlyCollection<IVessel> Models => vessels.AsReadOnly();

        public void Add(IVessel model)
        {
            vessels.Add(model);

        }

        public IVessel FindByName(string name)
        {
            IVessel vessel = null;
            foreach (var item in vessels)
            {
                if (item.Name == name)
                {
                    vessel = item;
                    break;
                }
            }
            return vessel;
        }

        public bool Remove(IVessel model)
        {
            foreach (var item in vessels)
            {
                if (item == model)
                {
                    vessels.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
