using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class Repairs
    {
        public string Partname { get; set; }
        public int Hoursworked { get; set; }
        public Repairs(string partname, int hoursworked)
        {
            this.Partname = partname;
            this.Hoursworked = hoursworked;
        }
        public override string ToString()
        {
            return $"Part Name: {this.Partname} Hours Worked: {this.Hoursworked}";
        }
    }
}
