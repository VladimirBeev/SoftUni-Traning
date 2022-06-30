using System;

namespace NestedConditional
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int h = 1; h <= 9; h++)
            {
                for (int m = 1; m <= 10; m++)
                {
                    int sum = h * m;
                    Console.WriteLine($"{h}*{m}={sum}");
                }
            }
        }
    }
}
