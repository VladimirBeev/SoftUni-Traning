using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<Repairs> Repairs { get; set; }

        public Engineer(string id,string firstname,string lastname, decimal salary, string corps, List<Repairs>repairpart)
            :base(id,firstname,lastname,salary,corps)
        {
            this.Repairs = new List<Repairs>();
        }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary} Corps: {this.Corps} Repairs: {this.Repairs}";
        }
    }
}
