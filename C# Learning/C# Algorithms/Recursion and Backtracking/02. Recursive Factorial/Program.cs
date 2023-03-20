using System;

namespace _02._Recursive_Factorial
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFactoriel(n));
        }

        private static int GetFactoriel(int n)
        {
            if (n<=0)
            {
                return 1;
            }
            return n * GetFactoriel(n - 1);
        }
    }
}
