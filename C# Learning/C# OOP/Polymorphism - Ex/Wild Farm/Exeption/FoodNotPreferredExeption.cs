using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Exeption
{
    public class FoodNotPreferredExeption : Exception
    {
        
        public FoodNotPreferredExeption(string message)
            :base(message)
        {

        }
    }
}
