using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int[] numb = Console.ReadLine()
                        .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            Console.WriteLine(numb.Length);
            Console.WriteLine(numb.Sum());
        }
    }
}
