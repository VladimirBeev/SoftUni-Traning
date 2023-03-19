using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get;}
        public double LitersPerKm { get;}
        public double TankCapacity { get;}

        //string DriveEmpty(double km);

        string Drive(double km);

        void Refuel(double liters);
    }
}
