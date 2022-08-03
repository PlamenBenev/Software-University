using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipments.Contracts;
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
        private ICollection<IEquipment> equipmentCol = new List<IEquipment>();
        private ICollection<IAthlete> athletesCol = new List<IAthlete>();

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
                _equipmentWeight = equipmentCol.Sum(x => x.Weight);
            }
        }
        public ICollection<IEquipment> Equipment
        {
            get { return equipmentCol; }
            private set { equipmentCol = value; }
        }

        public ICollection<IAthlete> Athletes
        {
            get { return athletesCol; }
            private set { athletesCol = value; }
        }

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
                names = $"{string.Join(", ", athletesCol)}";
            }

            string returner = $"{this.Name} is a {this.GetType().Name}:{Environment.NewLine}" +
                $"Athletes: {names}{Environment.NewLine}" +
                $"Equipment total count: {equipmentCol.Count}{Environment.NewLine}" +
                $"Equipment total weight: {EquipmentWeight} grams";

            return returner;
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            throw new NotImplementedException();
        }
    }
}
