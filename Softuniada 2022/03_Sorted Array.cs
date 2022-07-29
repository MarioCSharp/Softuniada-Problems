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
            int[] arr = Console.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
                else
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}