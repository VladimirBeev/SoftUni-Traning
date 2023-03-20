using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Break_Cycles
{
    public class Edge
    {
        public string First { get; set; }
        public string Second { get; set; }
    }
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;
        static void Main()
        {
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] nodeAndChildren = Console.ReadLine().Split(" -> ").ToArray();
                var node = nodeAndChildren[0];
                var childs = nodeAndChildren[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<string>();
                }
                graph[node].AddRange(childs);
                foreach (var child in childs)
                {
                    edges.Add(new Edge { First = node, Second = child });
                }
            }

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second).ToList();

            var removedEdges = new List<Edge>();
            foreach (var edge in edges)
            {
                var removed = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);
                if (!removed)
                {
                    continue;
                }
                if (BFS(edge.First, edge.Second))
                {
                    removedEdges.Add(edge);
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);

                }
            }
            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static bool BFS(string first, string second)
        {
            var queue = new Queue<string>();
            var vissited = new HashSet<string>();
            queue.Enqueue(first);
            vissited.Add(first);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == second)
                {
                    return true;
                }
                foreach (var child in graph[node])
                {
                    if (vissited.Contains(child))
                    {
                        continue;
                    }
                    vissited.Add(child);
                    queue.Enqueue(child);
                }
            }
            return false;
        }
    }
}
