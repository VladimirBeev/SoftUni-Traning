using System;
using System.Linq;

namespace _7._Knight_Game_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            for (int row = 0; row < matrix.Length; row++)
            {
                string elements = Console.ReadLine();
                char[] kingOrEmpty = elements.ToCharArray();
                for (int col = 0; col < matrix.Length; col++)
                {
                    matrix[row,col] = kingOrEmpty[col];
                }
            }
            char king = 'K';
            while(true)
            {

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix.Length; col++)
                    {
                        if (matrix[row,col] == king)
                        {
                            
                        }
                    }
                }
            }
        }
    }
}
