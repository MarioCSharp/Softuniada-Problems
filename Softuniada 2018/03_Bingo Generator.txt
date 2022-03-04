namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int first = int.Parse((num[0].ToString() + num[2].ToString()).ToString());
            int second = int.Parse((num[1].ToString() + num[3].ToString()).ToString());
            int max = first + second;
            int start = int.Parse(((num[0].ToString() + num[2].ToString()) + (num[1].ToString() + num[3].ToString())).ToString());
            int numToInt = int.Parse(num);
            var twelve = new List<int>();
            var fifteen = new List<int>();
            int final = int.Parse(max.ToString() + max.ToString());
            for (int i = start; i <= final; i++)
            {
                string iToString = i.ToString();
                string firstPart = iToString[0].ToString() + iToString[1].ToString();
                string secondPart = iToString[2].ToString() + iToString[3].ToString();
                if (i % 12 == 0 && int.Parse(firstPart) <= max && int.Parse(secondPart) <= max && int.Parse(secondPart) >= second)
                {
                    twelve.Add(i);
                }
                if (i % 15 == 0 && int.Parse(firstPart) <= max && int.Parse(secondPart) <= max && int.Parse(secondPart) >= second)
                {
                    fifteen.Add(i);
                }
            }
            Console.WriteLine("Dividing on 12: " + string.Join(" ", twelve));
            Console.WriteLine("Dividing on 15: " + string.Join(" ", fifteen));
            if (twelve.Count != fifteen.Count)
            {
                Console.WriteLine("NO BINGO!");
                return;
            }
            Console.WriteLine("!!!BINGO!!!");
        }
    }
}