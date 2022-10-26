﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, 65, 7.5)
        {
        }
        public override void Drive()
        {
            base.Drive();
            double calc = HorsePower - HorsePower * 0.03;
            this.HorsePower -= (int)calc;
        }
    }
}