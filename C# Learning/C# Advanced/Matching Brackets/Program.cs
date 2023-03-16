using System;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    internal class Program
    {
        static void Main()
        {
            string expr = Console.ReadLine();
            var stack = new Stack<int>();    
            for (int i = 0; i< expr.Length; i++)
            {
                char c = expr[i];
                if (c == '(')
                {
                    stack.Push(i);
                }
                else if (c == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string subexpr = expr.Substring(startIndex, endIndex - startIndex+1);
                    Console.WriteLine(subexpr);

                }
            }
        }
    }
}
