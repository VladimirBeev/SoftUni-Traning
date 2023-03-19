using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main()
        {
            double[] waterSicu = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] flourSicu = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(waterSicu);
            Stack<double> flour = new Stack<double>(flourSicu);
            Dictionary<string, double> bakeryColecction = new Dictionary<string, double>();

            while (water.Count != 0 && flour.Count != 0)
            {
                double sum = water.Peek() + flour.Peek();
                double waterProcent = (water.Peek() * 100) / sum;
                double flourProcent = (flour.Peek() * 100) / sum;

                if (waterProcent == 40 && flourProcent == 60)
                {
                    if (!(bakeryColecction.ContainsKey("Muffin")))
                    {
                        bakeryColecction.Add("Muffin", 1);
                    }
                    else
                        bakeryColecction["Muffin"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (waterProcent == 30 && flourProcent == 70)
                {
                    if (!(bakeryColecction.ContainsKey("Baguette")))
                    {
                        bakeryColecction.Add("Baguette", 1);
                    }
                    else
                        bakeryColecction["Baguette"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (waterProcent == 20 && flourProcent == 80)
                {
                    if (!(bakeryColecction.ContainsKey("Bagel")))
                    {
                        bakeryColecction.Add("Bagel", 1);
                    }
                    else
                        bakeryColecction["Bagel"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (waterProcent == 50 && flourProcent == 50)
                {
                    if (!(bakeryColecction.ContainsKey("Croissant")))
                    {
                        bakeryColecction.Add("Croissant", 1);
                    }
                    else
                        bakeryColecction["Croissant"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (true)
                {
                    double flourNeed = flour.Pop() - water.Peek();
                    flour.Push(flourNeed);
                    water.Dequeue();
                    if (!(bakeryColecction.ContainsKey("Croissant")))
                    {
                        bakeryColecction.Add("Croissant", 1);
                    }
                    else
                        bakeryColecction["Croissant"] += 1;
                }
            }

            foreach (var item in bakeryColecction.OrderByDescending(b => b.Value).ThenBy(b=>b.Key))
            {
                Console.Write($"{item.Key}: {item.Value}\n");
            }
            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }

        }
    }
}
