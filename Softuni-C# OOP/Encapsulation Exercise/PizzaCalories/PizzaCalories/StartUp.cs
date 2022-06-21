using System;

namespace PizzaCalories
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;

            string pizzaName = "Pizza";
            Dough dough = null;
            Topping topping = null;
            pizza = new Pizza(pizzaName, dough);

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "END")
            {
                if (input[0] == "Pizza")
                {
                    try
                    {
                        pizza.Name = input[1];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else if (input[0] == "Dough")
                {
                    try
                    {
                        dough = new Dough(input[1], input[2], double.Parse(input[3]));
                        pizza.Dough = dough;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else if (input[0] == "Topping")
                {
                    try
                    {
                        topping = new Topping(input[1], double.Parse(input[2]));
                        pizza.Add(topping);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }

                input = Console.ReadLine().Split(' ');
            }
            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
        }
    }
}
