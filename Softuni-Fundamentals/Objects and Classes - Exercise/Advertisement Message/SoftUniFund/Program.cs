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
            Random rand = new Random();

            List<string> phrasesList = new List<string>() { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.",
                "I can’t live without this product." };

            List<string> eventsList = new List<string>() { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            List<string> authorsList = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cityList = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int randomPhrase = rand.Next(phrasesList.Count);
                int randomEvents = rand.Next(eventsList.Count);
                int randomAuthors = rand.Next(authorsList.Count);
                int randomCity = rand.Next(cityList.Count);

                Console.WriteLine($"{phrasesList[randomPhrase]} {eventsList[randomEvents]} {authorsList[randomAuthors]} – {cityList[randomCity]}.");
            }

        }
    }

}