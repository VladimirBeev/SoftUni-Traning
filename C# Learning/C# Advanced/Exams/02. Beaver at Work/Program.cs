using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Beaver_at_Work
{
    internal class Program
    {
        private static int rowPosition;
        private static int colPosition;
        private static char[,] matrix;
        private static List<char> list = new List<char>();
        private static string lastDirection;
        private static int branches;

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size,size];
            for (int row = 0; row < size; row++)
            {
                char[] elements = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                    if (char.IsLower(elements[col]))
                    {
                        branches++;
                    }
                    if (elements[col] == 'B')
                    {
                        rowPosition = row;
                        colPosition = col;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                lastDirection = command;
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                if (branches == 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (branches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {list.Count} wood branches: {string.Join(", ",list)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branches} branches left.");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            if (!IsValid(rowPosition+row,colPosition+col))
            {
                if (list.Any())
                {
                    list.Remove(list[list.Count-1]);
                }
                return;
            }
            matrix[rowPosition, colPosition] = '-';
            rowPosition += row;
            colPosition += col;
            if (char.IsLower(matrix[rowPosition,colPosition]))
            {
                list.Add(matrix[rowPosition, colPosition]);
                matrix[rowPosition, colPosition] = 'B';
                branches--;
            }
            else if (matrix[rowPosition,colPosition] == 'F')
            {
                matrix[rowPosition, colPosition] = '-';
                if (lastDirection == "up")
                {
                    if (rowPosition == 0)
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0)-1,colPosition]))
                        {
                            list.Add(matrix[matrix.GetLength(0) - 1, colPosition]);
                            branches--;
                        }
                        rowPosition = matrix.GetLength(0)-1;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[0,colPosition]))
                        {
                            list.Add(matrix[0, colPosition]);
                            branches--;
                        }
                        rowPosition = 0;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                }
                else if (lastDirection == "down")
                {
                    if (rowPosition == matrix.GetLength(0)-1)
                    {
                        if (char.IsLower(matrix[0, colPosition]))
                        {
                            list.Add(matrix[0, colPosition]);
                            branches--;
                        }
                        rowPosition = 0;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0)-1, colPosition]))
                        {
                            list.Add(matrix[matrix.GetLength(0) - 1, colPosition]);
                            branches--;
                        }
                        rowPosition = matrix.GetLength(0) - 1;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                }
                else if (lastDirection == "right")
                {
                    if (colPosition == matrix.GetLength(1) - 1)
                    {
                        if (char.IsLower(matrix[rowPosition, 0]))
                        {
                            list.Add(matrix[rowPosition, 0]);
                            branches--;
                        }
                        colPosition = 0;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[rowPosition, matrix.GetLength(1)-1]))
                        {
                            list.Add(matrix[rowPosition, matrix.GetLength(1) - 1]);
                            branches--;
                        }
                        colPosition = matrix.GetLength(0) - 1;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                }
                else if (lastDirection == "left")
                {
                    if (colPosition == 0)
                    {
                        if (char.IsLower(matrix[rowPosition, matrix.GetLength(1)-1]))
                        {
                            list.Add(matrix[rowPosition, matrix.GetLength(1) - 1]);
                            branches--;
                        }
                        colPosition = matrix.GetLength(1) - 1;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[rowPosition, 0]))
                        {
                            list.Add(matrix[rowPosition, 0]);
                            branches--;
                        }
                        colPosition = 0;
                        matrix[rowPosition, colPosition] = 'B';
                    }
                }
            }
            else
            {
                matrix[rowPosition, colPosition] = 'B';
            }
        }

        private static bool IsValid(int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0) &&
                 col >= 0 && col < matrix.GetLength(1));
                
        }
    }
}
