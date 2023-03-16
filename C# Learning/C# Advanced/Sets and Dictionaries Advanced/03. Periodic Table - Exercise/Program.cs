using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numRow = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < numRow; i++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string element in elements)
                {
                    set.Add(element);
                }
            }
            Console.Write(string.Join(" ",set));
        }
    }
}
