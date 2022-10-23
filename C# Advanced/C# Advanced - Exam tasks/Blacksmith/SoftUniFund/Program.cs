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
            int[] inputSteel = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] inputCarbon = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> steel = new Queue<int>();
            Stack<int> carbon = new Stack<int>();

            SortedDictionary<string, int> swords = new SortedDictionary<string, int>();

            int gladius = 0;
            int shamshir = 0;
            int katana = 0;
            int sabre = 0;
            int broadSword = 0;

            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);

            foreach (var item in inputSteel)
            {
                steel.Enqueue(item);
            }
            foreach (var item in inputCarbon)
            {
                carbon.Push(item);
            }

            while (steel.Count > 0)
            {
                if (steel.Peek() + carbon.Peek() == 70)
                {
                    gladius++;
                    swords["Gladius"]++;
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 80)
                {
                    shamshir++;
                    swords["Shamshir"]++;
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 90)
                {
                    katana++;
                    swords["Katana"]++;
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 110)
                {
                    sabre++;
                    swords["Sabre"]++;
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 150)
                {
                    broadSword++;
                    swords["Broadsword"]++;
                    carbon.Pop();
                }
                else
                {
                    int newValue = carbon.Pop() + 5;
                    carbon.Push(newValue);
                }

                steel.Dequeue();
                if (carbon.Count == 0)
                {
                    break;
                }
            }
            int totalForged = gladius + shamshir + katana + sabre + broadSword;
            if (totalForged > 0)
            {
                Console.WriteLine($"You have forged {totalForged} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }
            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            foreach (var item in swords)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}