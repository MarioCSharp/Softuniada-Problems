namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        private static string[] elements;
        private static List<Tuple<string, string>> dependencies = new List<Tuple<string, string>>();
        private static string[] permutation;
        private static HashSet<string> used = new HashSet<string>();
        private static HashSet<string[]> col = new HashSet<string[]>();
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            elements = Enumerable.Range(1, n).Select(x => x.ToString()).ToArray();
            permutation = new string[elements.Length];

            var m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var line = Console.ReadLine().Split(" > ");
                dependencies.Add(Tuple.Create(line[0], line[1]));
            }

            GetCount(0);

            var ans = 0;

            foreach (var perm in col)
            {
                if (DependenciesAreRight(perm))
                {
                    ans++;
                }
            }

            Console.WriteLine(ans);
        }

        private static void GetCount(int idx)
        {
            if (idx == elements.Length)
            {
                col.Add(permutation.ToArray());
                return;
            }

            foreach (var element in elements)
            {
                if (!used.Contains(element))
                {
                    used.Add(element);
                    permutation[idx] = element;
                    GetCount(idx + 1);
                    used.Remove(element);
                }
            }
        }

        private static bool DependenciesAreRight(string[] perm)
        {
            foreach (var dependencie in dependencies)
            {
                var idx1 = -1;
                var idx2 = -1;

                for (int i = 0; i < perm.Length; i++)
                {
                    if (idx1 != -1 && idx2 != -1)
                    {
                        break;
                    }

                    if (dependencie.Item1.ToString() == perm[i])
                    {
                        idx1 = i;
                    }
                    if (dependencie.Item2.ToString() == perm[i])
                    {
                        idx2 = i;
                    }
                }

                if (idx1 < idx2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}