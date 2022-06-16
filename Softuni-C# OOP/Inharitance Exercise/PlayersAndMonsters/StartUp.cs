using System;
namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            DarkKnight darkKnight = new DarkKnight("Gosho",14);
            Console.WriteLine(darkKnight);
        }
    }
}