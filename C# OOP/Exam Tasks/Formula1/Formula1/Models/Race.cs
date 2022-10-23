using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numOfLaps;
        private bool tookPlace = false;
        private List<IPilot> pilots = new List<IPilot>();

        public Race(string raceNam,int numberOfLaps)
        {
            RaceName = raceNam;
            NumberOfLaps = numberOfLaps;
        }
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                raceName = value;
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid race name: {raceName }.");
                }
            }
        }

        public int NumberOfLaps
        {
            get { return numOfLaps; }
            private set
            {
                numOfLaps = value;
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {numOfLaps}.");
                }
            }
        }

        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string yesNo = "No";
            if (tookPlace)
            {
                yesNo = "Yes";
            }

            string returner = $"The {RaceName} race has:{Environment.NewLine}" +
                $"Participants: {pilots.Count}{Environment.NewLine}" +
                $"Number of laps: {NumberOfLaps}{Environment.NewLine}" +
                $"Took place: {yesNo}";

            return returner;
        }
    }
}
