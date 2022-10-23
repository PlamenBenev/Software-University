using Gym.Models;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core.Contracts
{
    internal class Controller : IController
    {
        private EquipmentRepository repo = new EquipmentRepository();
        private ICollection<IGym> gyms = new List<IGym>();
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = null;

            foreach (var item in gyms)
            {
                if (gymName == item.Name)
                {
                    gym = item;
                }
            }
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            if (gym.GetType().Name == "BoxingGym" && athleteType == "Boxer")
            {
                gym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
            }
            else if (gym.GetType().Name == "WeightliftingGym" && athleteType == "Weightlifter")
            {
                gym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
            }
            else
            {
                return "The gym is not appropriate.";
            }
            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                repo.Add(new BoxingGloves());
            }
            else if (equipmentType == "Kettlebell")
            {
                repo.Add(new Kettlebell());
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            double weight = 0;
            foreach (var item in gyms)
            {
                if (gymName == item.Name)
                {
                    weight = item.EquipmentWeight;
                }
            }
            return $"The total weight of the equipment in the gym {gymName} is {weight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            Equipment equipmentToAdd = null;
            foreach (var item in repo.Models)
            {
                if (item.GetType().Name == equipmentType)
                {
                    equipmentToAdd = (Equipment)item;
                    repo.Remove(item);
                    break;
                }
            }
            if (equipmentToAdd == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            foreach (var item in gyms)
            {
                if (item.Name == gymName)
                {
                    item.AddEquipment(equipmentToAdd);
                    break;
                }
            }
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            string returner = "";
            foreach (var item in gyms)
            {
                returner += item.GymInfo();
            }
            return returner;
        }

        public string TrainAthletes(string gymName)
        {
            int count = 0;
            foreach (var item in gyms)
            {
                if (item.Name == gymName)
                {
                    item.Exercise();
                    count = item.Athletes.Count;
                }
            }
            return $"Exercise athletes: {count}.";
        }
    }
}
