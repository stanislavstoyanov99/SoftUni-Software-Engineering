using System;

namespace _01BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bitToFind = int.Parse(Console.ReadLine());

            string numberBinary = Convert.ToString(number, 2);
            int counter = 0;

            // First solution
            while (number > 0)
            {
                int reminder = number % 2;
                if (reminder == bitToFind)
                {
                    counter++;
                }

                number /= 2;
            }

            Console.WriteLine(counter);
            counter = 0;

            // Second solution
            for (int i = 0; i < numberBinary.Length; i++)
            {
                if (numberBinary[i] - '0' == bitToFind)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
