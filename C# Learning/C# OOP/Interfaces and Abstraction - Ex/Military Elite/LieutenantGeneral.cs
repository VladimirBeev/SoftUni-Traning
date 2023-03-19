using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; set; }
        public LieutenantGeneral(string id, string firstname, string lastname, decimal salary, List<Private> privates)
            : base(id, firstname, lastname, salary)
        {
            this.Privates = new List<Private>();
        }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}\nPrivates:{this.Privates}";
        }
    }
}
