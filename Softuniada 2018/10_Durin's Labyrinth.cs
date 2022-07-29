// 50/100 time limit 

namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        private static List<int>[] graph;
        private static List<int> path = new List<int>();
        private static Dictionary<int, Tuple<int, int>> timesInThePaths = new Dictionary<int, Tuple<int, int>>();
        private static HashSet<int> visited = new HashSet<int>();
        private static int paths = 0;
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var M = int.Parse(Console.ReadLine());

            graph = new List<int>[N];

            for (int i = 0; i < N; i++)
            {
                graph[i] = new List<int>();
            }

            for (int n = 0; n < M; n++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var node = line[0];
                var child = line[1];

                graph[node].Add(child);
                graph[child].Add(node);
            }

            for (int i = 0; i < N; i++)
            {
                timesInThePaths[i] = Tuple.Create(0, 0);
            }

            Dfs(0);

            var nodes = timesInThePaths
                .Where(x => x.Value.Item1 == paths && x.Key != 0 && x.Key != graph.Length - 1)
                .OrderBy(x => x.Value.Item2)
                .Select(x => x.Key).ToArray();

            Console.WriteLine(nodes.Sum());

            foreach (var node in nodes)
            {
                if (node == nodes.Last())
                {
                    Console.Write(node);
                }
                else
                {
                    Console.Write($"{node}->");
                }
            }
        }

        private static void Dfs(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            path.Add(node);

            if (node == graph.Length - 1)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    timesInThePaths[path[i]] = Tuple.Create(timesInThePaths[path[i]].Item1 + 1, i);
                }

                paths++;
            }

            foreach (var child in graph[node])
            {
                Dfs(child);
            }

            path.RemoveAt(path.Count - 1);
            visited.Remove(node);
        }
    }
}