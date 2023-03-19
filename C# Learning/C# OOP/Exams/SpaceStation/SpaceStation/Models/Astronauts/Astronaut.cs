using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;
        private bool canBreath;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
            this.CanBreath = true;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidAstronautName));
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get =>this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidOxygen));
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath
        {
            get => this.canBreath;
            private set
            {
                if (this.Oxygen <= 0)
                {
                    this.canBreath = false;
                }
                else
                    this.canBreath = true;
            }
        }

        public IBag Bag
        {
            get => this.bag;
            private set
            {
                this.bag = value;
            }
        }
        public virtual void Breath()
        {
            if (this.Oxygen <= 0)
            {
                this.CanBreath = false;
            }
        }
    }
}
