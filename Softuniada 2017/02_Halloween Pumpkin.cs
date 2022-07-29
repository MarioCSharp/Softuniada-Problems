namespace ConsoleApp9
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.Write(new string('.', n - 1));
            Console.Write("_/_");
            Console.Write(new string('.', n - 1));
            Console.WriteLine();
            Console.Write('/');
            Console.Write(new string('.', n - 2));
            Console.Write("^,^");
            Console.Write(new string('.', n - 2));
            Console.Write('\\');
            Console.WriteLine();
            for (int i = 0; i < n - 3; i++)
            {
                Console.Write('|');
                Console.Write(new string('.', n * 2 - 1));
                Console.Write('|');
                Console.WriteLine();
            }
            Console.Write('\\');
            Console.Write(new string('.', n - 2));
            Console.Write("\\_/");
            Console.Write(new string('.', n - 2));
            Console.Write('/');
        }
    }
}