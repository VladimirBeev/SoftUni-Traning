using System;

namespace Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double inch = double.Parse(Console.ReadLine());
            double sm = 2.54 * inch;
            Console.WriteLine(sm);
        }
    }
}
