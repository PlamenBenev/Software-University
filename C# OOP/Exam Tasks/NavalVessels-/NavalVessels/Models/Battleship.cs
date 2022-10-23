using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel,IBattleship
    {
        private bool sonarMode = false;

        public bool SonarMode
        {
            get { return sonarMode; }
            set { sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            if (!sonarMode)
            {
                sonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                sonarMode=false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed,300)
        {
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
                ArmorThickness = 300;
        }
        public override string ToString()
        {
            string onOrOff = "OFF";
            if (sonarMode)
            {
                onOrOff = "ON";
            }
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {onOrOff}";
        }
    }
}
