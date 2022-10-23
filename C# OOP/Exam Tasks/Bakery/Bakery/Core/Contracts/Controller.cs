using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods = new List<BakedFood>();
        private List<Drink> drinks = new List<Drink>();
        private List<Table> tables = new List<Table>();
        public Controller()
        {

        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            else
                return "";

            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood food;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            else 
                return "";

            bakedFoods.Add(food);
            return $"Added {food.Name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            else
                return "";

            tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            string returner = "";
            foreach (var item in tables)
            {
                if (!item.IsReserved)
                {
                    returner += item.GetFreeTableInfo();
                }
            }
            return returner;
        }

        public string GetTotalIncome()
        {
            decimal total = 0;

            foreach (var item in tables)
            {
                total += item.GetBill();
            }
            return $"Total income: {total:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.Find(x => x.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            // table.Clear();
            return $"Table: {tableNumber}{Environment.NewLine}" +
                $"Bill: {bill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.Find(x => x.TableNumber == tableNumber);
            Drink drink = 
                drinks.Find(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            BakedFood food = bakedFoods.Find(x => x.Name == foodName);
            Table table = tables.Find(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (var item in tables)
            {
                if (!item.IsReserved && item.Capacity > numberOfPeople)
                {
                    item.Reserve(numberOfPeople);
                    return $"Table {item.TableNumber} has been reserved for {numberOfPeople} people";
                }
            }
            return $"No available table for {numberOfPeople} people";
        }
    }
}
