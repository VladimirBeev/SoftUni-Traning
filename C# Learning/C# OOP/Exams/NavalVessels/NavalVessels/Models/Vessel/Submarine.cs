using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessel
{
    public class Submarine : Vessel, ISubmarine
    {
        private const int InitialArmorThickness = 200;
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SubmergeMode
        {
            get => this.submergeMode;
            private set => this.submergeMode = value;
        }
        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else if (this.SubmergeMode == true)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"*Submerge Mode: {(this.SubmergeMode == true ? "ON" : "OFF")}");
            return sb.ToString();
        }
    }
}
