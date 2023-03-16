using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sorted = arrNums.OrderByDescending(x => x).ToArray();
            for (int i = 0; i < sorted.Length; i++)
            {
                if (sorted.Length>3)
                {
                    Console.Write($"{sorted[i]} ");
                    if (i == 2)
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
        }
    }
}
