// 80/100

using System;
using System.Linq;
using System.Collections.Generic;

class ThreeBrothers
{
    static void Main()
    {
        var inp1 = Console.ReadLine().Split().Select(int.Parse).ToList();
        var inp2 = Console.ReadLine().Split().Select(int.Parse).ToList();

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "nexus" && inp1.Count > 0 && inp2.Count > 0)
        {
            var split = input.Split('|');

            var partOne = split[0].Split(':').Select(int.Parse).ToArray();
            var partTwo = split[1].Split(':').Select(int.Parse).ToArray();

            if (partOne[0] < partTwo[0] && partOne[1] < partTwo[1])
            {
                continue;
            }

            var nexusValue = inp1[partOne[0]] + inp1[partTwo[0]] + inp2[partOne[1]] + inp2[partTwo[1]];

            var skipIndexesInp1 = new List<int>();
            skipIndexesInp1.Add(partOne[0]);
            skipIndexesInp1.Add(partTwo[0]);

            var skipIndexesInp2 = new List<int>();
            skipIndexesInp2.Add(partTwo[1]);
            skipIndexesInp2.Add(partOne[1]);

            var tempInp1 = new List<int>();
            var tempInp2 = new List<int>();

            skipIndexesInp1.Sort();
            skipIndexesInp2.Sort();

            for (int i = 0; i < inp1.Count; i++)
            {
                if (i >= skipIndexesInp1[0] && i <= skipIndexesInp1[1])
                {
                    continue;
                }

                tempInp1.Add(inp1[i] + nexusValue);
            }

            for (int i = 0; i < inp2.Count; i++)
            {
                if (i >= skipIndexesInp2[0] && i <= skipIndexesInp2[1])
                {
                    continue;
                }

                tempInp2.Add(inp2[i] + nexusValue);
            }

            inp1 = tempInp1;
            inp2 = tempInp2;
        }

        Console.WriteLine(string.Join(", ", inp1));
        Console.WriteLine(string.Join(", ", inp2));
    }
}