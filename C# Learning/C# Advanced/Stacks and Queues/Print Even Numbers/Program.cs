using System;
using System.Linq;
using System.Collections.Generic;

namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                
            Queue<int> queue = new Queue<int>(arr);
            Queue<int> eventNumbres = new Queue<int>();
            foreach (int i in arr)
            {
                if (i % 2 == 0)
                {
                    eventNumbres.Enqueue(i);
                }
            }
            Console.WriteLine(string.Join(", ", eventNumbres));
        }
    }
}
