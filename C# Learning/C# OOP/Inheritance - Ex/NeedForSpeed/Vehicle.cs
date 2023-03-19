using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption()
        {
            return DefaultFuelConsumption;
        }
        private int horsePower;
        private double fuel;

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public virtual void Drive(double kilometers)
        {
            var consumption = FuelConsumption()*(kilometers/100);
            this.Fuel -= consumption;
        }
    }
}
