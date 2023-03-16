using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var list = new Dictionary<string, Dictionary<string,List<string>>>();
            for (int i = 0; i < num; i++)
            {
                string[] action = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = action[0];
                string country = action[1];
                string city = action[2];

                if (!list.ContainsKey(continent))
                {
                    list[continent] = new Dictionary<string, List<string>>();   
                    
                }
                if (!list[continent].ContainsKey(country))
                {
                    list[continent][country] = new List<string>();
                }
                list[continent][country].Add(city);
            }
            foreach (var continent in list.Keys)
            {
                Console.WriteLine($"{continent}:");
                foreach (var country in list[continent])
                {
                    Console.WriteLine($"    {country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
