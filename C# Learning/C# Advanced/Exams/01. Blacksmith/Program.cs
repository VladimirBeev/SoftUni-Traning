using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            SortedDictionary<string, int> sword = new SortedDictionary<string, int>();

            while (steel.Count>0 && carbon.Count>0)
            {
                int stcount = steel.Count;
                var forge = steel.Peek() + carbon.Peek();
                if (forge == 70)
                {
                    if (sword.ContainsKey("Gladius"))
                    {
                        sword["Gladius"] += 1;
                        steel.Dequeue();
                        carbon.Pop();
                    }
                    else
                    {
                        sword.Add("Gladius", 1);
                        steel.Dequeue();
                        carbon.Pop();
                    }
                }
                else if (forge == 80)
                {
                    if (sword.ContainsKey("Shamshir"))
                    {
                        sword["Shamshir"] += 1;
                        steel.Dequeue();
                        carbon.Pop();
                    }
                    else
                    {
                        sword.Add("Shamshir", 1);
                        steel.Dequeue();
                        carbon.Pop();
                    }
                }
                else if (forge == 90)
                {
                    if (sword.ContainsKey("Katana"))
                    {
                        sword["Katana"] += 1;
                        steel.Dequeue();
                        carbon.Pop();
                    }
                    else
                    {
                        sword.Add("Katana", 1);
                        steel.Dequeue();
                        carbon.Pop();
                    }
                }
                else if (forge == 110)
                {
                    if (sword.ContainsKey("Sabre"))
                    {
                        sword["Sabre"] += 1;
                        steel.Dequeue();
                        carbon.Pop();
                    }
                    else
                    {
                        sword.Add("Sabre", 1);
                        steel.Dequeue();
                        carbon.Pop();
                    }

                }
                else if (forge == 150)
                {
                    if (sword.ContainsKey("Broadsword"))
                    {
                        sword["Broadsword"] += 1;
                        steel.Dequeue();
                        carbon.Pop();
                    }
                    else
                    {
                        sword.Add("Broadsword", 1);
                        steel.Dequeue();
                        carbon.Pop();
                    }
                }
                else
                {
                    steel.Dequeue();
                    int newvalue = carbon.Peek() + 5;
                    carbon.Pop();
                    carbon.Push(newvalue);
                }
            }
            if (!sword.Any())
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
                Console.WriteLine($"You have forged {sword.Values.Sum()} swords.");
            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            if (sword.Any())
            {
                foreach (var sw in sword)
                {
                    Console.WriteLine($"{sw.Key}: {sw.Value}");
                }
            }
        }
    }
}
