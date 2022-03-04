namespace ConsoleApp9
{
    using System;
    using System.Collections.Generic;
    class Code
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            List<int> prime = new List<int>();
            for (int i = start; i <= end; i++)
            {
                int count = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        count++;
                    }
                }
                if (count <= 2 && i != 1)
                {
                    prime.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", prime));
            Console.WriteLine($"The total number of prime numbers between {start} to {end} is {prime.Count}");
        }
    }
}