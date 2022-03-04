namespace ConsoleApp14
{
    using System;
    class Code
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int minus = 0;
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < minus; k++)
                {
                    Console.Write(" ");
                }
                for (int i = 1; i <= n - minus; i++)
                {
                    Console.Write(i);
                }
                minus++;
                for (int i = n - minus; i >= 1; i--)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
        }
    }
}