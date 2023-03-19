using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Dictionary<string ,Car> Participants { get; set; }
        public string Name { get ; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new Dictionary<string, Car>();
        }
        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (!this.Participants.ContainsKey(car.LicensePlate))
            {
                if (this.Capacity>0)
                {
                    if (this.MaxHorsePower >= car.HorsePower)
                    {
                        this.Participants[car.LicensePlate] = car;
                    }
                    
                }
                
            }
        }
        public bool Remove(string licensePlate)
        {
            if (this.Participants.ContainsKey(licensePlate))
            {
                this.Participants.Remove(licensePlate);
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            if (this.Participants.ContainsKey(licensePlate))
            {
                return this.Participants[licensePlate];
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            Car cars = null;
            if (Count > 0)
            {
                int maxHorsePower = 0;

                foreach (Car item in this.Participants.Values)
                {
                    if (item.HorsePower > maxHorsePower)
                    {
                        maxHorsePower = item.HorsePower;
                        cars = item;
                    }
                }
            }
            if (cars != null)
            {
                return cars;
            }
            else
                return null;
        }
        public string Report()
        {
            return $"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})\n"+
                   $"{string.Join("\n",Participants.Values)}";
        }
    }
}
