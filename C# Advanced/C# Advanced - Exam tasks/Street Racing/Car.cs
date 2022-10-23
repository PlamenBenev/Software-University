using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public Car(string make, string model, string license, int hp, int weight)
        {
            Make = make;
            Model = model;
            LicensePlate = license;
            HorsePower = hp;
            Weight = weight;
        }
        public override string ToString()
        {
            string returner = $"Make: {Make}{Environment.NewLine}" +
                $"Model: {Model}{Environment.NewLine}" +
                $"License Plate: {LicensePlate}{Environment.NewLine}" +
                $"Horse Power: {HorsePower}{Environment.NewLine}" +
                $"Weight: {Weight}";

            return returner;
        }
    }
}
