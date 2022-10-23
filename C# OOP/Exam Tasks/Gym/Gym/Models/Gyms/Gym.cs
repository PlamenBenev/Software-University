using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string _name;
        private int _capacity;
        private double _equipmentWeight;
        private readonly ICollection<IEquipment> equipmentCol = new List<IEquipment>();
        private readonly ICollection<IAthlete> athletesCol = new List<IAthlete>();

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public string Name
        {
            get { return _name; }
            private set 
            { 
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                _name = value; 
            }
        }

        public int Capacity
        {
            get { return _capacity; }
            private set { _capacity = value; }
        }

        public double EquipmentWeight
        {
            get { return _equipmentWeight; }
            private set
            {
                _equipmentWeight = value;
            }
        }
        public ICollection<IEquipment> Equipment => equipmentCol;

        public ICollection<IAthlete> Athletes => athletesCol;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity <= athletesCol.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            athletesCol.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipmentCol.Add(equipment);
            EquipmentWeight += equipment.Weight;
        }

        public void Exercise()
        {
            foreach (var item in athletesCol)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            string names = "No athletes";
            if (athletesCol.Count > 0)
            {
                List<string> namesList = new List<string>();
                foreach (var item in athletesCol)
                {
                    namesList.Add(item.FullName);
                }
                names = $"{string.Join(", ", namesList)}";
            }

            string returner = $"{this.Name} is a {this.GetType().Name}:{Environment.NewLine}" +
                $"Athletes: {names}{Environment.NewLine}" +
                $"Equipment total count: {equipmentCol.Count}{Environment.NewLine}" +
                $"Equipment total weight: {_equipmentWeight:f2} grams{Environment.NewLine}";

            return returner;
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            foreach (var item in athletesCol)
            {
                if (item == athlete)
                {
                    athletesCol.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
