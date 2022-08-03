using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string name;
        private int combarXP;
        private List<IVessel> vessels = new List<IVessel>();
        public string FullName
        {
            get { return name; }
            private set
            {
                name = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
            }
        }
        public int CombatExperience
        {
            get { return combarXP; }
            private set { combarXP = value; }
        }
        public ICollection<IVessel> Vessels
        {
            get {  return vessels; }
            private set
            {
                vessels = (List<IVessel>)value;
            }
        }

        public Captain(string fullName)
        {
            FullName = fullName;
        }
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            vessels.Add(vessel);
        }
        public void IncreaseCombatExperience()
        {
            this.combarXP += 10;
        }

        public string Report()
        {
            string returner1 = $"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.{Environment.NewLine}";
            string returner2 = "";
            if (Vessels.Count > 0)
            {
                foreach (var item in Vessels)
                {
                    returner2 += item.ToString() + Environment.NewLine;
                }
            }
            return returner1 + returner2;
        }
    }
}
