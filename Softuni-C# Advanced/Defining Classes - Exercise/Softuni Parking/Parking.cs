using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public List<Car> Cars
        {
            get { return cars; }
            set { this.cars = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { this.capacity = value; }
        }
        public int Count
        {
            get { return cars.Count; }
            
        }

        private List<Car> cars = new List<Car>();
        private int capacity;
        public Parking(int capp)
        {
            Cars = new List<Car>();
            Capacity = capp;
        }
        public Parking(List<Car> cars, int capacity) : this(capacity)
        {
            this.Cars = new List<Car>();
            this.Cars = cars;
        }

        public string AddCar(Car Car)
        {
            bool itsFine = true;

            foreach (var item in cars)
            {
                if (item.RegistrationNumber == Car.RegistrationNumber)
                {
                    itsFine = false;
                    break;
                }
            }
            if (itsFine && cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            if (itsFine)
            {
                cars.Add(Car);
                return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
            }
            else
                return "Car with that registration number, already exists!";

        }

        public string RemoveCar(string RegistrationNumber)
        {
            bool doesItExist = false;
            foreach (var item in cars)
            {
                if (item.RegistrationNumber == RegistrationNumber)
                {
                    cars.Remove(item);
                    doesItExist = true;
                    break;
                }
            }
            if (!doesItExist)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
                return $"Successfully removed {RegistrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            Car ccar = new Car("", "", 0, "");
            foreach (var item in cars)
            {
                if (item.RegistrationNumber == registrationNumber)
                {
                    ccar = item;
                    break;
                }
            }
            return ccar;
        }

        public int RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                if (RegistrationNumbers.Contains(this.Cars[i].RegistrationNumber))
                {
                    this.Cars.RemoveAt(i);
                    i--;
                }
            }
            return cars.Count;
        }
    }
}
