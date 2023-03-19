using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public class Soldier : ISoldier
    {

        public Soldier(string id,string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Id = id;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
