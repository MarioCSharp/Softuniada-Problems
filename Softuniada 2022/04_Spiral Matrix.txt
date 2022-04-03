namespace Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        private static int[,] matrix;
        private static bool[,] visited;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var cols = int.Parse(Console.ReadLine());   

            matrix = new int[rows, cols];
            visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split().Select(x => x.Trim()).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(input[j].ToString());
                }
            }

            DFS(0, 0);
        }
        private static void DFS(int row, int col)
        {
            if (!ValidIndex(row, col) || visited[row, col])
            {
                return;
            }

            Console.Write(matrix[row, col] + " ");
            visited[row, col] = true;

            if (row - 1 < 0 || visited[row - 1, col])
            {
                DFS(row, col + 1);
            }
            if (col + 1 >= matrix.GetLength(1) || visited[row, col + 1])
            {
                DFS(row + 1, col);
            }
            if (row + 1 <= matrix.GetLength(0) || visited[row + 1, col])
            {
                DFS(row, col - 1);
            }
            if (col - 1 < 0 || visited[row, col - 1])
            {
                DFS(row - 1, col);
            }
        }

        private static bool ValidIndex(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}