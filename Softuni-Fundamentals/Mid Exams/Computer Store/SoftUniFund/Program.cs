using System;
using System.Globalization;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            bool itsDouble = false;

            while (!itsDouble)
            {
                if (input == "special" || input == "regular")
                {
                    if (sum > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid order!");
                        return;

                    }
                }

                double price = double.Parse(input);
                if (price > 0)
                {
                    sum += price;
                }
                else
                {
                    Console.Write("Invalid price!");
                    Console.WriteLine();
                }
                input = Console.ReadLine();

            }
            double taxes = sum * 0.20;

            double discountSum = sum + taxes;
            if (input == "special")
            {

                discountSum -= discountSum * 0.1;
            }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sum:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {discountSum:f2}$");
        }
    }
}