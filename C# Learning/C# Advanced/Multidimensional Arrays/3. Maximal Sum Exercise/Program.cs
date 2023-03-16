using System;
using System.Linq;

namespace _3._Maximal_Sum_Exercise
{
    internal class Program
    {
        static void Main()
        {
            int[] sizeOfMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizeOfMatrix[0], sizeOfMatrix[1]];
            int totalSum = 0;
            int[] firstNums = new int[3];
            int[] secondNums = new int[3];
            int[] thirdNums = new int[3];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elementsArray = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elementsArray[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int firstRow = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int secondRow = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int thirdRow = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    int currentSum = firstRow + secondRow + thirdRow;
                    if (currentSum > totalSum)
                    {
                        totalSum = currentSum;
                        firstNums = new int[3] { matrix[row, col], matrix[row, col + 1], matrix[row, col + 2] };
                        secondNums = new int[3] { matrix[row + 1, col] , matrix[row + 1, col + 1] , matrix[row + 1, col + 2]};
                        thirdNums = new int[3] { matrix[row + 2, col] , matrix[row + 2, col + 1] , matrix[row + 2, col + 2] };
                        currentSum = 0;
                    }
                    currentSum = 0;
                }
            }
            Console.WriteLine($"Sum = {totalSum}");
            foreach (var num in firstNums)
                Console.Write($"{num} ");
            Console.WriteLine();
            foreach (var num in secondNums)
                Console.Write($"{num} ");
            Console.WriteLine();
            foreach (var num in thirdNums)
                Console.Write($"{num} ");
        }
    }
}
