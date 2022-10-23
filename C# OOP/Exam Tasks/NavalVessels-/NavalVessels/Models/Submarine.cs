using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel,ISubmarine
    {
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed,200)
        {
        }

        public bool SubmergeMode
        {
            get { return submergeMode; }
            set { submergeMode = value; }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {
                ArmorThickness = 200;
            }
        }
        public void ToggleSubmergeMode()
        {
            if (!submergeMode)
            {
                submergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                submergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }
        public override string ToString()
        {
            string onOrOff = "OFF";
            if (submergeMode)
            {
                onOrOff = "ON";
            }
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {onOrOff}";
        }
    }
}
