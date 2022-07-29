namespace Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        private static int[,] matrix;
        private static bool[,] visited;
        private static Dictionary<int, int> result;
        private static int areaSize;
        static void Main(string[] args)
        {
            var size = string.Empty;

            while ((size = Console.ReadLine()) != "end")
            {
                var split = size.Split('x');
                var rows = int.Parse(split[0]);
                var cols = int.Parse(split[1]);

                matrix = new int[rows, cols];
                visited = new bool[rows, cols];
                result = new Dictionary<int, int>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    var input = Console.ReadLine().ToCharArray();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = int.Parse(input[col].ToString());
                    }
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (visited[row, col] || matrix[row, col] != 1)
                        {
                            continue;
                        }
                        areaSize = 0;
                        DFS(row, col);
                        if (!result.ContainsKey(areaSize))
                        {
                            result[areaSize] = 1;
                        }
                        else
                        {
                            result[areaSize]++;
                        }
                    }
                }   
                foreach (var item in result.OrderByDescending(x => x.Key))
                {
                    Console.WriteLine($"{item.Value}x{item.Key}");
                }
                Console.WriteLine($"Total: {result.Sum(x => x.Value)}");
            }
        }
        private static void DFS(int row, int col)
        {
            if (!ValidIndex(row, col) || visited[row, col] || matrix[row, col] != 1)
            {
                return;
            }

            visited[row, col] = true;
            areaSize++;

            DFS(row, col + 1);
            DFS(row, col - 1);
            DFS(row + 1, col);
            DFS(row - 1, col);
        }
        private static bool ValidIndex(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}