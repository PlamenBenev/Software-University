using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int hp;
        private double engineDisplacement;

        public FormulaOneCar(string carModel,int horsePower,double displacement)
        {
            Model = carModel;
            Horsepower = horsePower;
            EngineDisplacement = displacement;
        }
        public string Model
        {
            get { return model; }
            private set
            {
                model = value;
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid car model: { model }.");
                }
            }
        }

        public int Horsepower
        {
            get { return hp; }
            private set
            {
                hp = value;
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: { hp }.");
                }
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set
            {
                engineDisplacement = value;
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException($"Invalid car engine displacement: {engineDisplacement}.");
                }
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return engineDisplacement / Horsepower * laps;
        }
    }
}
