using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Subordinate : IId , IBithday
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; }

        public Subordinate(string name)
        {
            this.Name = name;
        }
    }
}
