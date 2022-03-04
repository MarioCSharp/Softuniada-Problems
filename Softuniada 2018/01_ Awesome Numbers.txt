namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            int count = Count(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            if (count == 0)
            {
                Console.WriteLine("boring");
            }
            else if (count == 1)
            {
                Console.WriteLine("awesome");
            }
            else if (count == 2)
            {
                Console.WriteLine("super awesome");
            }
            else
            {
                Console.WriteLine("super special awesome");
            }
        }
        static int Count(int x, int favNumber)
        {
            int count = 0;
            if (x % favNumber == 0)
            {
                count++;
            }
            if (x % 2 != 0)
            {
                count++;
            }
            if (x < 0)
            {
                count++;
            }
            return count;
        }
    }
}