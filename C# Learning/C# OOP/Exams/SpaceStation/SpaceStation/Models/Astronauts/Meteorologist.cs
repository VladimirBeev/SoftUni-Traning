using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double InitOxygen = 90;
        public Meteorologist(string name)
            : base(name, InitOxygen)
        {
        }
        public override void Breath()
        {
            var oxy = this.Oxygen - 10;
            if (oxy > 0)
            {
                this.Oxygen -= 10;
                base.Breath();
            }
            else
            {
                this.Oxygen = 0;
                base.Breath();
            }
                
        }
    }
}
