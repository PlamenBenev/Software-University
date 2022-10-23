using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar carProp;
        private int numOfWins;

        public Pilot(string name)
        {
            FullName = name;
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                fullName = value;
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid pilot name: { fullName }.");
                }
            }
        }
        public IFormulaOneCar Car
        {
            get { return carProp; }
            private set
            {
                carProp = value;
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
            }
        }
        public int NumberOfWins
        {
            get { return numOfWins; }
            private set
            {
                numOfWins = value;
            }
        }
        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }
        public void AddCar(IFormulaOneCar car)
        {
            carProp = car;
            canRace = true;
        }
        public void WinRace()
        {
            numOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
