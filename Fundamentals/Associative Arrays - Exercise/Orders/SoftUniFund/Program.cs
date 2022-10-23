using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {

            // Dictionary<string, double> junk = new Dictionary<string, double>();
            string input1 = Console.ReadLine();
            List<Prod> prodList = new List<Prod>();

            while (input1 != "buy")
            {
                string[] token = input1.Split(' ');
                double price = double.Parse(token[1]);
                int quant = int.Parse(token[2]);

                Prod productStat = new Prod(token[0], price, quant);

                if (prodList.Count > 0)
                {
                    bool check = false;
                    foreach (var item in prodList)
                    {
                        if (item.Name == token[0])
                        {
                            check = true;
                            item.Price = price;
                            item.Quantity += quant;
                        }
                    }
                    if (!check)
                    {
                        prodList.Add(productStat);
                    }
                }
                else
                    prodList.Add(productStat);

                input1 = Console.ReadLine();
            }
            foreach (var item in prodList)
            {
                Console.WriteLine($"{item.Name} -> {item.Price * item.Quantity:f2}");
            }
        }
    }
}
class Prod
{
    public Prod(string name, double price, int quant)
    {
        Name = name;
        Price = price;
        Quantity = quant;
    }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}