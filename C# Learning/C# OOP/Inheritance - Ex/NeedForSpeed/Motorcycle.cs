using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower,double fuel)
            : base(horsePower, fuel)
        {
            
        }
        public override double FuelConsumption()
        {
            return base.FuelConsumption();
        }
        public override void Drive(double kilometers)
        {
            var consumption = FuelConsumption() * (kilometers / 100);
            this.Fuel -= consumption;
        }
    }
}
