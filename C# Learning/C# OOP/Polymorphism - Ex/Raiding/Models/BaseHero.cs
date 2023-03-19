using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        private string name;
        private int power;

        protected BaseHero(string name,int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public  int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                this.power = value;
            }
        }

        public abstract string CastAbility();
    }
}
