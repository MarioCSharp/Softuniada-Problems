namespace ConsoleApp9
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = n * 5;
            int height = n * 4 + 2;
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string(' ', n));
                Console.Write(new string('#', n * 3));
                Console.Write(new string(' ', n));
                Console.WriteLine();
            }
            Console.Write(new string('#', n));
            Console.Write(new string(' ', width - n * 2));
            Console.Write(new string('#', n));
            Console.WriteLine();
            for (int i = 0; i < n * 2 - 1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(new string('#', n));
                    for (int j = 0; j < n * 3 / 2; j++)
                    {
                        Console.Write(' ');
                        Console.Write('#');
                    }
                    Console.Write(' ');
                    Console.Write(new string('#', n));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(new string('#', n));
                    Console.Write(new string(' ', 2));
                    for (int j = 0; j < n * 3 / 2 - 1; j++)
                    {
                        Console.Write('#');
                        Console.Write(' ');
                    }
                    Console.Write(' ');
                    Console.Write(new string('#', n));
                    Console.WriteLine();
                }
            }
            Console.Write(new string('#', n));
            Console.Write(new string(' ', width - n * 2));
            Console.Write(new string('#', n));
            Console.WriteLine();
            Console.Write(new string('#', width));
            Console.WriteLine();
            for (int i = 0; i < n + 1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(new string('#', n));
                    for (int j = 0; j < n * 3 / 2; j++)
                    {
                        Console.Write(' ');
                        Console.Write('#');
                    }
                    Console.Write(' ');
                    Console.Write(new string('#', n));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(new string('#', width));
                    Console.WriteLine();
                }
            }
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string(' ', n));
                Console.Write(new string('#', n * 3));
                Console.Write(new string(' ', n));
                Console.WriteLine();
            }
        }
    }
}