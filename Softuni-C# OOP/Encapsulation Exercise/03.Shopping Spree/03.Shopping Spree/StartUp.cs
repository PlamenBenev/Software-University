using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInput = Console.ReadLine().Split(';');
            string[] foodInput = Console.ReadLine().Split(';');

            List<Person> people = new List<Person>();
            List<Product> prods = new List<Product>();

            foreach (string person in personInput)
            {
                string name = "";
                double price = 0;

                if (!string.IsNullOrWhiteSpace(person))
                {
                    string[] personInfo = person.Split('=');
                    name = personInfo[0];
                    price = double.Parse(personInfo[1]);
                }

                try
                {
                    Person dude = new Person(name, price);
                    people.Add(dude);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            foreach (var item in foodInput)
            {
                string name = "";
                double cost = 0;

                if (!string.IsNullOrWhiteSpace(item))
                {
                    string[] personInfo = item.Split('=');
                    name = personInfo[0];
                    cost = double.Parse(personInfo[1]);
                }
                try
                {
                    Product prod = new Product(name, cost);
                    prods.Add(prod);
                }
                catch
                {
                    return;
                }
            }

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "END")
            {
                foreach (var item in people)
                {
                    if (item.Name == input[0])
                    {
                        foreach (var prod in prods)
                        {
                            if (prod.Name == input[1])
                            {
                                if (prod.Cost <= item.Money)
                                {
                                    item.Products.Add(prod);

                                    Console.WriteLine($"{item.Name} bought {prod.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"{item.Name} can't afford {prod.Name}");
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine().Split(' ');
            }
            foreach (var item in people)
            {
                if (item.Products.Count > 0)
                {
                    Console.Write($"{item.Name} - ");
                    for (int i = 0; i < item.Products.Count; i++)
                    {
                        Console.Write($"{item.Products[i].Name}");
                        if (i < item.Products.Count - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{item.Name} - Nothing bought");
                }
            }
        }
    }
}
