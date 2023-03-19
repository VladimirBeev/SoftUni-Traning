using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class Spy : Soldier, ISpy
    {
        public int Codenumber { get; set; }
        public Spy(string id, string firstname, string lastname,int codenumber)
            :base(id, firstname, lastname)
        {
            this.Codenumber = codenumber;
        }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}\nCode Number: {this.Codenumber} ";
        }
    }
}
