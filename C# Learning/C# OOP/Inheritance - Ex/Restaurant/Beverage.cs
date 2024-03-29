﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }
        private double _milliliters;
        public double Milliliters
        {
            get { return _milliliters; }
            set { _milliliters = value; }
        }
    }
}
