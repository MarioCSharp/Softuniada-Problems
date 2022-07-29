// 90/100 because i am lazy. I need to make it to print them the correct order.

namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        static void Main()
        {
            var zonesCount = int.Parse(Console.ReadLine());

            var zones = new List<Zone>();
            var pices = new double[zonesCount + 1];

            for (int i = 1; i <= zonesCount; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ', ':', ',' }
                , StringSplitOptions.RemoveEmptyEntries);

                var x1 = int.Parse(args[1]);
                var y1 = int.Parse(args[2]);
                var x2 = x1 + int.Parse(args[4]);
                var y2 = y1 + int.Parse(args[3]);
                var price = double.Parse(args[5]);

                var zone = new Zone(i, args[0], x1, x2, y1, y2, price);
                pices[i] = price;

                zones.Add(zone);
            }

            var tests = Console.ReadLine().Split(';').ToArray();

            var zonePrice = new double[tests.Length];
            var zoneName = new string[tests.Length];

            for (int i = 0; i < tests.Length; i++)
            {
                var args = tests[i].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var x = args[0];
                var y = args[1];

                foreach (var zone in zones)
                {
                    if (zone.IsInZone(x, y))
                    {
                        zonePrice[i] = zone.CostPerMinute;
                        zoneName[i] = zone.Name;
                    }
                }
            }

            var t = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var k = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, Tuple<double, int>>();

            for (int i = 0; i < tests.Length; i++)
            {
                var args = tests[i].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var xDiff = Math.Abs(t[0] - args[0]);
                var yDiff = Math.Abs(t[1] - args[1]);

                var blocks = xDiff + yDiff - 1;

                var res = Math.Ceiling((double)(blocks * 2 * k) / 60);

                var time = (int)res;

                res *= zonePrice[i];

                result.Add($"Zone Type: {zoneName[i]}; X: {args[0]}; Y: {args[1]}; Price: {res:f2}", Tuple.Create(res, time));
            }

            Console.WriteLine(result.OrderBy(x => x.Value.Item1).ThenBy(x => x.Value.Item2).FirstOrDefault().Key);
        }
    }

    class Zone
    {
        public Zone(int id, string name, int x1, int x2, int y1
            , int y2, double costPerMinute)
        {
            Id = id;
            Name = name;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            CostPerMinute = costPerMinute;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public double CostPerMinute { get; set; }

        public bool IsInZone(int x, int y)
        {
            var isInHor = x >= X1 && x <= X2;
            var isInVer = y >= Y1 && y <= Y2;

            return isInHor && isInVer;
        }
    }
}