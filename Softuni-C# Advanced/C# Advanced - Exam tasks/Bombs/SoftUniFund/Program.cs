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
            int[] bombEffect = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] bombCasing = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int daturaBomb = 0;
            int cherryBomb = 0;
            int smokeDecoyBomb = 0;

            Queue<int> effect = new Queue<int>();
            Stack<int> casing = new Stack<int>();

            foreach (var item in bombEffect)
            {
                effect.Enqueue(item);
            }
            foreach (var item in bombCasing)
            {
                casing.Push(item);
            }

            while (true)
            {
                if (effect.Peek() + casing.Peek() == 40)
                {
                    daturaBomb++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (effect.Peek() + casing.Peek() == 60)
                {
                    cherryBomb++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (effect.Peek() + casing.Peek() == 120)
                {
                    smokeDecoyBomb++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else
                {
                    int newValue = casing.Pop() - 5;
                    casing.Push(newValue);
                }
                
                if (effect.Count == 0 || casing.Count == 0)
                {
                    break;
                }
                if (daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoyBomb >= 3)
                {
                    break;
                }
            }

            if (daturaBomb >= 3 && cherryBomb >= 3 & smokeDecoyBomb >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effect)}");
            }

            if (casing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
            }
            
             Console.WriteLine($"Cherry Bombs: {cherryBomb}");
          
             Console.WriteLine($"Datura Bombs: {daturaBomb}");

             Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBomb}");
            
        }
    }
}