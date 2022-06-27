using System;

namespace Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositsum = double.Parse(Console.ReadLine());
            int period = int.Parse(Console.ReadLine());
            double lihva = double.Parse(Console.ReadLine())/100;
            double totalsum = depositsum + period * ((depositsum * lihva) / 12);

            Console.WriteLine(totalsum);
        }
    }
}
