namespace Softuniada
{
    public class Program
    {
        private static List<int> spanningTree = new List<int>();
        private static HashSet<Edge> graph = new HashSet<Edge>();
        private static int[] parents;
        static void Main(string[] args)
        {
            var v = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            parents = new int[v + 1];

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }

            for (int i = 0; i < e; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var first = input[0];
                var second = input[1];
                var weight = input[2];

                var edge = new Edge(first, second, weight);

                graph.Add(edge);
            }

            Console.WriteLine(Kruskal());
        }
        private static int Kruskal()
        {
            var edges = graph.OrderBy(x => x.Weight).ToList();

            var max = int.MinValue;

            while (edges.Count != 0)
            {
                var edge = edges.First();
                edges.Remove(edge);

                var firstNode = edge.First;
                var secondNode = edge.Second;

                var firstRoot = FindRoot(firstNode);
                var secondRoot = FindRoot(secondNode);

                if (firstRoot != secondRoot)
                {
                    parents[firstRoot] = secondRoot;

                    if (edge.Weight > max)
                    {
                        max = edge.Weight;
                    }
                }
            }

            return max + 1;
        }

        private static int FindRoot(int node)
        {
            while (parents[node] != node)
            {
                node = parents[node];
            }

            return node;
        }
    }

    class Edge
    {
        public Edge(int first, int second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }

        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }
}
