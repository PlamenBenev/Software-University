using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> _bunnys;
        public BunnyRepository()
        {
            _bunnys = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => _bunnys;

        public void Add(IBunny model)
        {
            _bunnys.Add(model);
        }

        public IBunny FindByName(string name)
        {
            IBunny bunny = null;
            foreach (IBunny item in _bunnys)
            {
                if (bunny.Name == name)
                    bunny = item;
                break;
            }
            return bunny;
        }

        public bool Remove(IBunny model)
        {
            foreach (var item in _bunnys)
            {
                if (item == model)
                {
                    _bunnys.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
