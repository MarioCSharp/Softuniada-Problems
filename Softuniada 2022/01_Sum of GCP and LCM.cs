namespace SoftUniada
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int sum = 0;
            int k = 0;
            if (numTwo > numOne)
            {
                k = numTwo;
            }
            else
            {
                k = numOne;
            }
            while (true)
            {
                if (numTwo % k == 0 && numOne % k == 0)
                {
                    sum += k;
                    break;
                }
                else
                {
                    k--;
                }
            }
            int j = 1;
            while (true)
            {
                if (j % numOne == 0 && j % numTwo == 0)
                {
                    sum += j;
                    break;
                }
                else
                {
                    j++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}