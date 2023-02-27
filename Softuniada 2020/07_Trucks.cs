namespace AlgorithmsNetCore6
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Program
    {
        private static Dictionary<string, List<Edge>> graph = new Dictionary<string, List<Edge>>();
        private static Dictionary<string, string> parent = new Dictionary<string, string>();
        static void Main()
        {
            var source = Console.ReadLine();
            var target = Console.ReadLine();

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine().Split().ToArray();

                var first = line[0];
                var second = line[1];
                var currentFlow = int.Parse(line[2]);

                var edge = new Edge(first, second, currentFlow);

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<Edge>();
                }

                if (!graph.ContainsKey(second))
                {
                    graph[second] = new List<Edge>();
                }

                graph[first].Add(edge);
            }

            foreach (var node in graph.Keys)
            {
                parent[node] = node;
            }

            var flow = 0;

            while (BFS(source, target))
            {
                var minFlow = GetMinFlow(target);

                ApplyFlow(target, minFlow);

                flow += minFlow;
            }

            Console.WriteLine(flow);
        }

        private static void ApplyFlow(string node, int minFlow)
        {
            while (parent[node] != node)
            {
                var prev = parent[node];

                graph[prev].First(x => x.Second == node).LeftFlow -= minFlow;

                node = prev;
            }
        }

        private static int GetMinFlow(string node)
        {
            var min = int.MaxValue;

            while (parent[node] != node)
            {
                var prev = parent[node];

                var flow = graph[prev].First(x => x.Second == node).LeftFlow;

                if (flow < min)
                {
                    min = flow;
                }

                node = prev;
            }

            return min;
        }

        private static bool BFS(string source, string target)
        {
            var visited = new HashSet<string>();
            visited.Add(source);

            var queue = new Queue<string>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var edge in graph[node])
                {
                    var other = edge.First == node ? edge.Second : edge.First;

                    if (!visited.Contains(other) && graph[node].First(x => x.Second == other).LeftFlow > 0)
                    {
                        visited.Add(other);
                        queue.Enqueue(other);
                        parent[other] = node;
                    }
                }
            }

            return visited.Contains(target);
        }
    }

    public class Edge
    {
        public Edge(string first, string second, int leftFlow)
        {
            First = first;
            Second = second;
            LeftFlow = leftFlow;
        }

        public string First { get; set; }
        public string Second { get; set; }
        public int LeftFlow { get; set; }
    }
}