namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int label = 1;
        private static int[] labels;
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var logsCount = input[0];
            var tests = input[1];

            var logs = new List<Log>();

            graph = new List<int>[logsCount + 1];

            for (int i = 0; i <= logsCount; i++)
            {
                graph[i] = new List<int>();
            }

            for (int l = 1; l <= logsCount; l++)
            {
                var arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var newLog = new Log(l, arguments[0], arguments[2], arguments[1], arguments[3]);

                foreach (var log in logs)
                {
                    if (newLog.Cross(log))
                    {
                        graph[l].Add(log.Id);
                        graph[log.Id].Add(l);
                    }
                }

                logs.Add(newLog);
            }

            visited = new bool[logsCount + 1];
            labels = new int[logsCount + 1];

            for (int i = 1; i <= logsCount; i++)
            {
                if (!visited[i])
                {
                    Dfs(i);
                    label++;
                }
            }

            for (int i = 0; i < tests; i++)
            {
                var inp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var start = inp[0];
                var target = inp[1];

                Console.WriteLine(labels[start] == labels[target] ? "YES" : "NO");
            }
        }

        private static void Dfs(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;
            labels[node] = label;


            foreach (var child in graph[node])
            {
                Dfs(child);
            }
        }
    }

    class Log
    {
        public Log(int id, int x1, int x2, int y1, int y2)
        {
            Id = id;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public int Id { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public bool Cross(Log log) // Check if two figures in a coordinate system are crossing
        {
            var line = this.X1 <= log.X2 && this.X2 >= log.X1;
            var down = this.Y1 >= log.Y2 && log.Y1 >= this.Y2;

            return line && down;
        }
    }
}