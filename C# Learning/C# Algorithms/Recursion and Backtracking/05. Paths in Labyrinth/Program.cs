using System;
using System.Collections.Generic;

namespace _05._Paths_in_Labyrinth
{
    internal class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var array = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var element = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    array[row, col] = element[col];
                }
            }
            var directions = new List<string>();
            string direction = string.Empty;
            FindePath(array, 0, 0, directions, direction);
        }

        private static void FindePath(char[,] array, int row, int col, List<string> directions, string direction)
        {
            //Validate row and col
            if (row < 0 || row >= array.GetLength(0) || col < 0 || col >= array.GetLength(1))
            {
                return;
            }
            //Check for wall
            if (array[row, col] == '*'|| array[row,col] == 'V')
            {
                return;
            }
            if (true)
            {

            }

            directions.Add(direction);

            if (array[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }
            array[row, col] = 'V';
           

            FindePath(array, row - 1, col, directions, "U");//UP
            FindePath(array, row + 1, col, directions, "D");//DOWN
            FindePath(array, row, col - 1, directions, "L");//LEFT
            FindePath(array, row, col + 1, directions, "R");//RIGHT

            array[row, col] = '-';
            directions.RemoveAt(directions.Count-1);
        }
    }
}
