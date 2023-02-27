namespace Softuniada
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var matrix = new int[rows, rows];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var newMatrix = RotateMatrixCounterClockwise(matrix);

            for (int row = newMatrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = newMatrix.GetLength(1) - 1; col >= 0; col--)
                {
                    Console.Write(newMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        static int[,] RotateMatrixCounterClockwise(int[,] oldMatrix)
        {
            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];

            int newColumn, newRow = 0;

            for (int col = oldMatrix.GetLength(1) - 1; col >= 0; col--)
            {
                newColumn = 0;

                for (int row = 0; row < oldMatrix.GetLength(0); row++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[row, col];
                    newColumn++;
                }

                newRow++;
            }

            return newMatrix;
        }
    }
}