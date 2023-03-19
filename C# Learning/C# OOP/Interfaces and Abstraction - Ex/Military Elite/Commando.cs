using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Missions> mission;
        public Commando(string id,string firstname, string lastname, decimal salary, string corps, List<Missions>mission)
            :base(id,firstname,lastname,salary,corps)
        {
            this.Mission = new List<Missions>();
        }

        public List<Missions> Mission 
        { 
            get
            {
                return this.mission;
            }
            set
            {
                this.Mission = value;
            }
        }
        public void CompleteMission()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary} Corps: {this.Corps} Missions: {this.Mission}";
        }
    }
}
