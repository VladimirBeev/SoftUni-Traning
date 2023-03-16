using System;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kidName = Console.ReadLine();
            Queue<string> kids = new Queue<string>(kidName.Split(" "));
            int toss = int.Parse(Console.ReadLine());
            while (kids.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
