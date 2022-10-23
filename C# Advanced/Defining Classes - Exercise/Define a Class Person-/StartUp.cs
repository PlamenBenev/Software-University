using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("gosho",5);
            Person person2 = new Person("pesho", 5);

            Console.WriteLine(person.Name);
            Console.WriteLine(person2.Name);
        }
    }
}
