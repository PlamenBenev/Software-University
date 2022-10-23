using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int _capacity;
        private readonly List<Item> _items = new List<Item>();
        public int Capacity
        {
            get { return _capacity; }
            private set { _capacity = value; }
        }

        public int Load => _items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

        int IBag.Capacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Bag(int capacity)
        {
            Capacity = capacity;
        }

        public void AddItem(Item item)
        {
            if (_items.Count > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            _items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            Item item = _items.First(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            _items.Remove(item);
            return item;
        }
    }
}
