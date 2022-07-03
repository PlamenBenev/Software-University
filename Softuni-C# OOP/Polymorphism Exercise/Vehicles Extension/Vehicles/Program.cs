using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            string[] truckInfo = Console.ReadLine().Split(' ');
            string[] busInfo = Console.ReadLine().Split(' ');

            double carfuel = double.Parse(carInfo[1]);
            double carconsumption = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);

            double truckfuel = double.Parse(truckInfo[1]);
            double truckconsumption = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);

            double busfuel = double.Parse(busInfo[1]);
            double busconsumption = double.Parse(busInfo[2]);
            double busCapacity = double.Parse(busInfo[3]);

            Vehicle car = new Car(carfuel, carconsumption, carCapacity);
            Vehicle truck = new Truck(truckfuel, truckconsumption, truckCapacity);
            Vehicle bus = new Bus(busfuel, busconsumption, busCapacity);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                double amount = double.Parse(input[2]);

                if (input[0] == "Drive")
                {
                    if (input[1] == "Car")
                    {
                        car.Drive(amount);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Drive(amount);
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Drive(amount);
                    }
                }
                else if (input[0] == "Refuel")
                {
                    if (input[1] == "Car")
                    {
                        car.Refueling(amount);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Refueling(amount);
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Refueling(amount);
                    }
                }
                else if (input[0] == "DriveEmpty" && input[1] == "Bus")
                {
                    bus.Consumption -= 1.4;
                    bus.Drive(amount);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
