using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string _name;
        private int _portion;
        private decimal _price;
        private string _brand;
        public Drink(string name, int portion, decimal price, string brand)
        {
            Name = name;
            Portion = portion;
            Price = price;
            Brand = brand;
        }
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                _name = value;
            }
        }

        public int Portion
        {
            get { return _portion; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Portion cannot be less or equal to zero");
                }
                _portion = value;
            }
        }

        public decimal Price
        {
            get { return _price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                _price = value;
            }
        }

        public string Brand
        {
            get { return _brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }
                _brand = value;
            }
        }
        public override string ToString()
        {
            return $"{Name} {Brand} - {Portion}ml - {Price:f2}lv";
        }
    }
}
