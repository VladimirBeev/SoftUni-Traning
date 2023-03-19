using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            Dictionary<string, Person> personsKvp = 
                new Dictionary<string, Person>();
            Dictionary<string,Product> productKvp = 
                new Dictionary<string, Product>();
            string[] people = Console.ReadLine()
                    .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            string[] products = Console.ReadLine()
                    .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            try
            {
                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);
                    Person person = new Person(name, money);
                    personsKvp.Add(name, person);
                }
                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);
                    Product product = new Product(name, cost);
                    productKvp.Add(name, product);

                }
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] action = command.Split();

                    string personName = action[0];
                    string productName = action[1];

                    Person person = personsKvp[personName];
                    Product product = productKvp[productName];

                    bool isAdded = person.AddProduct(product);

                    if (!isAdded)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    command = Console.ReadLine();
                }
                foreach (var (name,person) in personsKvp)
                {
                    string productsInfo = person.Products.Count > 0 
                        ? string.Join(", ", person.Products.Select(x=>x.Name))
                        : "Nothing bought";
                    Console.WriteLine($"{name} - {productsInfo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
