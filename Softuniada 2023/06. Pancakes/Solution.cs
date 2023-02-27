namespace Softuniada
{
    public class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

            maxSubArraySum(a, a.Length);
        }
        static void maxSubArraySum(int[] a, int size)
        {
            int max_so_far = int.MinValue, max_ending_here = 0,
                start = 0, end = 0, s = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here += a[i];

                if (max_so_far <= max_ending_here)
                {
                    if (s - i == start - end && max_so_far == max_ending_here)
                    {
                        continue;
                    }

                    max_so_far = max_ending_here;
                    start = s;
                    end = i;
                }

                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                    s = i + 1;
                }
            }
            Console.WriteLine($"{max_so_far} {start} {end}");
        }
    }
}