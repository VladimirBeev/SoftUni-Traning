using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Wardrobe___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();
            int numColor = int.Parse(Console.ReadLine());
            for (int i = 0; i < numColor; i++)
            {
                string[] elements = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (!dictionary.ContainsKey(elements[0]))
                {
                    dictionary.Add(elements[0], new Dictionary<string, int>());
                    string[] clothes = elements[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var clot in clothes)
                    {
                        if (!dictionary[elements[0]].ContainsKey(clot))
                        {
                            dictionary[elements[0]].Add(clot, 1);
                        }
                        else
                            dictionary[elements[0]][clot]++;
                    }
                }
                else
                {
                    string[] clothes = elements[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var clot in clothes)
                    {
                        if (!dictionary[elements[0]].ContainsKey(clot))
                        {
                            dictionary[elements[0]].Add(clot, 1);
                        }
                        else
                            dictionary[elements[0]][clot]++;
                    }
                }
            }
            string[] colorClothes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach(var clot in item.Value)
                {
                    if (item.Key.Contains(colorClothes[0]) && clot.Key.Contains(colorClothes[1]))
                    {
                        Console.WriteLine($"* {clot.Key} - {clot.Value} (found!) ");
                    }
                    else
                        Console.WriteLine($"* {clot.Key} - {clot.Value}");
                }
            }
        }
    }
}
