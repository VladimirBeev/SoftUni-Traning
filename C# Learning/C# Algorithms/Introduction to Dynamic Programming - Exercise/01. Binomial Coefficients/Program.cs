using System;
using System.Collections.Generic;

namespace _01._Binomial_Coefficients
{
    public class Program
    {
        private static Dictionary<string, long> chash;
        static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            chash = new Dictionary<string, long>();
            Console.WriteLine(Binom(row,col));
        }

        private static long Binom(int row, int col)
        {
            if (col == row || col == 0)
            {
                return 1;
            }
            var key = $"{row}-{col}";
            if (chash.ContainsKey(key))
            {
                return chash[key];
            }
            var result = Binom(row - 1, col - 1) + Binom(row - 1, col);
            chash[key] = result;
            return result;
        }
    }
}
