using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    public class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int index = 0;
            int sum = GetSum(arr,index);
            Console.WriteLine(sum);
        }

        private static int GetSum(int[] arr, int index)
        {
            if (index>=arr.Length)
            {
                return 0;
            }
            return arr[index]+GetSum(arr,index+1);
        }
    }
}
