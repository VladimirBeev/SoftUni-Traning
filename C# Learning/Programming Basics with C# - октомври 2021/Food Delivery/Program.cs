using System;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            double pile = double.Parse(Console.ReadLine()) * 10.35;
            double riba = double.Parse(Console.ReadLine()) * 12.40;
            double vega = double.Parse(Console.ReadLine()) * 8.15;

            double foodsum = riba + pile + vega;
            double desert = 0.2 * foodsum;          

            Console.WriteLine(foodsum+desert+2.50);
        }
    }
}
