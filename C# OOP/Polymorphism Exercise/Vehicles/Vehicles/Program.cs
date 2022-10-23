using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            string[] truckInfo = Console.ReadLine().Split(' ');
            double carfuel = double.Parse(carInfo[1]);
            double carconsumption = double.Parse(carInfo[2]);
            double truckfuel = double.Parse(truckInfo[1]);
            double truckconsumption = double.Parse(truckInfo[2]);

            Vehicle car = new Car(carfuel, carconsumption);
            Vehicle truck = new Truck(truckfuel,truckconsumption);

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
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
