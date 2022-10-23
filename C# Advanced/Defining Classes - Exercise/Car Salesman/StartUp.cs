using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineNum = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineNum; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = null;

                if (input.Length == 2)
                {
                    engine = new Engine(input[0], int.Parse(input[1]));
                }
                else if (input.Length == 3)
                {
                    if (char.IsLetter(input[2][0]))
                    {
                        engine = new Engine(input[0], int.Parse(input[1]), 0, input[2]);
                    }
                    else
                        engine = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]));
                }
                else if (input.Length == 4)
                {
                    engine = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]);
                }
                engines.Add(engine);
            }

            int carNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < carNum; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = null;
                Engine engine = null;

                foreach (var item in engines)
                {
                    if (input[1] == item.Model)
                    {
                        engine = item;
                    }
                }

                if (input.Length == 2)
                {
                    car = new Car(input[0], engine);
                }
                else if (input.Length == 3)
                {
                    if (char.IsLetter(input[2][0]))
                    {
                        car = new Car(input[0], engine, 0, input[2]);
                    }
                    else
                        car = new Car(input[0], engine, int.Parse(input[2]));
                }
                else if (input.Length == 4)
                {
                    car = new Car(input[0], engine, int.Parse(input[2]), input[3]);
                }

                cars.Add(car);
            }
            foreach (var item in cars)
            {
                Console.WriteLine(item.Model + ":");
                Console.WriteLine($"  {item.Engine.Model}:");
                Console.WriteLine($"    Power: {item.Engine.Power}");
                if (item.Engine.Displacement == 0)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {item.Engine.Displacement}");
                }
                if (item.Engine.Efficiency == null)
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {item.Engine.Efficiency}");
                }
                if (item.Weight == 0)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {item.Weight}");
                }
                if (item.Color == null)
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                    Console.WriteLine($"  Color: {item.Color}");
            }
        }
    }
}
