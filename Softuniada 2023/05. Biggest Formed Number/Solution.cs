namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            LargestNumberMethod(Console.ReadLine().Split().Select(int.Parse).ToList());
        }
        public static void LargestNumberMethod(List<int> inputList)
        {
            string output = string.Empty;

            List<string> newList = inputList.Select(x => x.ToString()).ToList();

            newList.Sort(CompareTo);

            for (int i = 0; i < inputList.Count; i++)
            {
                output = output + newList[i];
            }

            if (output[0] == '0' && output.Length > 1)
            {
                Console.Write("0");
            }

            Console.Write(output);
        }

        internal static int CompareTo(string X, string Y)
        {
            string YX = Y + X;

            string XY = X + Y;

            return XY.CompareTo(YX) > 0 ? -1 : 1;
        }
    }
}