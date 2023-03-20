using System;
using System.Collections.Generic;

namespace _03._Cycles_in_Graph
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cyclic;
        static void Main()
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cyclic = new HashSet<string>();
            var command = Console.ReadLine();
            while (command != "End")
            {
                var action = command.Split("-");
                var elementFirst = action[0];
                var elementSecond = action[1];

                if (!graph.ContainsKey(elementFirst))
                {
                    graph[elementFirst] = new List<string>();
                }
                if (!graph.ContainsKey(elementSecond))
                {
                    graph[elementSecond] = new List<string>();
                }

                graph[elementFirst].Add(elementSecond);
                command = Console.ReadLine();
            }
            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }
                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {

                Console.WriteLine("Acyclic: No");
            }
        }

        private static void DFS(string node)
        {
            if (cyclic.Contains(node))
            {
                throw new InvalidOperationException();
            }
            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            cyclic.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            cyclic.Remove(node);

        }
    }
}
