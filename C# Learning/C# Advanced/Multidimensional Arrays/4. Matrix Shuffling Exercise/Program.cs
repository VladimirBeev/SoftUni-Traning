using System;
using System.Linq;

namespace _4._Matrix_Shuffling_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] stringMatrix = new string[sizeMatrix[0], sizeMatrix[1]];
            for (int row = 0; row < stringMatrix.GetLength(0); row++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < stringMatrix.GetLength(1); col++)
                {
                    stringMatrix[row, col] = elements[col];
                }
            }
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "END")
            {
                string action = commands[0];
                if (commands.Length == 5 && action == "swap")
                {
                    int rowOne = int.Parse(commands[1]);
                    int colOne = int.Parse(commands[2]);
                    int rowTwo = int.Parse(commands[3]);
                    int colTwo = int.Parse(commands[4]);
                    if (rowOne < stringMatrix.GetLength(0) && colOne < stringMatrix.GetLength(1) &&
                        rowTwo < stringMatrix.GetLength(0) && colTwo < stringMatrix.GetLength(1))
                    {
                        string currentString = stringMatrix[rowOne, colOne];
                        stringMatrix[rowOne, colOne] = stringMatrix[rowTwo, colTwo];
                        stringMatrix[rowTwo, colTwo] = currentString;
                        for (int row = 0; row < stringMatrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < stringMatrix.GetLength(1); col++)
                            {
                                Console.Write($"{stringMatrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
