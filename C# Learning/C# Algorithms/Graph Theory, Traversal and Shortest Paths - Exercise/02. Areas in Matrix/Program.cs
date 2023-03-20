using System;
using System.Collections.Generic;

namespace _02._Areas_in_Matrix
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int r = 0; r < rows; r++)
            {
                var elements = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    graph[r, c] = elements[c];
                }
            }
            var areaCounter = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }
                    
                    var charElement = graph[r, c];
                    DFS(r, c, charElement);

                    areaCounter += 1;
                    if (areas.ContainsKey(charElement))
                    {
                        areas[charElement] += 1;
                    }
                    else
                        areas[charElement] = 1;
                }
            }
            Console.WriteLine($"Areas: {areaCounter}");
            foreach (var element in areas)
            {
                Console.WriteLine($"Letter '{element.Key}' -> {element.Value}");
            }
        }

        private static void DFS(int r, int c, char charElement)
        {
            if (r < 0 || c < 0 || r >= graph.GetLength(0) || c >= graph.GetLength(1))
            {
                return;
            }
            if (visited[r, c])
            {
                return;
            }
            
            if (graph[r, c] != charElement)
            {
                return;
            }

            visited[r, c] = true;
            DFS(r + 1, c, charElement);
            DFS(r - 1, c, charElement);
            DFS(r, c + 1, charElement);
            DFS(r, c - 1, charElement);
        }
    }
}
