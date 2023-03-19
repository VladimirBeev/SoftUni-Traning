using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitOxygen = 70;
        public Biologist(string name)
            : base(name, InitOxygen)
        {
        }
        public override void Breath()
        {
            var oxy = this.Oxygen - 5;
            if (oxy > 0)
            {
                this.Oxygen -= 5;
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
