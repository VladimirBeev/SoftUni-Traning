using System;

namespace _02._Nested_Loops
{
    public class Program
    {
        private static int[] elements;
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            elements = new int[n];

            GenVector(0);
        }

        private static void GenVector(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ",elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[index] = i;
                GenVector(index + 1);

            }
        }
    }
}
