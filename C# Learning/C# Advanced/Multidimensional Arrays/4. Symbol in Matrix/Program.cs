using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string stringElements = Console.ReadLine();
                char[] chars = stringElements.ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = chars[col];
                }
            }
            char serchEmenent= char.Parse(Console.ReadLine());
            bool notExist = true;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (serchEmenent == matrix[row,col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        notExist = false;
                    }
                    
                }
            }
            if (notExist)
            {
                
                Console.WriteLine($"{serchEmenent} does not occur in the matrix");
            }
        }
    }
}
