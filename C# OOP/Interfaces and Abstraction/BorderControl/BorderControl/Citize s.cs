using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : IId
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Citizens(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
    }
}
