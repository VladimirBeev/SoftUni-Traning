using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public string Make { get; set; }
        public string  Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }
        public override string ToString()
        {
            return $"Make: {this.Make}\n"+
                    $"Model: {this.Model}\n" +
                    $"License Plate: {this.LicensePlate}\n" +
                    $"Horse Power: {this.HorsePower}\n" +
                    $"Weight: {this.Weight}";
        }
    }

}
