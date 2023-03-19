using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Intrefaces;
namespace Vehicles.Models
{
    public class Bus : Vehicle 
    {
        private const double BusIncrementModifaier = 1.4;
        public Bus(double fuel, double liters,double tankCapacity) 
            : base(fuel, liters,tankCapacity)
        {
        }
        protected override double FuelConsumptionModifier => base.FuelConsumptionModifier+BusIncrementModifaier;
    }
}
