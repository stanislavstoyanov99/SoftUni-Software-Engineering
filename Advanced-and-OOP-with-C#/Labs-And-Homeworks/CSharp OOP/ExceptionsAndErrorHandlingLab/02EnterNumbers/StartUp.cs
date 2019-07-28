using System;

namespace _02EnterNumbers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadNumber(1, 10);
                }
                catch (ArgumentException)
                {
                    i = 0;
                    ReadNumber(1, 10);
                }
            }
        }

        public static void ReadNumber(int start, int end)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input.GetType() != typeof(int))
            {
                throw new ArgumentException("The input is not a number");
            }

            if (input < start || input > end)
            {
                throw new ArgumentException($"The number is not in the given range [{start}]-[{end}]");
            }
        }
    }
}
