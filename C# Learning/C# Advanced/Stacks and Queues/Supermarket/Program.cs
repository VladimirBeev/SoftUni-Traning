using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Queue<string> customerName = new Queue<string>();
            while (command != "End")
            {
                if (command != "Paid")
                {
                    customerName.Enqueue(command);
                }
                else if (command == "Paid")
                {
                    Console.WriteLine(string.Join("\n",customerName));
                    customerName.Clear();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{customerName.Count} people remaining.");
        }
    }
}
