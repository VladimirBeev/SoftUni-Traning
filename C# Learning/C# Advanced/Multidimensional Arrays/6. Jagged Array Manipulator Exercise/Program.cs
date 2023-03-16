using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowSize][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            for (int row = 0;row < matrix.Length-1; row++)
            {
                if (matrix[row].Length == matrix[row+1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        int multiplayOne = matrix[row][col] * 2;
                        matrix[row][col] = multiplayOne;
                        int multiplayTwo = matrix[row+1][col] * 2;
                        matrix[row+1][col] = multiplayTwo;
                    }
                }
                else
                {
                    if (matrix[row].Length > matrix[row+1].Length)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            if (matrix[row].Length > col)
                            {
                                int devideOne = matrix[row][col] / 2;
                                matrix[row][col] = devideOne;
                            }
                            if (matrix[row + 1].Length > col)
                            {
                                int devideTwo = matrix[row + 1][col] / 2;
                                matrix[row + 1][col] = devideTwo;
                            }
                        }
                    }
                    else
                    {
                        for (int col = 0; col < matrix[row+1].Length; col++)
                        {
                            if (matrix[row].Length > col)
                            {
                                int devideOne = matrix[row][col] / 2;
                                matrix[row][col] = devideOne;
                            }
                            if (matrix[row + 1].Length > col)
                            {
                                int devideTwo = matrix[row + 1][col] / 2;
                                matrix[row + 1][col] = devideTwo;
                            }
                        }
                    }
                    
                }
            }
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (commands[0]!= "End")
            {
                
                int rowNum = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (commands[0] == "Add")
                {
                    if (rowNum < matrix.Length && rowNum>= 0)
                    {
                        if (matrix[rowNum].Length>col && col >=0)
                        {
                            matrix[rowNum][col] += value;
                        }
                    }
                }
                else if (commands[0]== "Subtract")
                {
                    if (rowNum < matrix.Length && rowNum >= 0)
                    {
                        if (matrix[rowNum].Length > col & col >=0)
                        {
                            matrix[rowNum][col] -= value;
                        }
                    }
                }
                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var ele in matrix)
            {
                Console.Write(string.Join(" ",ele));
                Console.WriteLine();
            }
        }
    }
}
