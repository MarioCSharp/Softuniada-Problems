namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var num1 = nums[0];
            var num2 = nums[1];
            var num3 = nums[2];

            if (num1 + num2 + num3 == 13)
                Console.WriteLine("Yes");
            else if (-num1 + num2 + num3 == 13)
                Console.WriteLine("Yes");
            else if (num1 + -num2 + num3 == 13)
                Console.WriteLine("Yes");
            else if (num1 + num2 + -num3 == 13)
                Console.WriteLine("Yes");
            else if (-num1 + -num2 + num3 == 13)
                Console.WriteLine("Yes");
            else if (num1 + -num2 + -num3 == 13)
                Console.WriteLine("Yes");
            else if (-num1 + num2 + -num3 == 13)
                Console.WriteLine("Yes");
            else if (-num1 + -num2 + -num3 == 13)
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}