using System;
using System.Linq;

namespace _01._1_Recursive_Array_Sum
{
    internal class Program
    {
        public static int[] array;
        public static int index;
        public static void Main()
        {
            array = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            index = 0;
            Console.WriteLine(SumArray(0));
        }

        private static int SumArray(int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }
            return array[index]+SumArray(index+1);
        }
    }
}
