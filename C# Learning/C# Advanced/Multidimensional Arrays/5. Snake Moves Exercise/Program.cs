using System;
using System.Linq;
namespace _5._Snake_Moves_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] snakeMtrix = new char[sizeMatrix[0], sizeMatrix[1]];
            char[] elements = Console.ReadLine().ToCharArray();
            int index = 0;
            for (int row = 0; row < snakeMtrix.GetLength(0); row++)
            {
                if (row == 0 || row % 2 == 0)
                {
                    for (int col = 0; col < snakeMtrix.GetLength(1); col++)
                    {
                        if (index > elements.Length - 1)
                        {
                            index = 0;
                        }
                        snakeMtrix[row, col] = elements[index];
                        index++;
                    }
                }
                else
                    for (int col = snakeMtrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (index > elements.Length - 1)
                        {
                            index = 0;
                        }
                        snakeMtrix[row, col] = elements[index];
                        index++;
                    }
            }
            for (int row = 0; row < snakeMtrix.GetLength(0); row++)
            {
                for (int col = 0; col < snakeMtrix.GetLength(1); col++)
                {
                    Console.Write(snakeMtrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
