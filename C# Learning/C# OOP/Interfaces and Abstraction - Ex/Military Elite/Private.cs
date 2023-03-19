using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class Private : Soldier , IPrivate
    {
        public decimal Salary { get; set; }
        public Private(string id,string firstname, string lastname, decimal salary)
            : base(id,firstname,lastname)
        {
            this.Salary = salary;
        }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}";
        }
    }
}
