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
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numToPushPopContain[0]; i++)
            {
                stack.Push(numToProces[i]);
            }
            for (int i = 0;i < numToPushPopContain[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Any())
            {
                if (stack.Contains(numToPushPopContain[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }   
    }
}
