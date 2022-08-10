﻿using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int _power;
        public Dye(int power)
        {
            Power = power;
        }
        public int Power
        {
            get { return _power; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _power = value;
            }
        }

        public bool IsFinished()
        {
            if (this.Power == 0)
                return true;
            return false;
        }

        public void Use()
        {
            this.Power -= 10;
            if (this.Power < 0)
            { this.Power = 0; }
        }
    }
}
