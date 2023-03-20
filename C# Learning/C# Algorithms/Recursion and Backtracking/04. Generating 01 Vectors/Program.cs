using System;

namespace _04._Generating_01_Vectors
{
    internal class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int[] vector = new int[num];
            int index = 0;
            Vector(index,vector);
        }

        private static void Vector(int index,int[] vector)
        {
            if (index>=vector.Length)
            {
                Console.WriteLine(string.Join("",vector));
                return;
            }
            
            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Vector(index + 1, vector);
            }
            
        }
    }
}
