using System;

namespace _03._1_Generating_01_Vectors
{
    internal class Program
    {
        public static int num;
        public static int[] array;
        public static int[] modify;
        public static int index;
        public static void Main()
        {
            num = int.Parse(Console.ReadLine());
            array = new int[num];
            index = 0;
            GenVectors(index);
        }

        private static void GenVectors(int index)
        {
            if (index>=array.Length)
            {
                Console.WriteLine($"{string.Join("", array)}");
                return; 
            }

            for (int i = 0; i < 2; i++)
            {
                array[index] = i;
                GenVectors(index+1);
            }
        }
    }
}
