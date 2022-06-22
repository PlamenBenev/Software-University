using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robots : IId
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public Robots(string model, string id)
        {
            Id = id;
            Model = model;
        }
    }
}
