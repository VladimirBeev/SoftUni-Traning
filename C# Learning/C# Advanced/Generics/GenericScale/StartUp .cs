using System;

namespace GenericScale
{
    internal class StartUp
    {
        static void Main()
        {
            var one = 5;
            var two = 2;
            EqualityScale<int> equality = new EqualityScale<int>(one, two);
            Console.WriteLine(equality.AreEqual());
        }
    }
}
