using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double pvc = double.Parse(Console.ReadLine());
            double paint = double.Parse(Console.ReadLine());
            double thinner = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double reserv = (10*paint)/100;
            double painsum = (paint+reserv)*14.50;
            double pvcsum = (pvc + 2) * 1.50;
            double thinnersum = thinner * 5.00;

            double total = pvcsum + painsum + thinnersum + 0.40;

            double master = ((30 * total) / 100) * hours;

            
            Console.WriteLine(total+master);
        }
    }
}
