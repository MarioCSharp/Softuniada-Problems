namespace SoftUniada
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string word = Console.ReadLine();
            int width = 3 * n + 6;
            int height = 3 * n + 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string(' ', n) + "~ ~ ~");
            }
            Console.WriteLine(new string('=', width - 1));
            int middle = n / 2;
            int formula = (width - 3) - (n - 1) - word.Length;
            for (int i = 1; i <= n - 2; i++)
            {
                if (i == middle)
                {
                    Console.WriteLine("|" + new string('~', n) + word.ToUpper() + new string('~', n) + "|" + new string(' ', n - 1) + "|");
                }
                else
                {
                    Console.WriteLine("|" + new string('~', n * 2 + 4)+ "|" + new string(' ', n - 1) + "|");
                }
            }
            Console.WriteLine(new string('=', width - 1));
            int newWidth = n * 2 + 6;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string(' ', i) + "\\" + new string('@', newWidth - 2 * i - 2) + "/");
            }
            Console.WriteLine(new string('-', width - 1));
        }
    }
}