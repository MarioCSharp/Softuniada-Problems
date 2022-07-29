namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        private static int counter = 0;
        private static HashSet<string> words = new HashSet<string>();
        static void Main(string[] args)
        {
            var word = Console.ReadLine().ToCharArray();

            FindAll(word, 0);

            Console.WriteLine(counter);
            Console.WriteLine(string.Join("\n", words));
        }

        private static void FindAll(char[] word, int index)
        {
            if (index >= word.Length)
            {
                counter++;
                words.Add(string.Join("", word));
                return;
            }
            if (word[index] != '*')
            {
                FindAll(word, index + 1);
            }
            else
            {
                word[index] = 'L';
                FindAll(word, index + 1);
                word[index] = 'R';
                FindAll(word, index + 1);
                word[index] = 'S';
                FindAll(word, index + 1);
                word[index] = '*';
            }
        }
    }
}