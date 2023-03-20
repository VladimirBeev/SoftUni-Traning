using System;

namespace _02._1_Recursive_Drawing
{
    internal class Program
    {
        public static int num;
        public static int index;
        public static void Main()
        {
            num = int.Parse(Console.ReadLine());
            index = 0;
            Draw(index);
        }

        private static void Draw(int index)
        {
            if (index == num)
            {
                return;
            }


            for (int i = index; i < num; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            Draw(index+1);

            for (int i = index; i < num; i++)
            {
                Console.Write('#');
            }
            Console.WriteLine();
        }
    }
}
