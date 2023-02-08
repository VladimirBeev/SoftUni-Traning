using System;

namespace Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radian = double.Parse(Console.ReadLine());
            Console.WriteLine(radian*180 /Math.PI);
        }
    }
}
