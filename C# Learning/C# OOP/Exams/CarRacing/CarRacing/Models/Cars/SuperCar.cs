using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double FuelAvailable = 80;
        private const double FuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, FuelAvailable, FuelConsumptionPerRace)
        {
        }
        public override void Drive()
        {
            base.Drive();
        }
    }
}
