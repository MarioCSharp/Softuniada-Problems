namespace Softuniada
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var width = n + 5;
            var used = 0;

            if (width % 2 == 0)
            {
                used = width / 2 - 1;
                Console.WriteLine(new string('_', width / 2 - 1) + '^' + new string('_', width / 2 - 1));
            }
            else
            {
                used = width / 2;
                Console.WriteLine(new string('_', width / 2) + '^' + new string('_', width / 2));
            }

            var dots = 1;

            for (int i = used - 1; i >= 0; i--)
            {
                if (i == used - 1)
                {
                    Console.WriteLine(new string('_', i) + "/" + "|" + "\\" + new string('_', i));
                    continue;
                }
                else if (i == used - 2)
                {
                    Console.WriteLine(new string('_', i) + "/" + "|||" + "\\" + new string('_', i));
                }
                else
                {
                    Console.WriteLine(new string('_', i) + "/" + new string('.', dots) + "|||" + new string('.', dots) + "\\" + new string('_', i));
                    dots++;
                }

            }

            Console.WriteLine("_/" + new string('.', dots - 2) + "|||" + new string('.', dots - 2) + "\\_");

            for (int i = 0; i < n; i++)
            {
                if (width % 2 != 0)
                {
                    Console.WriteLine(new string('_', used - 1) + "|||" + new string('_', used - 1));
                }
            }


            Console.WriteLine(new string('_', used - 1) + "~~~" + new string('_', used - 1));
            Console.WriteLine(new string('_', used - 2) + "//!\\\\" + new string('_', used - 2));

            used -= 3;
            dots = 1;
            while (used != 0)
            {
                Console.WriteLine(new string('_', used) + "//" + new string('.', dots) + "!" + new string('.', dots) + "\\\\" + new string('_', used));
                used--;
                dots++;
            }

        }
    }
}