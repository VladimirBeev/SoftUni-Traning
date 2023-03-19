using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Intrefaces;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle , IDriveEmpty
    {
        private double fuelQuantity;
        private double litersPerKm;
        private double tankCapacity;


        protected Vehicle(double fuel, double liters, double tankCapacity)
        {
            this.FuelQuantity = fuel;
            this.LitersPerKm = liters;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }
        public double LitersPerKm
        {
            get
            {
                return this.litersPerKm;
            }
            protected set
            {
                this.litersPerKm = value + FuelConsumptionModifier;
            }
        }
        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                this.tankCapacity = value;
                if (this.tankCapacity >= this.FuelQuantity)
                {
                    this.tankCapacity = value - this.FuelQuantity;
                }
                else
                {
                    this.FuelQuantity = 0;
                    this.tankCapacity = value;
                }
            }
        }
        protected virtual double FuelConsumptionModifier { get; }

        public string Drive(double km)
        {
            var fuelCons = this.LitersPerKm * km;
            if (fuelCons <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelCons;
                return $"{this.GetType().Name} travelled {km} km";
            }
            else
                return $"{this.GetType().Name} needs refueling";
        }

        public string DriveEmpty(double km)
        {
            var fuelCons = (this.LitersPerKm - 1.4) * km;
            if (fuelCons <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelCons;
                return $"{this.GetType().Name} travelled {km} km";
            }
            else
                return $"{this.GetType().Name} needs refueling";
        }
        public virtual void Refuel(double liters)
        {
            if (!double.IsNegative(liters) && liters != 0)
            {
                if (this.TankCapacity < liters)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                    
                }
                else
                {
                    this.TankCapacity -= liters;
                    this.FuelQuantity += liters;
                }
            }
            else
                Console.WriteLine("Fuel must be a positive number");
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
