using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> _cars = new List<ICar>();
        public IReadOnlyCollection<ICar> Models => _cars.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            _cars.Add(model);
        }

        public ICar FindBy(string property)
        {
            ICar car = null;
            foreach (var item in _cars)
            {
                if (item.VIN == property)
                {
                    car = item;
                    break;
                }
            }
            return car;
        }

        public bool Remove(ICar model)
        {
            foreach (var item in _cars)
            {
                if (item == model)
                {
                    _cars.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
