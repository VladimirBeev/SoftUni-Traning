using System;
using System.Collections.Generic;
using WildFarm.Exeption;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animal;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private Engine()
        {
            this.animal = new List<Animal>();
        }
        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
            : this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }
        public void Start()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArgs = command.Split();
                    string[] foodArgs = Console.ReadLine().Split();

                    Animal animal = BuildAnimalUsingFactory(animalArgs);
                    Food food = this.foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));

                    Console.WriteLine(animal.ProduseSound());
                    this.animal.Add(animal);
                    animal.Eat(food);
                }
                catch (InvalidFactoryTypeExeption ifte)
                {
                    Console.WriteLine(ifte.Message);
                }
                catch (FoodNotPreferredExeption fnpe)
                {
                    Console.WriteLine(fnpe.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (Animal animals in animal)
            {
                Console.WriteLine(animals);
            }
        }
        private Animal BuildAnimalUsingFactory(string[] animalArgs)
        {
            Animal animal;
            if (animalArgs.Length == 4)
            {
                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, thirdParam);
            }
            else if (animalArgs.Length == 5)
            {
                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];
                string fourthParam = animalArgs[4];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, thirdParam, fourthParam);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
