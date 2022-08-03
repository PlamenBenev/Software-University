﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{
    public class Weightlifter : Athlete
    {
        private const int stamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, stamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
        }
    }
}
