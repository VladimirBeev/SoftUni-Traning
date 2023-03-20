using System;
using System.Linq;

namespace _05._Generating_Combinations
{
    internal class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());
            int startNum = 0;
            int endNum = arr.Count();
            int index = 0;
            Combination(arr,index,)
        }
    }
}
