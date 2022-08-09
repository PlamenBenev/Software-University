using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        private CarRepository cars = new CarRepository();
        private RacerRepository racer = new RacerRepository();
        private IMap map = new Map();
        public Controller()
        {

        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type == "SuperCar")
            {
                cars.Add(new SuperCar(make, model, VIN, horsePower));
                return $"Successfully added car {make} {model} ({VIN}).";
            }
            if (type == "TunedCar")
            {
                cars.Add(new TunedCar(make, model, VIN, horsePower));
                return $"Successfully added car {make} {model} ({VIN}).";
            }
            throw new ArgumentException("Invalid car type!");
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = null;
            foreach (var item in cars.Models)
            {
                if (item.VIN == carVIN)
                {
                    car = item;
                }
            }
            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            if (type == "ProfessionalRacer")
            {
                racer.Add(new ProfessionalRacer(username,car));
                return $"Successfully added racer {username}.";
            }
            if (type == "StreetRacer")
            {
                racer.Add(new StreetRacer(username, car));
                return $"Successfully added racer {username}.";
            }
            throw new ArgumentException("Invalid racer type!"); 
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = null;
            IRacer racerTwo = null;
            foreach (var item in racer.Models)
            {
                if (item.Username == racerOneUsername)
                {
                    racerOne = item;
                }
                else if (item.Username == racerTwoUsername)
                {
                    racerTwo = item;
                }
            }
            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var ordered = racer.Models.OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username);

            string returner = "";
            foreach (var item in ordered)
            {
                returner += $"{item.GetType().Name}: {item.Username}{Environment.NewLine}" +
                    $"--Driving behavior: {item.RacingBehavior}{Environment.NewLine}" +
                    $"--Driving experience: {item.DrivingExperience}{Environment.NewLine}" +
                    $"--Car: {item.Car.Make} {item.Car.Model} ({item.Car.VIN}){Environment.NewLine}";
            }
            return returner;
        }
    }
}
