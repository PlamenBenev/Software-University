using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipments
{
    public class Kettlebell : Equipment
    {
        private const double weight = 1000;
        private const decimal price = 80m;
        public Kettlebell() : base(weight, price)
        {
        }
    }
}
