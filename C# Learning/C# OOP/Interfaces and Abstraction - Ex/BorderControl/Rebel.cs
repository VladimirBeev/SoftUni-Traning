using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : Subordinate, IBuyer
    {
        public int Age { get; set; }
        public HashSet<string> Group { get; set; }
        public Rebel(string name, int age, string group)
            : base(name)
        {
            this.Age = age;
            this.Group = new HashSet<string> { group };
        }

        public int BuyFood()
        {
            return 5;
        }
    }
}
