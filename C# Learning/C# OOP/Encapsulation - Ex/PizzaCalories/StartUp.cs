using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            string[] inputPizza = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string name = inputPizza[1];

            string[] inputDough = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string flourType = inputDough[1];
            string bakingTechnique = inputDough[2];
            int weight = int.Parse(inputDough[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(name,dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppingInfo = input.Split();

                    string toppingType = toppingInfo[1];
                    int toppingweight = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingweight);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
