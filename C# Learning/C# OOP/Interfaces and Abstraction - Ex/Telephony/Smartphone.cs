using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : IPhone,IWeb
    {
        private int number;
        private string webSite;
        public Smartphone(int number)
        {
            this.Number = number;
        }
        public Smartphone(string webSite)
        {
            this.WebSite = webSite;
        }

        public string WebSite
        {
            get
            {
                return this.webSite;
            }
            set
            {
                this.webSite = value;
            }
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
            return $"Calling... {this.Number:D10}";
        }

        public string WebUrl()
        {
            return $"Browsing: {this.WebSite}!";
        }
    }
}
