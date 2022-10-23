using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public class Citizens : IId, IBirthdays, IBuyer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdays { get; set; }
        public int Food { get; set; }

        public Citizens(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdays = birthday;
        }
        public void BuyFood()
        {
            Food += 10;
        }
    }
}
