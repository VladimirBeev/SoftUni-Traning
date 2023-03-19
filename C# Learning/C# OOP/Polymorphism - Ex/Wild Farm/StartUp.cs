using System;
using WildFarm.Core;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(foodFactory,animalFactory);
            engine.Start();
        }
    }
}
