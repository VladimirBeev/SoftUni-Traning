using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int InitEnergy = 100;
        public HappyBunny(string name) 
            : base(name, InitEnergy)
        {
        }

        public override void Work()
        {
            var energy = this.Energy - 10;
            if (energy < 0)
            {
                this.Energy = 0;
            }
            else
                this.Energy -= 10;
        }
    }
}
