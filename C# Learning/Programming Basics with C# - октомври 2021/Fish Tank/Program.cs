using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            double daljina = double.Parse(Console.ReadLine());
            double shirina = double.Parse(Console.ReadLine());
            double visochina = double.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine())/100;
            double sum = daljina * shirina * visochina;
           
            double litri = sum / 1000;
          
            double pqsak = 1 - procent;
           
            double litrisum = litri*pqsak;
                

            Console.WriteLine(litrisum);
        }
    }
}
