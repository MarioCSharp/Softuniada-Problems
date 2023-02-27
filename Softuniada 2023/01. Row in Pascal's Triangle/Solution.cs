namespace Softuniada
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", getRow(int.Parse(Console.ReadLine()))));
        }

        public static List<int> getRow(int n)
        {
            List<int> current = new List<int>();

            current.Add(1);

            if (n == 0)
                return current;

            List<int> previous = getRow(n - 1);

            for (int i = 1; i < previous.Count; i++)
            {

                int curr = previous[i - 1] + previous[i];
                current.Add(curr);
            }

            current.Add(1);

            return current;
        }
    }
}