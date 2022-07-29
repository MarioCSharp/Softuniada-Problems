namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        private static char[,,] field;
        private static int applesEated;
        private static string currentWay;
        private static string nextWay;
        private static int currentSteps;
        private static int snakeLayer;
        private static int snakeRow;
        private static int snakeCol;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            field = new char[n, n, n];
            for (int row = 0; row < n; row++)
            {
                var arrInput = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (int layer = 0; layer < n; layer++)
                {
                    char[] token = arrInput[layer].Trim().ToCharArray();
                    for (int column = 0; column < n; column++)
                    {
                        field[layer, row, column] = char.Parse(token[column].ToString());
                        if (field[layer, row, column] == 's')
                        {
                            snakeRow = row;
                            snakeCol = column;
                            snakeLayer = layer;
                        }
                    }
                }
            }
            string direction = Console.ReadLine();
            currentWay = direction;
            while (true)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                nextWay = input[0];
                currentSteps = int.Parse(input[2]);
                Solve();
                if (input[0] == "end")
                {
                    break;
                }
                currentWay = nextWay;
            }
            Console.WriteLine($"Points collected: {applesEated}");
        }
        public static void Solve()
        {
            field[snakeLayer, snakeRow, snakeCol] = 'o';
            for (int i = 0; i < currentSteps; i++)
            {
                Check();
            }
            field[snakeLayer, snakeRow, snakeCol] = 's';
        }
        public static void End()
        {
            Console.WriteLine($"Points collected: {applesEated}");
            Console.WriteLine("The snake dies.");
            Environment.Exit(0);
        }
        public static void Check()
        {
            if (currentWay == "down" && snakeLayer + 1 < field.GetLength(0))
            {
                snakeLayer++;
            }
            else if (currentWay == "down")
            {
                End();
            }
            else if (currentWay == "backward" && snakeRow + 1 < field.GetLength(1))
            {
                snakeRow++;
            }
            else if (currentWay == "backward")
            {
                End();
            }
            else if (currentWay == "forward" && snakeRow - 1 >= 0)
            {
                snakeRow--;
            }
            else if (currentWay == "forward")
            {
                End();
            }
            else if (currentWay == "up" && snakeLayer - 1 >= 0)
            {
                snakeLayer--;
            }
            else if (currentWay == "up")
            {
                End();
            }
            else if (currentWay == "left" && snakeCol - 1 >= 0)
            {
                snakeCol--;
            }
            else if (currentWay == "left")
            {
                End();
            }
            else if (currentWay == "right" && snakeCol + 1 < field.GetLength(2))
            {
                snakeCol++;
            }
            else if (currentWay == "right")
            {
                End();
            }
            if (field[snakeLayer, snakeRow, snakeCol] == 'a')
            {
                applesEated++;
                field[snakeLayer, snakeRow, snakeCol] = 'o';
            }
        }
    }
}