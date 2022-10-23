using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> _eggList;
        public EggRepository()
        {
            _eggList = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this._eggList;

        public void Add(IEgg model)
        {
            _eggList.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return _eggList.First(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            foreach (var item in _eggList)
            {
                if (item == model)
                {
                    _eggList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
