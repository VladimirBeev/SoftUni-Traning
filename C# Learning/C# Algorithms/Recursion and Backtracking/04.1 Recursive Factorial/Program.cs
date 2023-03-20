using System;

namespace _04._1_Recursive_Factorial
{
    internal class Program
    {
        public static int num;
        public static void Main()
        {
            num = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactoriel(num));
        }

        private static int GetFactoriel(int num)
        {
            if (num == 1)
            {
                return 1;
            }
            return num*GetFactoriel(num - 1);
        }
    }
}
