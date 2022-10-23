using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> _list = new List<IRacer>();
        public IReadOnlyCollection<IRacer> Models => _list.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            _list.Add(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer model = null;
            foreach (var item in _list)
            {
                if (item.Username == property)
                {
                    model = item;
                    break;
                }
            }
            return model;
        }

        public bool Remove(IRacer model)
        {
            foreach (var item in _list)
            {
                if (item == model)
                {
                    _list.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
