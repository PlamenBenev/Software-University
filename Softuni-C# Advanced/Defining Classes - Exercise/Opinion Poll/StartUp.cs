using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(input[0], int.Parse(input[1]));

                if (person.Age > 30)
                {
                    persons.Add(person);
                }
            }

            persons = persons.OrderBy(x => x.Name).ToList();

            foreach (var item in persons)
            {
                Console.WriteLine(item.Name + " - " + item.Age);
            }
        }
    }
}
