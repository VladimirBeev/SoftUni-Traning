using System;

namespace Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int penpack = int.Parse(Console.ReadLine());
            int marckpack = int.Parse(Console.ReadLine());
            int clean = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double sumproduct = penpack * 5.80 + marckpack * 7.20 + (clean * 1.2);
            double sumdiscount = (discount/100.0);
            double total = sumproduct - (sumproduct * sumdiscount);
           
            Console.WriteLine(total);
        }
    }
}
