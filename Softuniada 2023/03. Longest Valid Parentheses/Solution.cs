namespace Softuniada
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(findMaxLen(Console.ReadLine()));
        }
        public static int findMaxLen(string input)
        {
            int n = input.Length;

            Stack<int> ans = new Stack<int>();
            ans.Push(-1);

            int res = 0;

            for (int i = 0; i < n; i++)
            {
                if (input[i] == '(')
                {
                    ans.Push(i);
                }

                else
                {

                    if (ans.Count > 0)
                    {
                        ans.Pop();
                    }

                    if (ans.Count > 0)
                    {
                        res
                            = Math.Max(res,
                                       i - ans.Peek());
                    }

                    else
                    {
                        ans.Push(i);
                    }
                }
            }

            return res;
        }
    }
}