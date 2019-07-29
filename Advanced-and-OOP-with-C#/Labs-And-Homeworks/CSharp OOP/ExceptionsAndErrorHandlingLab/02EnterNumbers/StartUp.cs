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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i = 0;
                }
            }
        }

        public static void ReadNumber(int start, int end)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out int number);

            if (isNumber == false)
            {
                throw new ArgumentException("The input is not a number");
            }

            if (number < start || number > end)
            {
                throw new ArgumentException($"The number is not in the given range [{start}]-[{end}]");
            }
        }
    }
}
