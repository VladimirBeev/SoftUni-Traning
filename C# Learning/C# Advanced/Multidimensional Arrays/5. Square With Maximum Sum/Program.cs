using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;
            string bestMatrix = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row,col+1] + matrix[row+1,col] + matrix[row+1,col+1];
                    if (currentSum>sum)
                    {
                        sum = currentSum;
                        bestMatrix = matrix[row, col] + " " + 
                            matrix[row, col + 1] + "\n" + 
                            matrix[row + 1, col] + " " + 
                            matrix[row + 1, col + 1];
                    }
                }
            }
            Console.WriteLine(bestMatrix);
            Console.WriteLine(sum);
        }
        
    }
}
