namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            var list = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                list.Add(word[i]);
            }
            int count = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    list.RemoveAt(i);
                    list.RemoveAt(i);
                    i = -1;
                    count++;
                    continue;
                }
            }
            Console.WriteLine((list.Count == 0) ? "Empty String" : string.Join("", list));
            Console.WriteLine($"{count} operations");
        }
    }
}