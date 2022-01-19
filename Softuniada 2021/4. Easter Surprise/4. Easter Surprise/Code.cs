namespace ConsoleApp14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Code
    {
        private static char[][] matrix;
        public static void Main()
        {
            int[] sizeInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizeInput[0];
            int cols = sizeInput[1];
            matrix = new char[rows][];
            for (int r = 0; r < rows; r++)
            {
                List<char> list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToList();
                matrix[r] = list.ToArray();
            }
            char symbolFound = char.Parse(Console.ReadLine());
            int[] toFindInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = toFindInput[0];
            int col = toFindInput[1];
            char symbol = matrix[row][col];
            matrix[row][col] = symbolFound;
            FindPath(row, col, symbolFound, symbol);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }
        public static void FindPath(int row, int col, char symbolToReplaceWith, char validSymbol)
        {
            if (col + 1 < matrix[row].Length && matrix[row][col + 1] == validSymbol)
            {
                matrix[row][col + 1] = symbolToReplaceWith;
                FindPath(row, col + 1, symbolToReplaceWith, validSymbol);
            }
            if (col - 1 >= 0 && matrix[row][col - 1] == validSymbol)
            {
                matrix[row][col - 1] = symbolToReplaceWith;
                FindPath(row, col - 1, symbolToReplaceWith, validSymbol);
            }
            if (row - 1 >= 0 && matrix[row - 1][col] == validSymbol)
            {
                matrix[row - 1][col] = symbolToReplaceWith;
                FindPath(row - 1, col, symbolToReplaceWith, validSymbol);
            }
            if (row + 1 < matrix.GetLength(0) && matrix[row + 1][col] == validSymbol)
            {
                matrix[row + 1][col] = symbolToReplaceWith;
                FindPath(row + 1, col, symbolToReplaceWith, validSymbol);
            }
        }
    }
}