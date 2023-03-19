using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CarIncrement = 0.9;
        public Car(double fuel, double liters,double tankCapacity)
            : base(fuel, liters,tankCapacity)
        {
        }
        protected override double FuelConsumptionModifier => base.FuelConsumptionModifier+CarIncrement;
    }
}
