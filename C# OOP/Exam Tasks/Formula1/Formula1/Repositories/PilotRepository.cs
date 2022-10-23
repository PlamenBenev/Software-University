using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots = new List<IPilot>();
        public IReadOnlyCollection<IPilot> Models => pilots.AsReadOnly();

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilot = null;
            foreach (var item in pilots)
            {
                if (item.FullName == name)
                {
                    pilot = item;
                    break;
                }
            }
            return pilot;
        }

        public bool Remove(IPilot model)
        {
            foreach (var item in pilots)
            {
                if (item == model)
                {
                    pilots.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
