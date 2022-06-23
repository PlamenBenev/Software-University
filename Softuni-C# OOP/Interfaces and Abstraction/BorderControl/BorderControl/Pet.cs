using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public class Pet : IBirthdays
    {
        public string Birthdays { get; set; }
        public string Name { get; set; }
        public Pet(string name, string birthday)
        {
            Birthdays = birthday;
            Name = name;
        }
    }
}
