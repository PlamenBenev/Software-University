using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "End")
            {
                string[] foodInput = Console.ReadLine().Split(' ');
                if (input[0] == "Cat")
                {
                    Animal cat = new Cat(input[1], double.Parse(input[2]), input[3], input[4]);
                    Food food = null;
                    Console.WriteLine("Meow");

                    if (foodInput[0] == "Meat")
                    {
                        food = new Meat(int.Parse(foodInput[1]));
                        cat.Food = food;
                    }
                    else if (foodInput[0] == "Vegetable")
                    {
                        food = new Vegetable(int.Parse(foodInput[1]));
                        cat.Food = food;
                    }
                    else
                    {
                        Console.WriteLine($"Cat does not eat {foodInput[0]}!");
                    }
                    cat.ToString();
                    animals.Add(cat);
                }
                else if (input[0] == "Tiger")
                {
                    Animal tiger = new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);
                    Food food = null;
                    Console.WriteLine("ROAR!!!");

                    if (foodInput[0] == "Meat")
                    {
                        food = new Meat(int.Parse(foodInput[1]));
                        tiger.Food = food;
                    }
                    else
                    {
                        Console.WriteLine($"Tiger does not eat {foodInput[0]}!");
                    }
                    tiger.ToString();
                    animals.Add(tiger);
                }
                else if (input[0] == "Dog")
                {
                    Animal dog = new Dog(input[1], double.Parse(input[2]), input[3]);
                    Food food = null;
                    Console.WriteLine("Woof!");

                    if (foodInput[0] == "Meat")
                    {
                        food = new Meat(int.Parse(foodInput[1]));
                        dog.Food = food;
                    }
                    else
                    {
                        Console.WriteLine($"Dog does not eat {foodInput[0]}!");
                    }
                    dog.ToString();
                    animals.Add(dog);
                }
                else if (input[0] == "Mouse")
                {
                    Animal mouse = new Mouse(input[1], double.Parse(input[2]), input[3]);
                    Food food = null;
                    Console.WriteLine("Squeak");

                    if (foodInput[0] == "Vegetable")
                    {
                        food = new Vegetable(int.Parse(foodInput[1]));
                        mouse.Food = food;
                    }
                    else if (foodInput[0] == "Fruit")
                    {
                        food = new Fruit(int.Parse(foodInput[1]));
                        mouse.Food = food;
                    }
                    else
                    {
                        Console.WriteLine($"Mouse does not eat {foodInput[0]}!");
                    }
                    mouse.ToString();
                    animals.Add(mouse);
                }
                else if (input[0] == "Hen")
                {
                    Animal hen = new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));
                    Food food = new Vegetable(int.Parse(foodInput[1]));

                    Console.WriteLine("Cluck");
                    hen.Food = food;
                    hen.ToString();
                    animals.Add(hen);
                }
                else if (input[0] == "Owl")
                {
                    Animal owl = new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));
                    Food food = null;
                    Console.WriteLine("Hoot Hoot");

                    if (foodInput[0] == "Meat")
                    {
                        food = new Meat(int.Parse(foodInput[1]));
                        owl.Food = food;
                    }
                    else
                    {
                        Console.WriteLine($"Owl does not eat {foodInput[0]}!");
                    }
                    owl.ToString();
                    animals.Add(owl);
                }
                input = Console.ReadLine().Split(' ');
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
