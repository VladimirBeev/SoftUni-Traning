using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < num; i++)
            {
                int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (arr[0]== 1)
                {
                    stack.Push(arr[1]);
                }
                else if (arr[0] == 2 && stack.Any())
                {
                    stack.Pop();
                }
                else if (arr[0] == 3 && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (arr[0] == 4 && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.Write(string.Join(", ",stack));
        }
    }
}
