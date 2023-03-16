using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(songs);
            while (queue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                if (command.Contains("Add"))
                {
                    string song = command.Substring(4);
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
