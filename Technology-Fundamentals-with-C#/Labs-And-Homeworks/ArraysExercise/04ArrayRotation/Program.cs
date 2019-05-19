using System;
using System.Linq;

namespace _04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int firstNumber = numbers[0]; // sets the first number of the array

                for (int j = 0; j < numbers.Length - 1; j++) // въртим до предпоследния елемент от масива
                {
                    numbers[j] = numbers[j + 1]; // the current number becomes the next number
                }

                numbers[numbers.Length - 1] = firstNumber; // the last number becomes the first number from the current array
            }

            Console.WriteLine(string.Join(" ", numbers)); // print the new array
        }
    }
}
