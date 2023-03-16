using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int [] quantityOfOrders = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(quantityOfOrders);
            Console.WriteLine(queue.Max());
            int countOrder = queue.Count();
            for (int i = 0; i < countOrder; i++)
            {
                if (queue.Peek() <= quantityOfFood)
                {
                    quantityOfFood -= queue.Peek();
                    queue.Dequeue();
                }
            }
            if (!queue.Any() || queue.Peek() == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }   
    }
}
