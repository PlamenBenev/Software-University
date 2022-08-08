using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"Race cannot be completed because both racers are not available!";
            }
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            racerOne.Race();
            racerTwo.Race();

            double racingBehaviorMultiplier = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }
            double oneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplier;

            if (racerTwo.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }
            double TwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplier;

            string winner = "";
            if (oneChance > TwoChance)
            {
                winner = racerOne.Username;
            }
            else
                winner = racerTwo.Username;

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner} is the winner!";
        }
    }
}
