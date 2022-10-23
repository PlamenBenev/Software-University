using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> _foodList = new List<IBakedFood>();
        private ICollection<IDrink> _drinkList = new List<IDrink>();
        private int _tableNumber;
        private int _capacity;
        private int _numberOfPeople;
        private decimal _pricePerPerson;
        private bool isReserved = false;
        private decimal _price;
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            Price = pricePerPerson * NumberOfPeople;
        }
        private ICollection<IBakedFood> FoodOrders => _foodList;
        private ICollection<IDrink> DrinkOrders => _drinkList;

        public int TableNumber
        {
            get { return _tableNumber; } 
            private set { _tableNumber = value; }
        }

        public int Capacity
        {
            get { return _capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                _capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return _numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                _numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return _pricePerPerson; }
            private set
            {
                _pricePerPerson = value;
            }
        }

        public bool IsReserved
        {
            get { return isReserved; }
            private set
            {
                isReserved = value;
            }
        }

        public decimal Price
        {
            get { return _price; }
            private set
            {
                _price = value;
            }
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            isReserved = false;
            NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal bill = _price;
            foreach (var item in FoodOrders)
            {
                bill += item.Price;
            }
            foreach (var item in DrinkOrders)
            {
                bill += item.Price;
            }
            return bill;
        }

        public string GetFreeTableInfo()
        {
            string returner = $"Table: {TableNumber}{Environment.NewLine}" +
                 $"Type: {this.GetType().Name}{Environment.NewLine}" +
                 $"Capacity: {Capacity}{Environment.NewLine}" +
                 $"Price per Person: {PricePerPerson}";

            return returner;
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            isReserved = true;
        }
    }
}
