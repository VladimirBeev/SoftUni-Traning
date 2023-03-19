using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessel
{
    public class Battleship : Vessel, IBattleship
    {
        private const int InitialArmorThickness = 300;
        private bool sonarMode = false;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SonarMode
        {
            get => this.sonarMode;
            private set => this.sonarMode = value;
            
        }
        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else if (this.SonarMode == true)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
            
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"*Sonar mode: {(this.SonarMode == true? "ON":"OFF")}");
            return sb.ToString();
        }
    }
}
