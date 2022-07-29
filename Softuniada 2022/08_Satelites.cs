// 80/100

namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static List<Edge> edges = new List<Edge>();
        private static Dictionary<string, int> dependencies = new Dictionary<string, int>();
        private static Dictionary<string, int> nexuses = new Dictionary<string, int>();
        private static HashSet<string> DfsVisited = new HashSet<string>();
        static void Main(string[] args)
        {
            Initialize();

            GetDependencies();

            GetAllNexuses();

            Print();
        }

        private static void Print()
        {
            var start = nexuses.OrderBy(x => x.Value).FirstOrDefault().Key;

            if (start == null)
            {
                return;
            }

            BfsPrint(start);
        }

        private static void BfsPrint(string start)
        {
            DfsOrder(start);

            foreach (var node in DfsVisited.OrderBy(x => x))
            {
                foreach (var child in graph[node].OrderBy(x => x))
                {
                    Console.WriteLine($"{node} <-> {child}");
                }
            }
        }

        private static void DfsOrder(string node)
        {
            if (DfsVisited.Contains(node))
            {
                return;
            }

            DfsVisited.Add(node);

            foreach (var child in graph[node])
            {
                DfsOrder(child);
            }
        }

        private static void GetAllNexuses()
        {
            foreach (var node in dependencies.OrderBy(x => x.Key))
            {
                var toRemove = new List<string>();
                var start = graph[node.Key].OrderBy(x => x).FirstOrDefault();

                if (start == null)
                {
                    continue;
                }

                foreach (var child in graph[node.Key])
                {
                    toRemove.Add($"{node.Key}-{child}");
                }

                foreach (var item in toRemove)
                {
                    var split = item.Split('-');

                    graph[split[0]].Remove(split[1]);
                    graph[split[1]].Remove(split[0]);
                }

                var target = dependencies[node.Key] + 1;
                var res = Bfs(start) + 1;

                foreach (var item in toRemove)
                {
                    var split = item.Split('-');

                    graph[split[0]].Add(split[1]);
                    graph[split[1]].Add(split[0]);
                }

                if (res == target)
                {
                    nexuses[node.Key] = res;
                }
            }
        }

        private static int Bfs(string start)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            var visited = new HashSet<string>();
            visited.Add(start);

            var count = 0;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                count++;

                if (graph[node].Count != 2)
                {
                    return -1;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return count;
        }

        private static void GetDependencies()
        {
            foreach (var node in graph.Keys)
            {
                if (!dependencies.ContainsKey(node))
                {
                    dependencies[node] = 0;
                }
                foreach (var child in graph[node])
                {
                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies[child] = 1;
                        continue;
                    }

                    dependencies[child]++;
                }
            }
        }

        private static void Initialize()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                var node = line[0];
                var child = line[1];

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<string>();
                }
                if (!graph.ContainsKey(child))
                {
                    graph[child] = new List<string>();
                }

                graph[node].Add(child);
                graph[child].Add(node);

                edges.Add(new Edge(node, child));
                edges.Add(new Edge(child, node));
            }
        }
        public class Edge
        {
            public Edge(string from, string to)
            {
                From = from;
                To = to;
            }

            public string From { get; set; }
            public string To { get; set; }
        }
    }
}