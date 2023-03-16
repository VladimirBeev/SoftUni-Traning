using System;
using System.Linq;

namespace _2._Squares_in_Matrix_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] matrixElements = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = matrixElements[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        if (matrix[row, col] == matrix[row + 1, col + 1])
                        {
                            if (matrix[row, col] == matrix[row + 1, col])
                            {
                                counter++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
