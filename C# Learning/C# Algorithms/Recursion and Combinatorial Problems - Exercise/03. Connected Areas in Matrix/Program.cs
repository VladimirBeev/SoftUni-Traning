using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Connected_Areas_in_Matrix
{
    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }

    }
    public class Program
    {
        private const char VisitedSymbol = 'v';
        private static char[,] matrix;
        private static int size;
        static void Main()
        {
            int roww = int.Parse(Console.ReadLine());
            int coll = int.Parse(Console.ReadLine());
            matrix = new char[roww, coll];
            for (int row = 0; row < roww; row++)
            {
                var elements = Console.ReadLine();
                for (int col = 0; col < coll; col++)
                {
                    matrix[row,col] = elements[col];
                }
            }
            var areas = new List<Area>();
            for (int row = 0; row < roww; row++)
            {
                for (int col = 0; col < coll; col++)
                {
                    size = 0;
                    ExploreArea(row, col);
                    if (size != 0)
                    {
                        areas.Add(new Area { Row = row, Col = col, Size = size });
                    }
                }
            }
            var sorted = areas
                .OrderByDescending(x => x.Size)
                .ThenBy(x=> x.Row)
                .ThenBy(x=>x.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < sorted.Count; i++)
            {
                var area = sorted[i];
                Console.WriteLine($"Area #{i+1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row,col) || IsWall(row,col) || IaVisited(row,col))
            {
                return;
            }
            size += 1;
            matrix[row, col] = VisitedSymbol;
            ExploreArea(row-1,col);
            ExploreArea(row+1,col);
            ExploreArea(row, col - 1);
            ExploreArea(row,col + 1);
        }

        private static bool IaVisited(int row, int col)
        {
            return matrix[row, col] == VisitedSymbol;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(int row, int col)
        {
            return row< 0 || col< 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        }
    }
}
