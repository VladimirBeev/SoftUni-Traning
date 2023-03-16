using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double, int> counter = new Dictionary<double, int>();
            foreach (var item in arr)
            {
                if (counter.ContainsKey(item))
                {
                    counter[item]++;
                }
                else
                {
                    counter[item] = 1;
                }
            }
            foreach (var i in counter)
            {
                Console.WriteLine($"{i.Key} - {i.Value} times");
            }
        }
    }
}
