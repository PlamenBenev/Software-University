using System;
using System.Globalization;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            int counter = 0;

            char[] stringArray = username.ToCharArray();

            string reverse = String.Empty;

            for (int i = stringArray.Length - 1; i >= 0; i--)
            {
                reverse += stringArray[i];
            }


            while (password != reverse)
            {
                if (counter != 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    counter++;
                }
                else
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                password = Console.ReadLine();
            }
            if (password == reverse)
            {
                Console.WriteLine($"User {username} logged in.");

            }

        }
    }
}