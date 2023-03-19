using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main()
        {
              Console.WriteLine(string.Join(", ",Console.ReadLine()
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.Parse(x))
                        .Where(x => x % 2 == 0)
                        .OrderBy(x => x)
                        .ToArray()));
            
        }
    }
}
