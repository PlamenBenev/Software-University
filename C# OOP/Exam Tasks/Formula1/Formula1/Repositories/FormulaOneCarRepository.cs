using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars = new List<IFormulaOneCar>();
        public IReadOnlyCollection<IFormulaOneCar> Models =>
            cars.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            IFormulaOneCar car = null;
            foreach (var item in cars)
            {
                if (item.Model == name)
                {
                    car = item;
                    break;
                }
            }
            return car;
        }

        public bool Remove(IFormulaOneCar model)
        {
            foreach (var item in cars)
            {
                if (item == model)
                {
                    cars.Remove(item);

                    return true;
                }
            }
            return false;
        }
    }
}
