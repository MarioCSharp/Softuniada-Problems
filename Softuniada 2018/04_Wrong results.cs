namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        private static int[,,] matrix;
        private static int wrongResult;
        private static bool[,,] wasWrong;
        private static int count;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Initialize(size);
            int[] inputCordinates = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int layer = inputCordinates[0];
            int row = inputCordinates[1];
            int col = inputCordinates[2];
            wrongResult = matrix[layer, row, col];
            Solve();
            Print();
        }
        static void Print()
        {
            Console.WriteLine($"Wrong values found and replaced: {count}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                    {
                        Console.Write(matrix[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        private static void Solve()
        {
            for (int layer = 0; layer < matrix.GetLength(0); layer++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[layer, row, col] == wrongResult)
                        {
                            matrix[layer, row, col] = 0;
                            wasWrong[layer, row, col] = true;
                            if (layer + 1 < matrix.GetLength(0) && matrix[layer + 1, row, col] != wrongResult && !wasWrong[layer + 1, row, col])
                            {
                                matrix[layer, row, col] += matrix[layer + 1, row, col];
                            }
                            if (layer - 1 >= 0 && matrix[layer - 1, row, col] != wrongResult && !wasWrong[layer - 1, row, col])
                            {
                                matrix[layer, row, col] += matrix[layer - 1, row, col];
                            }
                            if (row + 1 < matrix.GetLength(1) && matrix[layer, row + 1, col] != wrongResult && !wasWrong[layer, row + 1, col])
                            {
                                matrix[layer, row, col] += matrix[layer, row + 1, col];
                            }
                            if (row - 1 >= 0 && matrix[layer, row - 1, col] != wrongResult && !wasWrong[layer, row - 1, col])
                            {
                                matrix[layer, row, col] += matrix[layer, row - 1, col];
                            }
                            if (col + 1 < matrix.GetLength(2) && matrix[layer, row, col + 1] != wrongResult && !wasWrong[layer, row, col + 1])
                            {
                                matrix[layer, row, col] += matrix[layer, row, col + 1];
                            }
                            if (col - 1 >= 0 && matrix[layer, row, col - 1] != wrongResult && !wasWrong[layer, row, col - 1])
                            {
                                matrix[layer, row, col] += matrix[layer, row, col - 1];
                            }
                            count++;
                        }
                    }
                }
            }
        }
        static void Initialize(int size)
        {
            matrix = new int[size, size, size];
            wasWrong = new bool[size, size, size];
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (int layer = 0; layer < size; layer++)
                {
                    int[] token = input[layer].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    for (int column = 0; column < size; column++)
                    {
                        matrix[layer, row, column] = token[column];
                    }
                }
            }
        }
    }
}