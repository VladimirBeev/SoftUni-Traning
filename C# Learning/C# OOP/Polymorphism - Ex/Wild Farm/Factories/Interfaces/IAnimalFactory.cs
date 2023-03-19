using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals;

namespace WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name,double weight, string thirdParam, string fourthParam = null);
    }
}
