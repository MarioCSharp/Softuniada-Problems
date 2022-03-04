namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Draw(n * 5, n * 2 + 3, n);
        }
        static void Draw(int width, int height, int n)
        {
            Console.WriteLine(new string('.', n * 2) + new string('*', width - n * 4) + new string('.', n * 2));
            int dots = n * 2 - 2;
            int stars = 1;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('.', dots) + new string('*', stars) + new string('+', width - stars * 2 - dots * 2) + new string('*', stars) + new string('.', dots));
                dots -= 2;
                stars++;
            }
            stars = 2;
            dots = n - 1;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('.', dots) + new string('*', stars) + new string('=', width - stars * 2 - dots * 2) + new string('*', stars) + new string('.', dots));
                dots--;
            }
            dots = n / 2;
            Console.WriteLine(new string('.', dots) + new string('*', stars) + new string('~', (width - dots * 2 - stars * 2 - 12) / 2) + "HAPPY EASTER" + new string('~', (width - dots * 2 - stars * 2 - 12) / 2) + new string('*', stars) + new string('.', dots));
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('.', dots) + new string('*', stars) + new string('=', width - stars * 2 - dots * 2) + new string('*', stars) + new string('.', dots));
                dots++;
            }
            dots = n;
            stars = n / 2;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('.', dots) + new string('*', stars) + new string('+', width - stars * 2 - dots * 2) + new string('*', stars) + new string('.', dots));
                dots += 2;
                stars--;
            }
            Console.WriteLine(new string('.', n * 2) + new string('*', width - n * 4) + new string('.', n * 2));
        }
    }
}