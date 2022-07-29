// Just the Knapsack Algorithm

namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            int stamina = int.Parse(Console.ReadLine());

            List<string> trackNames = Console.ReadLine().Split(' ').ToList();
            List<int> trackStaminaNeeded = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> trackChallenges = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<Track> tracks = new List<Track>();

            for (int i = 0; i < trackChallenges.Count; i++)
            {
                tracks.Add(new Track(trackNames[i], trackStaminaNeeded[i], trackChallenges[i]));
            }

            tracks = tracks.OrderByDescending(x => x.Stamina).ToList();

            var dp = new int[tracks.Count + 1, stamina + 1];
            var tracksUsed = new bool[tracks.Count + 1, stamina + 1];

            for (int trackIndex = 0; trackIndex < tracks.Count; trackIndex++)
            {
                var track = tracks[trackIndex];
                var rowIndex = trackIndex + 1;

                for (int s = 0; s <= stamina; s++)
                {
                    if (track.Stamina > s)
                    {
                        continue;
                    }

                    var excluding = dp[rowIndex - 1, s];
                    var including = track.Challenges + dp[rowIndex - 1, s - track.Stamina];

                    if (including > excluding)
                    {
                        dp[rowIndex, s] = including;
                        tracksUsed[rowIndex, s] = true;
                    }
                    else
                    {
                        dp[rowIndex, s] = excluding;
                    }
                }
            }

            var res = new List<Track>();
            var currentStamina = stamina;

            for (int trackIndex = tracks.Count; trackIndex >= 0; trackIndex--)
            {
                if (tracksUsed[trackIndex, currentStamina])
                {
                    res.Add(tracks[trackIndex - 1]);

                    currentStamina -= tracks[trackIndex - 1].Stamina;
                }
            }

            Console.WriteLine(string.Join(" ", res.Select(x => x.Name).OrderBy(x => x)));
            Console.WriteLine(dp[tracks.Count, stamina]);
            Console.WriteLine(stamina - res.Sum(x => x.Stamina));

        }
    }
    public class Track
    {
        public Track(string name, int stamina, int challenges)
        {
            this.Name = name;
            this.Stamina = stamina;
            this.Challenges = challenges;
        }
        public string Name { get; set; }
        public int Stamina { get; set; }
        public int Challenges { get; set; }
    }
}