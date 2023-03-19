using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        private int number;
        public StationaryPhone(int number)
        {
            this.Number = number;
        }
        public int Number 
        { 
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public string Call()
        {
            return $"Dialing... {this.Number:D7}";
        }
    }
}
