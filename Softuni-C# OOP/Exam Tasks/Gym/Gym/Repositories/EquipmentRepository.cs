﻿using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> _equipmentList = new List<IEquipment>(); 
        public IReadOnlyCollection<IEquipment> Models => _equipmentList.AsReadOnly();

        public void Add(IEquipment model)
        {
            _equipmentList.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            IEquipment eq = null;
            foreach (var item in _equipmentList)
            {
                if (type == item.GetType().Name)
                {
                    eq = item;
                }
            }
            return eq;
        }

        public bool Remove(IEquipment model)
        {
            foreach (var item in _equipmentList)
            {
                if (item == model)
                {
                    _equipmentList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}