namespace ConsoleApp14
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            string toConvertTo = Console.ReadLine();
            if (IsTransformable(word, toConvertTo))
            {
                Console.WriteLine($"The minimum operations required to convert \"{word}\" to \"{toConvertTo}\" are {CalucateMinimumOperations(word, toConvertTo)}");
            }
            else
            {
                Console.WriteLine("The name cannot be transformed!");
            }
        }
        public static bool IsTransformable(string first, string second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }
            return string.Concat(first.OrderBy(x => x)) == string.Concat(second.OrderBy(x => x));
        }
        public static int CalucateMinimumOperations(string first, string second)
        {
            int count = 0;
            for (int i = first.Length - 1, j = second.Length - 1; i >= 0; i--, j--)
            {
                while (i >= 0 && first[i] != second[j])
                {
                    i--;
                    count++;
                }
            }
            return count;
        }
    }
}