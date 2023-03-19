using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class Missions
    {
        private string state;
        public string Codename { get; set; }
        public Missions(string codename)
        {
            this.Codename = codename;
            this.State = state;
        }
        
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (value == "inProgress")
                {
                    this.state = value;
                }
                else if (value == "Finished")
                {
                    this.state = value;
                }
            }
        }
        public void CompleteMission()
        {
            return;
        }
        public override string ToString()
        {
            return $"Code Name: {this.Codename} State: {this.State}";
        }
    }
}
