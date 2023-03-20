using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._1Paths_in_Labyrinth
{
    internal class Program
    {
        public static char[,] matrix;
        public static List<string> path;
        public static bool[,] visited;

        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            path = new List<string>();
            visited = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var el = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = el[col];
                }
            }

            GetPath(0, 0,string.Empty);
        }

        private static void GetPath(int row, int col, string directions)
        {
            if (IsValid(row, col))
                 return;

            path.Add(directions);
            if (IsExit(row, col))
            {
                Console.WriteLine(string.Join(string.Empty, path));
                path.RemoveAt(path.Count - 1);
                return;
            }
            else if (!IsWall(row, col) && !IsVisited(row, col))
            {
                Marck(row, col);
                GetPath(row - 1, col, "U");//up
                GetPath(row + 1, col, "D");//down
                GetPath(row, col - 1, "L");//left
                GetPath(row, col + 1, "R");//right
                Unmarck(row, col);
            }
            path.RemoveAt(path.Count - 1);
        }

        private static bool Unmarck(int row, int col)
        {
            return visited[row, col] = false;
        }

        private static bool Marck(int row, int col)
        {
            return visited[row, col] = true;
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsExit(int row, int col)
        {
            return matrix[row, col] == 'e';
        }

        private static bool IsValid(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }
    }
}
