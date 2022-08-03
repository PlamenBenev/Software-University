using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Core.Contracts
{
    public class Controller : IController
    {
        private VesselRepository repo = new VesselRepository();
        private List<Captain> captains = new List<Captain>();
        public Controller()
        {

        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            Captain captain = null;
            Vessel vessel = null;
            foreach (var item in captains)
            {
                if (item.FullName == selectedCaptainName)
                {
                    captain = item;
                }
            }
            foreach (var item in repo.Models)
            {
                if (item.Name == selectedVesselName)
                {
                    vessel = (Vessel)item;
                }
            }
            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            captain.Vessels.Add(vessel);
            vessel.Captain = captain;

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            Vessel attacker = null;
            Vessel defending = null;

            foreach (var item in repo.Models)
            {
                if (item.Name == attackingVesselName)
                {
                    attacker = (Vessel)item;
                }
                if (item.Name == defendingVesselName)
                {
                    defending = (Vessel)item;
                }
            }
            if (attacker == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (defending == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            if (attacker.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defending.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";

            }
            attacker.Attack(defending);
            attacker.Captain.IncreaseCombatExperience();
            defending.Captain.IncreaseCombatExperience();
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defending.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            string returner = "";
            foreach (var item in captains)
            {
                if (item.FullName == captainFullName)
                {
                    returner += item.Report();
                    break;
                }
            }
            return returner;
        }

        public string HireCaptain(string fullName)
        {
            foreach (var item in captains)
            {
                if (item.FullName == fullName)
                {
                    return $"Captain {fullName} is already hired.";
                }
            }
            Captain capt = new Captain(fullName);
            captains.Add(capt);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            foreach (var item in repo.Models)
            {
                if (item.Name == name)
                {
                    return $"{vesselType} vessel {name} is already manufactured.";
                }
            }
            bool valid = false;
            if (vesselType == "Submarine" || vesselType == "Battleship")
            {
                valid = true;
            }
            if (!valid)
            {
                return "Invalid vessel type.";
            }
            Vessel vessel = null;
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
                vessel = new Battleship(name, mainWeaponCaliber, speed);

            repo.Add(vessel);
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            foreach (var item in repo.Models)
            {
                if (item.Name == vesselName)
                {
                    item.RepairVessel();
                    return $"Vessel {vesselName} was repaired.";
                }
            }
            return $"Vessel {vesselName} could not be found.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            Battleship battleship = null;
            Submarine submarine = null;
            foreach (var item in repo.Models)
            {
                if (item.Name == vesselName)
                {
                    if (item.GetType().Name == "Battleship")
                    {
                        battleship = (Battleship)item;
                    }
                    else if (item.GetType().Name == "Submarine")
                    {
                        submarine = (Submarine)item;
                    }
                    break;
                }
            }
            if (battleship == null && submarine == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            if (battleship != null)
            {
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else 
            {
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string VesselReport(string vesselName)
        {
            string returner = "";
            foreach (var item in repo.Models)
            {
                 if (item.Name == vesselName)
                {
                    returner = item.ToString();
                }
            }
            return returner;
        }
    }
}
