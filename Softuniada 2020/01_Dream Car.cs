namespace ConsoleApp14
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            decimal startWage = decimal.Parse(Console.ReadLine());
            decimal monthlyR = decimal.Parse(Console.ReadLine());
            decimal increaseWage = decimal.Parse(Console.ReadLine());
            decimal priceOfCar = decimal.Parse(Console.ReadLine());
            decimal months = decimal.Parse(Console.ReadLine());
            decimal final = 0;
            decimal currWage = startWage;
            for (int i = 0; i < months; i++)
            {
                final += currWage;
                final -= monthlyR;
                currWage += increaseWage;
            }
            if (final >= priceOfCar)
            {
                Console.WriteLine("Have a nice ride!");
            }
            else
            {
                Console.WriteLine("Work harder!");
            }
        }
    }
}