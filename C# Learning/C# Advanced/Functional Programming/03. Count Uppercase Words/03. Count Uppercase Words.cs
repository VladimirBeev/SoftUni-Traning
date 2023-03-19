using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine(string.Join(" \n",Console.ReadLine()
                        .Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => x[0] == x.ToUpper()[0])).ToArray());
        }
    }
}
