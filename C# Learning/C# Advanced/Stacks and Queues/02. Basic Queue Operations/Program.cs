using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numToPushPopContain = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numToProces = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numToPushPopContain[0]; i++)
            {
                queue.Enqueue(numToProces[i]);
            }
            for (int i = 0; i < numToPushPopContain[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Any())
            {
                if (queue.Contains(numToPushPopContain[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}

