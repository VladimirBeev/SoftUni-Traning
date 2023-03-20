using System;

namespace _03._Recursive_Drawing
{
    internal class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Draaw(num);
        }

        private static void Draaw(int num)
        {
            if (num == 0)
            {
                return;
            };
            Console.WriteLine(new string('*',num));
            Draaw(num - 1);
            Console.WriteLine(new string('#',num));
        }
    }
}
