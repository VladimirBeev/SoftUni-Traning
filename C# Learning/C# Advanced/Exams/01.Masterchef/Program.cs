using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main()
        {
            int[] numberOfIngredients = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numberOfFreshness = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var ingredients = new Queue<int>(numberOfIngredients);
            var freshness = new Stack<int>(numberOfFreshness);
            var dish = new Dictionary<string, int>
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };

            while (ingredients.Count != 0 && freshness.Count != 0)
            {
                if (!(ingredients.Peek() == 0))
                {
                    int multiplay = ingredients.Peek() * freshness.Peek();
                    if (multiplay == 400)
                    {
                        dish["Lobster"] += 1;
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else if (multiplay == 300)
                    {
                        dish["Chocolate cake"] += 1;
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else if (multiplay == 250)
                    {
                        dish["Green salad"] += 1;
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else if (multiplay == 150)
                    {
                        dish["Dipping sauce"] += 1;
                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else
                    {
                        freshness.Pop();
                        int increase = ingredients.Dequeue() + 5;
                        ingredients.Enqueue(increase);
                    }
                }
                else
                    ingredients.Dequeue();
            }
            if (dish["Lobster"] > 0 && dish["Chocolate cake"] > 0 && dish["Green salad"] > 0 && dish["Dipping sauce"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
                Console.WriteLine("You were voted off. Better luck next year.");
            if (ingredients.Count>0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var item in dish.OrderBy(d=>d.Key).ThenBy(d=>d.Value))
            {
                if (item.Value>0)
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
        }
    }
}
