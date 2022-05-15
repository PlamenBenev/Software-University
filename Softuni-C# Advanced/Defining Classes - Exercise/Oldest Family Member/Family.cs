using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Members { get; set; }

        public Family()
        {
            Members = new List<Person>();
        }
        public void AddMember(Person person)
        {
            Members.Add(person);
        }
        public Person OldestPerson()
        {
            Person person = Members
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
                return person;
        }
    }
}
