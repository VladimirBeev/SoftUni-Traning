using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public interface ISoldier
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
