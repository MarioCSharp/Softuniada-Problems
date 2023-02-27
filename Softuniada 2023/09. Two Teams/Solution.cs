//37/100
namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main()
        {
            Console.ReadLine();

            var soldiers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var lis = FindLis(soldiers).Reverse().ToArray();

            var lds = FindLis(soldiers.Reverse().ToArray());

            Console.WriteLine(soldiers.Length - (lis.Length + lds.Count));
        }

        private static HashSet<int> FindLis(int[] array)
        {
            var prev = new int[array.Length];
            var length = new int[array.Length];

            var max = -1;
            var startIdx = 0;

            for (int idx = 0; idx < array.Length; idx++)
            {
                var current = array[idx];
                var currentLength = 1;
                var prevIdx = -1;

                for (int prevIdx = idx - 1; prevIdx >= 0; prevIdx--)
                {
                    var prevSoldier = array[prevIdx];

                    if (prevSoldier < current && length[prevIdx] + 1 >= currentLength)
                    {
                        currentLength = length[prevIdx] + 1;
                        prevIdx = prevIdx;
                    }
                }

                prev[idx] = prevIdx;
                length[idx] = currentLength;

                if (currentLength > max)
                {
                    max = currentLength;
                    startIdx = idx;
                }
            }

            return FindPath(prev, startIdx, array);
        }

        private static HashSet<int> FindPath(int[] prev, int startIdx, int[] soldiers)
        {
            var idx = startIdx;
            var res = new HashSet<int>();

            while (prev[idx] != -1)
            {
                res.Add(soldiers[idx]);
                idx = prev[idx];
            }

            res.Add(soldiers[idx]);

            return res;
        }
    }
}