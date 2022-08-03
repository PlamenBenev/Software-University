using Gym.Models.Equipments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{
    public abstract class Equipment : IEquipment
    {
        private double _weight;
        private decimal _price;
        public Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }
        public double Weight
        { get { return _weight; } private set { _weight = value; } }

        public decimal Price { get { return _price; } private set { _price = value; } }
    }
}
