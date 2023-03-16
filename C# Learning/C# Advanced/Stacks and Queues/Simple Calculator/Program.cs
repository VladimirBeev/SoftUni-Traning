using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split());
            Stack<string> reversedStack = new Stack<string>(stack);
            int sum = int.Parse(reversedStack.Pop());
            
            while (reversedStack.Count != 0 )
            {
                char ch = char.Parse(reversedStack.Pop());
                int num = int.Parse(reversedStack.Pop());
                if (ch == 43)
                {
                    sum += num;
                }
                else
                {
                    sum -= num;
                }
            }
            Console.WriteLine(sum);
            
        }
    }
}
