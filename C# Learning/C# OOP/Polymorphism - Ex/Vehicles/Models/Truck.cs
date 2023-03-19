using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckInckrement = 1.6;
        private const double RefuelCoeffiecient = 0.95;
        public Truck(double fuel, double liters,double tankCapacity)
            : base(fuel, liters,tankCapacity)
        {
        }
        protected override double FuelConsumptionModifier => base.FuelConsumptionModifier+TruckInckrement;

        public override void Refuel(double liters)
        {
            if (base.TankCapacity > liters)
            {
                base.Refuel(liters * RefuelCoeffiecient);
            }
            else
                base.Refuel(liters);
        }
    }
}
