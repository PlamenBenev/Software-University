using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core.Contracts
{
    public class Controller : IController
    {
        private PilotRepository pilotRepo = new PilotRepository();
        private RaceRepository raceRepo = new RaceRepository();
        private FormulaOneCarRepository carRepo = new FormulaOneCarRepository();
        public Controller()
        {

        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = null;
            IFormulaOneCar car = null;
            foreach (var item in pilotRepo.Models)
            {
                if (item.FullName == pilotName && item.Car == null)
                {
                    pilot = item;
                }
            }
            if (pilot == null)
            {
                return $"Pilot {pilotName} does not exist or has a car.";
            }
            foreach (var item in carRepo.Models)
            {
                if (item.Model == carModel)
                {
                    car = item;
                }
            }
            if (car == null)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }

            foreach (var item in pilotRepo.Models)
            {
                if (item.FullName == pilotName)
                {
                    item.AddCar(car);
                }
            }
            foreach (var item in carRepo.Models)
            {
                if (item.Model == carModel)
                {
                    carRepo.Remove(item);
                    break;
                }
            }

            return $"Pilot {pilotName} will drive a {car.GetType().Name} { carModel } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = null;
            IPilot pilot = null;
            foreach (var item in raceRepo.Models)
            {
                if (item.RaceName == raceName)
                {
                    race = item;
                }
            }
            foreach (var item in pilotRepo.Models)
            {
                if (item.FullName == pilotFullName)
                {
                    pilot = item;
                }
            }
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (pilot == null || pilot.CanRace == false
                || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            foreach (var item in carRepo.Models)
            {
                if (item.Model == model)
                {
                    throw new InvalidOperationException($"Formula one car { model } is already created.");
                }
            }
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            if (type == "Ferrari")
            {
                carRepo.Add(new Ferrari(model, horsepower, engineDisplacement));
            }
            else
                carRepo.Add(new Williams(model, horsepower, engineDisplacement));

            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            foreach (var item in pilotRepo.Models)
            {
                if (fullName == item.FullName)
                {
                    throw new InvalidOperationException($"Pilot {fullName} is already created.");
                }
            }
            pilotRepo.Add(new Pilot(fullName));
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            foreach (var item in raceRepo.Models)
            {
                if (item.RaceName == raceName)
                {
                    throw new InvalidOperationException($"Race {raceName} is already created.");
                }
            }
            raceRepo.Add(new Race(raceName, numberOfLaps));
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            List<Pilot> pilots = new List<Pilot>();

            foreach (var item in pilotRepo.Models)
            {
                pilots.Add((Pilot)item);
            }
            var ordering = pilots.OrderByDescending(x => x.NumberOfWins).ToList();

            string returner = "";
            foreach (var item in ordering)
            {
                returner += item.ToString() + Environment.NewLine;
            }
            return returner;
        }

        public string RaceReport()
        {
            string returner = "";

            foreach (var item in raceRepo.Models)
            {
                if (item.TookPlace == true)
                    returner += item.RaceInfo() + Environment.NewLine;
            }
            return returner;
        }

        public string StartRace(string raceName)
        {
            IRace race = null;
            foreach (var item in raceRepo.Models)
            {
                if (raceName == item.RaceName)
                {
                    race = item;
                }
            }
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            List<Pilot> uriders = new List<Pilot>();
            foreach (var item in race.Pilots)
            {
                uriders.Add((Pilot)item);
            }

            var riders = uriders.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            string first = riders[0].FullName;
            string second = riders[1].FullName;
            string third = riders[2].FullName;

            riders[0].WinRace();
            race.TookPlace = true;

            return $"Pilot {first} wins the {raceName} race.{Environment.NewLine}" +
                $"Pilot {second} is second in the {raceName} race.{Environment.NewLine}" +
                $"Pilot {third} is third in the {raceName} race.";
        }
    }
}
