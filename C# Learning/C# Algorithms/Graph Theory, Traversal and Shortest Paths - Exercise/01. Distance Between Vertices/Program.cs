using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var numberForPair = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < nodes; i++)
            {
                var nodeAndChildren = Console.ReadLine().Split(":",StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(nodeAndChildren[0]);
                if (nodeAndChildren.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    graph[node] = new List<int>();
                    var children = nodeAndChildren[1].Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    graph[node].AddRange(children);
                }
            }
            for (int i = 0; i < numberForPair; i++)
            {
                var startNodeAndEndNode = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var start = startNodeAndEndNode[0];
                var destination = startNodeAndEndNode[1];

                var steps = BFC(start,destination);
                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }
        }

        private static int BFC(int start, int destination)
        {
            var queue = new Queue<int>();
            var vissited = new HashSet<int>();
            var parent = new Dictionary<int, int>();

            queue.Enqueue(start);
            vissited.Add(start);
            parent.Add(start, -1);

            while (queue.Count > 0)
            {
               var node = queue.Dequeue();
                if (node == destination)
                {
                    return GetStrps(parent,destination);
                }
                foreach (var child in graph[node])
                {
                    if (vissited.Contains(child))
                    {
                        continue;
                    }

                    vissited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = node;
                }

            }
            return -1;
        }

        private static int GetStrps(Dictionary<int, int> parent, int destination)
        {
            var node = destination;
            var steps = 0;

            while (node != -1)
            {
                node = parent[node];
                steps+=1;
            }
            return steps-1;
        }
    }
}
