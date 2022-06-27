using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {
        public int Add(int s, int d)
        {
            return s + d;
        }
        public double Add(double s , double d , double f)
        {
            return s + d + f;
        }
        public decimal Add(decimal s , decimal d , decimal f)
        {
            return s + d + f;
        }
    }
}
