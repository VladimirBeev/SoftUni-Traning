using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carPass = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int count = 0;
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carPass; i++)
                    {
                        if (queue.Count != 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
