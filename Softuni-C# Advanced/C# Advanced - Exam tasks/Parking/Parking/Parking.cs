using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Car> Cars {  get; set; } = new List<Car>();
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
        }

        public void Add(Car car)
        {
            if (Capacity > Cars.Count)
            {
                Cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            foreach (var item in Cars)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    Cars.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Car GetLatestCar()
        {
            Car car = null;
            int latest = 0;
            foreach (var item in Cars)
            {
                if (item.Year > latest)
                {
                    car = item;
                    latest = item.Year;
                }
            }
            return car;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = null;
            foreach (var item in Cars)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    car = item;
                }
            }
            return car;
        }
        public int Count
        {
            get { return Cars.Count; }
        }
        public string GetStatistics()
        {
            return $"The cars are parked in {Type}:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, Cars)}";
        }
    }
}
