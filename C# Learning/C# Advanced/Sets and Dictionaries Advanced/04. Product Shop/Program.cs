using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main()
        {
            SortedDictionary<string,Dictionary<string,double>> foodShops = new SortedDictionary<string,Dictionary<string, double>>();
            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] action = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string shop = action[0];
                string product = action[1];
                double price = double.Parse(action[2]);
                if (!foodShops.ContainsKey(shop))
                {
                    foodShops.Add(shop, new Dictionary<string,double>());
                    
                }
                foodShops[shop].Add(product, price);

                command = Console.ReadLine();
            }
            foreach(var item in foodShops)
            {
                Console.WriteLine($"{item.Key}->");
                foreach(var item2 in item.Value)
                {
                    Console.WriteLine($"Product: {item2.Key}, Price: {item2.Value}");
                }
                
            }
        }
    }
}
