using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValue = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothesValue);
            int count = 1;
            int sum = 0;
            int stacCount = stack.Count;
            for (int i = 0; i < stacCount; i++)
            {
                    if (sum < capacity)
                    {
                        sum += stack.Peek();
                    }
                    if (sum == capacity)
                    {
                        if (stack.Any())
                        {
                            count++;
                            sum = 0;
                        }
                    }
                    if (sum > capacity)
                    {
                        sum = stack.Peek();
                        count++;
                    }
                    stack.Pop();
            }
            Console.WriteLine(count);
        }
    }
}
