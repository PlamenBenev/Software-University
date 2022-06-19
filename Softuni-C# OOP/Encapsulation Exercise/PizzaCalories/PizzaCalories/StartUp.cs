using System;

namespace PizzaCalories
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "END")
            {
                try
                {
                    Dough dough = new Dough(input[1], input[2], double.Parse(input[3]));
                    Pizza pizza = new Pizza("Dough", dough);
                    Console.WriteLine(pizza.Dough.CaloriesPerGram);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine().Split(' ');
            }
        }
    }
}
