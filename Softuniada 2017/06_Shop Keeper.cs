// 50/100 

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
            var available = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var count = 0;

            var orders = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < orders.Count; i++)
            {
                if (i == 0 && !available.Contains(orders[i]))
                {
                    Console.WriteLine("impossible");
                    return;
                }

                if (!(i + 1 < orders.Count))
                {
                    continue;
                }

                if (available.Contains(orders[i + 1]))
                {
                    continue;
                }

                var index = i + 1;

                var temp = orders.Skip(index).ToArray().Reverse().ToArray();

                var changed = false;

                count++;

                for (int j = 0; j < available.Length; j++)
                {
                    if (!temp.Contains(available[j]))
                    {
                        available[j] = orders[index];
                        changed = true;
                        break;
                    }
                }

                if (changed)
                {
                    continue;
                }

                var elToChange = 0;

                for (int j = 0; j < temp.Length; j++)
                {
                    if (available.Contains(orders[j]))
                    {
                        elToChange = orders[j];
                        break;
                    }
                }

                var idx = 0;

                for (int j = 0; j < available.Length; j++)
                {
                    if (elToChange == available[j])
                    {
                        idx = j;
                        break;
                    }
                }

                available[idx] = orders[index];
            }

            Console.WriteLine(count);
        }
    }
}