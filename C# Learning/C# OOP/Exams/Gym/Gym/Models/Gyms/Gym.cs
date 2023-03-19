using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private double equipmentWeight;
        private ICollection<IEquipment> equipmentCollection;
        private ICollection<IAthlete> athleteCollection;

        protected Gym(string name, int capacity)
        {
            this.equipmentCollection = new List<IEquipment>();
            this.athleteCollection = new List<IAthlete>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidGymName));
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public double EquipmentWeight => this.equipmentWeight;// = this.equipmentCollection.Sum(e=>e.Weight);
        

        public ICollection<IEquipment> Equipment => this.equipmentCollection;

        public ICollection<IAthlete> Athletes => this.athleteCollection;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == this.Athletes.Count)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughSize));
            }
            this.athleteCollection.Add(athlete);
            //this.Capacity--;
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipmentCollection.Add(equipment);
        }

        public void Exercise()
        {
            foreach(var athlete in this.athleteCollection)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            string[] names = new string[this.athleteCollection.Count];
            for (int i = 0; i < this.athleteCollection.Count; i++)
            {
                foreach (var item in this.Athletes)
                {
                    names[i] = item.FullName;
                }
            }
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {(this.athleteCollection.Count == 0? "No athletes":string.Join(", ",names))}");
            sb.AppendLine($"Equipment total count: {this.equipmentCollection.Count}");
            sb.Append($"Equipment total weight: {this.EquipmentWeight} grams");
            return sb.ToString();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athleteCollection.Remove(athlete);
        }
    }
}
