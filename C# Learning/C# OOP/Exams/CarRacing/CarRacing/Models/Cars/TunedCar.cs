using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double FuelAvailable = 65;
        private const double FuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, FuelAvailable, FuelConsumptionPerRace)
        {
        }
        public override void Drive()
        {
            base.Drive();
            int engineWear = (int)(this.HorsePower * 0.03);
            this.HorsePower -= engineWear;
        }
    }
}
