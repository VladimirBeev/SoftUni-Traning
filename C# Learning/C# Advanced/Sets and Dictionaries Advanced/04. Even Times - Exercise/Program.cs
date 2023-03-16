using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Even_Times___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numRow = int.Parse(Console.ReadLine());
            HashSet<int> set = new HashSet<int>();
            HashSet<int> eventTime = new HashSet<int>();
            for (int i = 0; i < numRow; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (set.Contains(number))
                {
                    eventTime.Add(number);
                }
                set.Add(number);
            }
            Console.WriteLine(string.Join(" ",eventTime));
        }
    }
}
