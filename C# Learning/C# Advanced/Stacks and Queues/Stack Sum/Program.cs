using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] tokens = command.Split();
                string  actions = tokens[0].ToString().ToLower();
                if (actions == "add")
                {
                    int firstNumberToAdd = int.Parse(tokens[1]);
                    int secondNumberToAdd = int.Parse(tokens[2]);
                    stack.Push(firstNumberToAdd);
                    stack.Push(secondNumberToAdd);
                }
                else if (actions == "remove")
                {
                    int firstNumberToRemove = int.Parse(tokens[1]);
                    if (stack.Count > firstNumberToRemove)
                    {
                        for (int i = 0; i < firstNumberToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine("Sum: {0}",stack.Sum());
        }
    }
}
