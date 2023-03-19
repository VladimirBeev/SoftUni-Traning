using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(string id,string firstname, string lastname,decimal salary,string corps)
            : base(id,firstname,lastname,salary)
        {
            this.Corps = corps;
        }
        public string Corps 
        { 
            get
            {
                return this.corps;
            }
            set
            {
                if (value == "Airforces")
                {
                    this.corps = value;
                }
                else if (value == "Marines")
                {
                    this.corps = value;
                }
            }
        }
    }
}
