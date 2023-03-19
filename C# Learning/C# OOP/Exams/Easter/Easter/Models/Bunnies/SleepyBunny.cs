using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {

        private const int InitEnergy = 50;
        public SleepyBunny(string name) 
            : base(name, InitEnergy)
        {
        }

        public override void Work()
        {
            var workenegy = this.Energy - 15;
            if (workenegy < 0)
            {
                this.Energy = 0;
            }
            else
                this.Energy -= 15;
        }
    }
}
