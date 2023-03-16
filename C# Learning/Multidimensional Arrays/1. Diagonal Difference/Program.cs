using System;
using System.Linq;
namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main()
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];
            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                int[] currentRowNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = currentRowNum[col];
                    if (row == col)
                    {
                        int[] primaryDiagonal = new int[sizeOfMatrix];
                        primaryDiagonal[col] = currentRowNum[col];
                        sumPrimaryDiagonal += primaryDiagonal[col];  
                    }
                    for (int i = 0; i < sizeOfMatrix; i++)
                    {
                        if (row == i && col == sizeOfMatrix-1-i)
                        {
                            int[] secondDiagonal = new int[sizeOfMatrix];
                            secondDiagonal[col] = currentRowNum[col];
                            sumSecondaryDiagonal += secondDiagonal[col];
                        }
                    }
                }
            }
            int sumDiagonal = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);
            Console.WriteLine(sumDiagonal);
        }
    }
}
