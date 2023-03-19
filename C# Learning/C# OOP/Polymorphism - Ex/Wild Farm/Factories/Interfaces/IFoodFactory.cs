using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        Food CreateFood(string type,int quantity);
    }
}
