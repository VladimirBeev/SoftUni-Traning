using System;
using System.Collections.Generic;

namespace _04._Salaries
{
    public class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visided;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visided = new Dictionary<int, int>();
            for (int node = 0; node < n; node++)
            {
                graph[node] = new List<int>();
                var elements = Console.ReadLine();
                for (int child = 0; child < elements.Length; child++)
                {
                    if (elements[child] == 'Y')
                    {
                        graph[node].Add(child);
                    }
                }
            }

            var salary = 0;
            for (int node = 0;node < graph.Length; node++)
            {
                salary += DFS(node);
            }
            Console.WriteLine(salary);
        }

        private static int DFS(int node)
        {
            if (visided.ContainsKey(node))
            {
                return visided[node];
            }

            var salary = 0;

            if (graph[node].Count == 0)
            {
                return 1;
            }
            else
            {
                foreach(var child in graph[node])
                {
                    salary += DFS(child);
                }
            }
            visided[node] = salary;
            return salary;
        }
    }
}
