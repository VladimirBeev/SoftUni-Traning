using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int DogFood = int.Parse(Console.ReadLine());
            int CatFood = int.Parse(Console.ReadLine());
            double sum = (DogFood * 2.50) + (CatFood * 4); 
            Console.WriteLine($"{sum} lv.");
        }
    }
}
