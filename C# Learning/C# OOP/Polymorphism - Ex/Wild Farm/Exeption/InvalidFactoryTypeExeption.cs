using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Exeption
{
    internal class InvalidFactoryTypeExeption : Exception
    {
        private const string DefMessage = "Invalid type!";

        public InvalidFactoryTypeExeption() 
            : base(DefMessage)
        {

        }
        public InvalidFactoryTypeExeption(string massage)
            : base(massage)
        {

        }
    }
}
