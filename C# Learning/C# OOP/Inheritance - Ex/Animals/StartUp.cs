using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string command;
            while((command = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray(); ;
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = animalInfo[2];
                    Animal animal = null;
                    if (command == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (command == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (command == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (command == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (command == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                        throw new Exception("Invalid input!");

                    animals.Add(animal);
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid input!");
                }
                
            }
            foreach (Animal ani in animals)
            {
                Console.WriteLine(ani);
            }
        }
    }
}
