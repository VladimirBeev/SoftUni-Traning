using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessel;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private List<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }

        public int CombatExperience
        {
            get => this.combatExperience;
            private set
            {
                this.combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            foreach (IVessel ve in this.Vessels)
            {
                if (ve.Targets.Count > 0)
                {
                    this.CombatExperience += 10;
                }
                if (ve is Battleship)
                {
                    if (ve.ArmorThickness < 300)
                    {
                        this.CombatExperience += 10;
                    }
                }
                if (ve is Submarine)
                {
                    if (ve.ArmorThickness < 200)
                    {
                        this.CombatExperience += 10;
                    }
                }
            }
        }

        public string Report()
        {
            return $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.";
        }
    }
}
