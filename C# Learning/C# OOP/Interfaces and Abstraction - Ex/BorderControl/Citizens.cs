using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizens : Subordinate,IBuyer
    {
        private int age;
        public Citizens(string name, int age, string id, string birthday)
            :base(name)
        {
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        public int BuyFood()
        {
            return 10;
        }
    }
}
