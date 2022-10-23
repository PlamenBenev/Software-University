using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Ferrari : FormulaOneCar
    {
        public Ferrari(string carModel, int horsePower, double displacement) : base(carModel, horsePower, displacement)
        {
        }
    }
}
