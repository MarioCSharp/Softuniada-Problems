namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static char[][] matrix;
        private static int currentRow = 0;
        private static int currentColumn = 0;
        private static int count = 0;
        private static int startRow = 0;
        private static int startCol = 0;
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rows = line[0];
            var cols = line[1];

            currentRow = rows - 1;

            matrix = new char[rows][];

            for (int i = 0; i < cols; i++)
            {
                matrix[i] = new char[cols];
            }

            for (int r = 0; r < rows; r++)
            {
                var input = Console.ReadLine().Trim().ToCharArray();

                if (input.Contains('S'))
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 'S')
                        {
                            currentColumn = i;
                            break;
                        }
                    }
                }

                matrix[r] = input;
            }

            startRow = currentRow;
            startCol = currentColumn;

            var c = int.Parse(Console.ReadLine());

            var won = false;

            for (int i = 0; i <= c; i++)
            {
                if (currentRow == 0)
                {
                    won = true;
                    break;
                }
                else if (i == c)
                {
                    break;
                }

                var inp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var row = inp[0];
                var rot = inp[1];

                RotateRow(row, rot);

                if (matrix[currentRow - 1][currentColumn] == '-')
                {
                    matrix[currentRow][currentColumn] = '-';
                    matrix[--currentRow][currentColumn] = 'S';
                    count++;
                    matrix[startRow][startCol] = '0';
                }
            }

            Console.WriteLine(won ? "Win" : "Lose");
            Console.WriteLine($"Total Jumps: {count}");

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(string.Empty, matrix[i]));
            }
        }

        private static void RotateRow(int row, int rot)
        {
            var indecies = new List<int>();

            for (int i = 0; i < matrix[row].Length; i++)
            {
                if (matrix[row][i] == '-')
                {
                    indecies.Add(i);
                    matrix[row][i] = '0';
                }
            }

            var len = matrix[row].Length;

            indecies = indecies.Select(x => x += rot).ToList();

            for (int i = 0; i < indecies.Count; i++)
            {
                if (indecies[i] >= len)
                {
                    indecies[i] = Math.Abs(len - indecies[i]);
                    i--;
                }
            }

            for (int i = 0; i < indecies.Count; i++)
            {
                matrix[row][indecies[i]] = '-';
            }

            if (currentRow == row)
            {
                currentColumn += rot;

                if (currentColumn > len)
                {
                    currentColumn = len - currentColumn;
                }

                matrix[currentRow][currentColumn] = 'S';
            }
        }
    }
}