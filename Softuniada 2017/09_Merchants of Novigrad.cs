//33/100 time limit

namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static int modulo;
        private static Dictionary<int, int> dependencies = new Dictionary<int, int>();
        private static List<int> possibleNodes = new List<int>();
        private static HashSet<int> visitedFirstDfs = new HashSet<int>();
        private static string isNotAcyclic;
        private static int problemComesFrom = 0;
        private static int paths = 0;
        static void Main(string[] args)
        {
            Initialize();

            Dfs(1);

            RemoveNotNeeded();

            isNotAcyclic = IsAcyclic() ? "no" : "yes";


            if (problemComesFrom != 0)
            {
                RemoveTheProblem();
            }

            visitedFirstDfs = new HashSet<int>();
            possibleNodes = new List<int>();

            Dfs(1);

            if (possibleNodes.Count <= 1)
            {
                Console.WriteLine("infinite");
                return;
            }

            GetPaths(1, possibleNodes.Max());

            Console.WriteLine($"{paths} {isNotAcyclic}");
        }

        private static void GetPaths(int node, int target)
        {
            if (node == target)
            {
                paths++;
                paths %= modulo;
            }

            foreach (var child in graph[node])
            {
                GetPaths(child, target);
            }
        }

        private static void RemoveTheProblem()
        {
            graph.Remove(problemComesFrom);

            var nodesThatHaveConToTheProblem = new List<int>();

            foreach (var node in graph.Where(x => x.Value.Contains(problemComesFrom)))
            {
                nodesThatHaveConToTheProblem.Add(node.Key);
            }

            foreach (var node in nodesThatHaveConToTheProblem)
            {
                graph[node].Remove(problemComesFrom);
            }
        }

        private static void Initialize()
        {
            var m = Console.ReadLine().Split().Select(int.Parse).ToArray()[1];
            modulo = (int)Math.Pow(10, 9);

            for (int i = 0; i < m; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var node = line[0];
                var child = line[1];

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<int>();
                }

                if (!graph.ContainsKey(child))
                {
                    graph[child] = new List<int>();
                }

                graph[node].Add(child);
            }
        }

        private static void RemoveNotNeeded()
        {
            var unneededList = new List<int>();
            foreach (var unneeded in graph.Keys.Where(x => !possibleNodes.Contains(x)))
            {
                unneededList.Add(unneeded);
            }

            foreach (var unneeded in unneededList)
            {
                graph.Remove(unneeded);
            }
        }

        private static void Dfs(int node)
        {
            if (visitedFirstDfs.Contains(node))
            {
                return;
            }

            visitedFirstDfs.Add(node);
            possibleNodes.Add(node);

            foreach (var child in graph[node])
            {
                Dfs(child);
            }
        }

        private static bool IsAcyclic()
        {
            GetDependencies();

            return GetTop();
        }

        private static bool GetTop()
        {
            var top = new List<int>();

            while (dependencies.Any())
            {
                var node = dependencies.FirstOrDefault(x => x.Value == 0).Key;

                if (node == 0)
                {
                    problemComesFrom = dependencies.First().Key;
                    return false;
                }

                top.Add(node);

                foreach (var child in graph[node])
                {
                    dependencies[child]--;
                }

                dependencies.Remove(node);
            }

            return true;
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
                    }
                    else
                    {
                        dependencies[child]++;
                    }
                }
            }
        }
    }
}