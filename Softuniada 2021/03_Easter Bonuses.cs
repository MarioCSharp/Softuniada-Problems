namespace ConsoleApp9
{
    using System;
    using System.Linq;
    class Code
    {
        static void Main(string[] args)
        {
            string input = null;
            int final = 0;
            while ((input = Console.ReadLine()) != "stop")
            {
                var name = input;
                var tasks = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                int sum = 1;
                int personBonus = 0;
                for (int i = 0; i < tasks.Count; i++)
                {
                    for (int j = 0; j < tasks.Count; j++)
                    {
                        if (i != j)
                        {
                            sum *= tasks[j];
                        }
                    }
                    personBonus += sum;
                    sum = 1;
                }
                Console.WriteLine($"{name} has a bonus of {personBonus} lv.");
                final += personBonus;
            }
            Console.WriteLine($"The amount of all bonuses is {final} lv.");
        }
    }
}