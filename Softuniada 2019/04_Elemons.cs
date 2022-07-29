namespace Algorithms
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        private static string[,,] matrix;
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            matrix = new string[n, n, n];

            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                for (int layer = 0; layer < n; layer++)
                {
                    var token = line[layer].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int column = 0; column < n; column++)
                    {
                        matrix[layer, row, column] = token[column];
                    }
                }
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Melolemonmelon")
            {
                var args = input.Split().Select(int.Parse).ToArray();

                var layer = args[0];
                var row = args[1];
                var col = args[2];

                matrix[layer, row, col] = "0";

                for (int l = 0; l < matrix.GetLength(0); l++)
                {
                    for (int r = 0; r < matrix.GetLength(1); r++)
                    {
                        for (int c = 0; c < matrix.GetLength(2); c++)
                        {
                            if (matrix[l, r, c] == "0")
                            {
                                continue;
                            }

                            if ((ValidIndex(layer - 1, r, c) && l == layer - 1 && r == row && c == col)
                                || (ValidIndex(layer + 1, r, c) && l == layer + 1 && r == row && c == col)
                                || (ValidIndex(l, row - 1, c) && l == layer && r == row - 1 && c == col)
                                || (ValidIndex(l, row + 1, c) && l == layer && r == row + 1 && c == col)
                                || (ValidIndex(l, r, col - 1) && l == layer && r == row && c == col - 1)
                                || (ValidIndex(l, r, col + 1) && l == layer && r == row && c == col + 1))
                            {
                                continue;
                            }

                            var character = matrix[l, r, c];

                            if (character == "W")
                            {
                                matrix[l, r, c] = "E";
                            }
                            else if (character == "E")
                            {
                                matrix[l, r, c] = "F";
                            }
                            else if (character == "F")
                            {
                                matrix[l, r, c] = "A";
                            }
                            else if (character == "A")
                            {
                                matrix[l, r, c] = "W";
                            }
                        }
                    }
                }
            }

            for (int r = 0; r < matrix.GetLength(1); r++)
            {
                for (int l = 0; l < matrix.GetLength(0); l++)
                {
                    for (int c = 0; c < matrix.GetLength(2); c++)
                    {
                        Console.Write(matrix[l, r, c] + " ");
                    }

                    if (l != matrix.GetLength(0) - 1)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static bool ValidIndex(int layer, int row, int col)
        {
            return layer >= 0 && layer < matrix.GetLength(0)
                   && row >= 0 && row < matrix.GetLength(1)
                   && col >= 0 && col < matrix.GetLength(2);
        }
    }
}